using System;
using MediatR;

namespace ServiceBusExplorer.Api.Features.ServiceBus
{
    public class GetServiceBusAddress : IRequest<Uri>
    {
    }
}
