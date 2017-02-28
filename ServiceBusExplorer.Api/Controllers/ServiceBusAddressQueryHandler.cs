using System;
using MediatR;
using ServiceBusExplorer.Api.Infrastructure;

namespace ServiceBusExplorer.Api.Controllers
{
    public class ServiceBusAddressQueryHandler : IRequestHandler<GetServiceBusAddress, Uri>
    {
        private readonly INamespaceManagerWrapper _namespaceManager;

        public ServiceBusAddressQueryHandler(
            IAppSettings appSettings,
            INamespaceManagerProvider namespaceManagerProvider
            )
        {
            var connectionString = appSettings.ServiceBusConnectionString;
            _namespaceManager = namespaceManagerProvider.CreateFromConnectionString(connectionString);
        }

        public Uri Handle(GetServiceBusAddress message)
        {
            return _namespaceManager.Address;
        }
    }
}
