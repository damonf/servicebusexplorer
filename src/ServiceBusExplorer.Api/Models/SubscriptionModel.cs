
namespace ServiceBusExplorer.Api.Models
{
    public class SubscriptionModel
    {
        public string Name { get; set; }
        public long ActiveMessageCount { get; set; }
        public long DeadLetterMessageCount { get; set; }
    }
}
