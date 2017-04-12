
namespace ServiceBusExplorer.Api.Models
{
    public class TopicModel
    {
        public string Name { get; set; }
        public long ActiveMessageCount { get; set; }
        public long DeadLetterMessageCount { get; set; }
        public SubscriptionModel[] Subscriptions { get; set; }
    }
}
