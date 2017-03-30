using MediatR;
using ServiceBusExplorer.Api.Model;

namespace ServiceBusExplorer.Api.Controllers
{
    public class GetTopic : IRequest<TopicDetailModel>
    {
        public string Path { get; set; }
    }
}
