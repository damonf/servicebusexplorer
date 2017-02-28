using System;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using MediatR;
using Microsoft.AspNet.SignalR;
using Serilog;
using ServiceBusExplorer.Api.Controllers;

namespace ServiceBusExplorer.Api.Infrastructure
{
    public class HubTicker
    {
        private static HubTicker _instance;
        private const int Interval = 5000;  // TODO: put in app config

        private readonly IContainer _container;
        private readonly ManualResetEvent _stopSignal = new ManualResetEvent(false);
        private Task _running;

        private HubTicker(IContainer container)
        {
            _container = container;
        }

        public static void Start(IContainer container)
        {
            if (_instance != null)
            {
                throw new InvalidOperationException($"{nameof(HubTicker)} was already started");
            }

            _instance = new HubTicker(container);
            _instance.StartHubTicker();
        }

        public static void Stop()
        {
            _instance.StopHubTicker();
        }

        private void StopHubTicker()
        {
            _stopSignal.Set();
            _running.Wait();
        }

        private void StartHubTicker()
        {
            _running = Task.Run(() =>
            {
                Run();
            });
        }

        private void Run()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var hub = scope.Resolve<IHubContext<IServiceBusExplorerHub>>();
                var logger = scope.Resolve<ILogger>();
                var mediator = scope.Resolve<IMediator>();

                logger.Information($"{nameof(HubTicker)} started");

                while (!_stopSignal.WaitOne(Interval))
                {
                    try
                    {
                        var update = mediator.Send(new GetServiceBus()).Result;
                        hub.Clients.All.ServiceBusUpdate(update);
                    }
                    catch (Exception e)
                    {
                        logger.Error("Exception during servicebus update: {message}", e.Message);
                    }
                }

                logger.Information($"{nameof(HubTicker)} stopped");
            }
        }
    }
}
