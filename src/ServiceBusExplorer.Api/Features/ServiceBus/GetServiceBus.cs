using MediatR;
using ServiceBusExplorer.Api.Models;

namespace ServiceBusExplorer.Api.Features.ServiceBus
{
    public class GetServiceBus : IRequest<ServiceBusModel>
    {
    }
}
