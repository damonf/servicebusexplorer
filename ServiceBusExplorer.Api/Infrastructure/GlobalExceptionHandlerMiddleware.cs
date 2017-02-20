using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Serilog;

namespace ServiceBusExplorer.Api.Infrastructure
{
    public class GlobalExceptionHandlerMiddleware : OwinMiddleware
    {
        private readonly ILogger _logger;

        public GlobalExceptionHandlerMiddleware(OwinMiddleware next, ILogger logger) : base(next)
        {
            _logger = logger;
        }

        public override async Task Invoke(IOwinContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error: {message}", ex.Message);
            }
        }
    }

    //public static class GlobalExceptionMiddlewareExtensions
    //{
    //    public static void UseGlobalExceptionHandler(this IAppBuilder app)
    //    {
    //        app.Use<GlobalExceptionHandlerMiddleware>();
    //    }
    //}
}
