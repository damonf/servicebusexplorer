
namespace ServiceBusExplorer.Api.Model
{
    public class ServiceBusModel
    {
        public QueueModel[] Queues { get; set; }
        public TopicModel[] Topics { get; set; }
    }
}
