using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Autofac.Features.Variance;
using Autofac.Integration.WebApi;
using MediatR;
using Serilog;
using Module = Autofac.Module;

namespace ServiceBusExplorer.Api.Infrastructure
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

    public class MediatRConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            builder.Register<SingleInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t =>
                {
                    object o;
                    return c.TryResolve(t, out o) ? o : null;
                };
            });

            builder.Register<MultiInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
            });

            base.Load(builder);
        }
    }
}
