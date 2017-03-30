using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.ServiceBus.Messaging;
using ServiceBusExplorer.Api.Infrastructure;
using ServiceBusExplorer.Api.Model;
using TopicDescription = Microsoft.ServiceBus.Messaging.TopicDescription;

namespace ServiceBusExplorer.Api.Controllers
{
    public class ServiceBusQueryHandler : IAsyncRequestHandler<GetServiceBus, ServiceBusModel>
    {
        private readonly INamespaceManagerWrapper _namespaceManager;

        public ServiceBusQueryHandler(
            IAppSettings appSettings,
            INamespaceManagerProvider namespaceManagerProvider
            )
        {
            var connectionString = appSettings.ServiceBusConnectionString;
            _namespaceManager = namespaceManagerProvider.CreateFromConnectionString(connectionString);
        }

        public async Task<ServiceBusModel> Handle(GetServiceBus message)
        {
            var queuesTask = _namespaceManager.GetQueuesAsync();
            var topicsTask = GetTopicsAsync();

            await Task.WhenAll(queuesTask, topicsTask);

            return new ServiceBusModel
            {
                Queues = (await queuesTask).Select(q => new QueueModel
                {
                    Name = q.Path,
                    ActiveMessageCount = q.MessageCountDetails.ActiveMessageCount,
                    DeadLetterMessageCount = q.MessageCountDetails.DeadLetterMessageCount,
                }).ToArray(),

                Topics = (await topicsTask).Select(t => new TopicModel
                {
                    Name = t.Key.Path,
                    ActiveMessageCount = t.Key.MessageCountDetails.ActiveMessageCount,
                    DeadLetterMessageCount = t.Key.MessageCountDetails.DeadLetterMessageCount,

                    Subscriptions = t.Value.Select(s => new SubscriptionModel
                    {
                        Name = s.Name,
                        ActiveMessageCount = s.MessageCountDetails.ActiveMessageCount,
                        DeadLetterMessageCount = s.MessageCountDetails.DeadLetterMessageCount
                    }).ToArray()

                }).ToArray()
            };
        }

        private async Task<IDictionary<TopicDescription, IEnumerable<SubscriptionDescription>>> GetTopicsAsync()
        {
            var topics = (await _namespaceManager.GetTopicsAsync()).ToArray();

            var subscriptionTasks = topics.Select(t => _namespaceManager.GetSubscriptionsAsync(t.Path)).ToArray();

            var subscriptions = await Task.WhenAll(subscriptionTasks);

            var result = new Dictionary<TopicDescription, IEnumerable<SubscriptionDescription>>();

            for (var i = 0; i < topics.Length; ++i)
            {
                result.Add(topics[i], subscriptions[i]);
            }

            return result;
        }
    }
}
