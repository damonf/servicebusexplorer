using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using Serilog;
using ServiceBusExplorer.Api.Infrastructure;
using Module = Autofac.Module;

namespace ServiceBusExplorer.Api.DependencyResolution
{
    public class AutofacConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(Log.Logger).As<ILogger>();
            builder.RegisterType<GlobalExceptionHandlerMiddleware>();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();

            base.Load(builder);
        }
    }
}
