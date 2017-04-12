using MediatR;
using ServiceBusExplorer.Api.Models;

namespace ServiceBusExplorer.Api.Features.Queue
{
    public class GetQueue : IRequest<QueueDetailModel>
    {
        public string Path { get; set; }
    }
}
