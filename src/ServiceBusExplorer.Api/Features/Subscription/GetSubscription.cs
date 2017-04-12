using MediatR;
using ServiceBusExplorer.Api.Models;

namespace ServiceBusExplorer.Api.Features.Subscription
{
    public class GetSubscription : IRequest<SubscriptionDetailModel>
    {
        public string TopicPath { get; set; }
        public string Name { get; set; }
    }
}
