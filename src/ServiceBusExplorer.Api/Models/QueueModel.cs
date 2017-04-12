
namespace ServiceBusExplorer.Api.Models
{
    public class QueueModel
    {
        public string Name { get; set; }
        public long ActiveMessageCount { get; set; }
        public long DeadLetterMessageCount { get; set; }
    }
}
