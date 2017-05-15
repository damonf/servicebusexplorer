
namespace ServiceBusExplorer.Api.Infrastructure
{
    public interface IAppSettings
    {
        string ServiceBusConnectionString { get; }
        int AutoRefreshIntervalMs { get; }
        string AppPath { get; }
    }
}
