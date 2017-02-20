using Microsoft.ServiceBus;

namespace ServiceBusExplorer.Api.Infrastructure
{
    public interface INamespaceManagerProvider
    {
        INamespaceManagerWrapper CreateFromConnectionString(string connectionString);
    }

    public class NamespaceManagerProvider : INamespaceManagerProvider
    {
        public INamespaceManagerWrapper CreateFromConnectionString(string connectionString)
        {
            var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);
            return new NamespaceManagerWrapper(namespaceManager);
        }
    }
}
