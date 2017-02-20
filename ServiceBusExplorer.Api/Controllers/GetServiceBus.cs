using MediatR;
using ServiceBusExplorer.Api.Model;

namespace ServiceBusExplorer.Api.Controllers
{
    public class GetServiceBus : IRequest<ServiceBusModel>
    {
    }
}
