using MediatR;
using ServiceBusExplorer.Api.Model;

namespace ServiceBusExplorer.Api.Controllers
{
    public class GetSubscription : IRequest<SubscriptionDetailModel>
    {
        public string TopicPath { get; set; }
        public string Name { get; set; }
    }
}
