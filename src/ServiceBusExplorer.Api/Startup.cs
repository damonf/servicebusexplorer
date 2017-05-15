using System;
using System.IO;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;
using Autofac;
using Autofac.Integration.SignalR;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using ServiceBusExplorer.Api.Features.Hub;
using ServiceBusExplorer.Api.Infrastructure;
using ServiceBusExplorer.Api.Logging;

namespace ServiceBusExplorer.Api
{
    public class Startup
    {
        private IHubTicker _hubTicker;

        public void Configuration(IAppBuilder app)
        {
            var config = ConfigureWebApi();
            config.Services.Add(typeof(IExceptionLogger), new SerilogExceptionLogger());

            var hubConfig = new HubConfiguration();
            var container = ConfigureContainer(hubConfig);

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll); // This must be done prior to calling IAppBuilder.UseWebApi
            app.UseWebApi(config);

            hubConfig.Resolver = new AutofacDependencyResolver(container);
            app.MapSignalR("/signalr", hubConfig);

            ConfigureStaticFiles(app, container.Resolve<IAppSettings>());

            _hubTicker = container.Resolve<IHubTicker>();
        }

        public void BeforeShutdown()
        {
            _hubTicker.StopAsync().Wait();
        }

        private static HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();

            SwaggerConfig.Register(config);

            config.EnableCors(new EnableCorsAttribute("*", "*", "GET, POST, OPTIONS, PUT, DELETE"));
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            config.MapHttpAttributeRoutes();

            return config;
        }
        private static IContainer ConfigureContainer(HubConfiguration hubConfig)
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            // register signalR hubs
            builder.RegisterType<ServiceBusExplorerHub>().ExternallyOwned();
            // register the hub context
            builder.Register(
                ctx =>
                    hubConfig.Resolver.Resolve<IConnectionManager>()
                        .GetHubContext<ServiceBusExplorerHub, IServiceBusExplorerHub>()).ExternallyOwned();

            builder.RegisterType<HubTicker>().As<IHubTicker>().SingleInstance();

            var settings = new JsonSerializerSettings {ContractResolver = new SignalRContractResolver()};
            var serializer = JsonSerializer.Create(settings);
            builder.RegisterInstance(serializer).As<JsonSerializer>();

            var container = builder.Build();
            return container;
        }

        // This allows us to also serve up the SPA
        private static void ConfigureStaticFiles(IAppBuilder app, IAppSettings appSettings)
        {
            var appFolder = appSettings.AppPath;

            try
            {
                var fileSystem = new PhysicalFileSystem(appFolder);
                var options = new FileServerOptions
                {
                    //EnableDirectoryBrowsing = true,
                    EnableDefaultFiles = true,
                    FileSystem = fileSystem
                };

                app.UseFileServer(options);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(
                    $"Error! \"AppPath\" specified in App.config does not exist: value is \"{appFolder}\"." +
                     "  GUI will not be served by this host.");
            }
        }
    }
}
