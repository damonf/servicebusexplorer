using System;
using Autofac;
using Microsoft.AspNet.SignalR;
using Serilog;
using ServiceBusExplorer.Api.Model;

namespace ServiceBusExplorer.Api.Infrastructure
{
    public interface IServiceBusExplorerHub
    {
        void ServiceBusUpdate(ServiceBusModel message);
    }

    public class ServiceBusExplorerHub : Hub<IServiceBusExplorerHub>
    {
        private readonly ILifetimeScope _hubLifetimeScope;
        private readonly ILogger _logger;

        public ServiceBusExplorerHub(ILifetimeScope lifetimeScope)
        {
            _hubLifetimeScope = lifetimeScope.BeginLifetimeScope();
            _logger = _hubLifetimeScope.Resolve<ILogger>();

            _logger.Information($"{nameof(ServiceBusExplorerHub)} starting");
        }

        protected override void Dispose(bool disposing)
        {
            // Dispose the hub lifetime scope when the hub is disposed.
            if (disposing)
            {
                _hubLifetimeScope?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
