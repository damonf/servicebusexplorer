using MediatR;
using ServiceBusExplorer.Api.Model;

namespace ServiceBusExplorer.Api.Controllers
{
    public class GetQueue : IRequest<QueueDetailModel>
    {
        public string Path { get; set; }
    }
}
