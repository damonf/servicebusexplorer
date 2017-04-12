using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using Serilog;

namespace ServiceBusExplorer.Api.Logging
{
    public class SerilogExceptionLogger : ExceptionLogger
    {
        private readonly ILogger _logger;

        public SerilogExceptionLogger()
        {
            _logger = Serilog.Log.Logger;
        }

        public override Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            var catchBlock = context.ExceptionContext.CatchBlock.Name;
            var ex = context.Exception;
            _logger.Error(ex, "Error: {message}\r\n Catchblock: {catchBlock}", ex.Message, catchBlock);

            return Task.FromResult(0);
        }
    }
}
