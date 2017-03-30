using System;
using MediatR;

namespace ServiceBusExplorer.Api.Controllers
{
    public class GetServiceBusAddress : IRequest<Uri>
    {
    }
}
