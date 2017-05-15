using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNet.SignalR;
using Serilog;
using ServiceBusExplorer.Api.Features.ServiceBus;
using ServiceBusExplorer.Api.Infrastructure;

namespace ServiceBusExplorer.Api.Features.Hub
{
    public class HubTicker : IHubTicker, IDisposable
    {
        private readonly IHubContext<IServiceBusExplorerHub> _hubContext;
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private readonly AutoResetEvent _stopSignal = new AutoResetEvent(false);
        private readonly int _interval;
        private Task _running;

        public HubTicker(
            IHubContext<IServiceBusExplorerHub> hubContext,
            IMediator mediator,
            IAppSettings appSettings,
            ILogger logger)
        {
            _hubContext = hubContext;
            _mediator = mediator;
            _logger = logger;
            _interval = appSettings.AutoRefreshIntervalMs;
        }

        public async Task StartAsync()
        {
            await _semaphore.WaitAsync();

            try
            {
                if (_running != null)
                {
                    return;
                }

                _running = Task.Run(() =>
                {
                    Run();
                });

            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task StopAsync()
        {
            await _semaphore.WaitAsync();

            try
            {
                if (_running == null)
                {
                    return;
                }

                _stopSignal.Set();
                await _running;
                _running = null;
            }
            finally
            {
                _semaphore.Release();
            }

        }

        private void Run()
        {
            _logger.Information($"{nameof(HubTicker)} started");

            while (!_stopSignal.WaitOne(_interval))
            {
                try
                {
                    var update = _mediator.Send(new GetServiceBus()).Result;
                    _hubContext.Clients.All.ServiceBusUpdate(update);
                }
                catch (Exception e)
                {
                    _logger.Error("Exception during servicebus update: {message}", e.Message);
                }
            }

            _logger.Information($"{nameof(HubTicker)} stopped");
        }

        public void Dispose()
        {
            _semaphore?.Dispose();
            _stopSignal?.Dispose();
            _running?.Dispose();
        }
    }
}
