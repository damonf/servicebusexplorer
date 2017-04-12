using MediatR;
using ServiceBusExplorer.Api.Models;

namespace ServiceBusExplorer.Api.Features.Topic
{
    public class GetTopic : IRequest<TopicDetailModel>
    {
        public string Path { get; set; }
    }
}
