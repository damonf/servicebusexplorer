using System.Threading.Tasks;

namespace ServiceBusExplorer.Api.Features.Hub
{
    public interface IHubTicker
    {
        Task StartAsync();
        Task StopAsync();
    }
}
