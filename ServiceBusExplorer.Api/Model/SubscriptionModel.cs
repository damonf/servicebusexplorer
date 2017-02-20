
namespace ServiceBusExplorer.Api.Model
{
    public class SubscriptionModel
    {
        public string Name { get; set; }
        public long ActiveMessageCount { get; set; }
        public long DeadLetterMessageCount { get; set; }
    }
}
