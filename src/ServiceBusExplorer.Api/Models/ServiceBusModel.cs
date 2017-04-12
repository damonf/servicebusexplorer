
namespace ServiceBusExplorer.Api.Models
{
    public class ServiceBusModel
    {
        public QueueModel[] Queues { get; set; }
        public TopicModel[] Topics { get; set; }
    }
}
