using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace ServiceBusExplorer.Api.Infrastructure
{
    public interface INamespaceManagerWrapper
    {
        Task<IEnumerable<QueueDescription>> GetQueuesAsync();
        Task<IEnumerable<TopicDescription>> GetTopicsAsync();
        Task<IEnumerable<SubscriptionDescription>> GetSubscriptionsAsync(string topicPath);
        Task<QueueDescription> GetQueueAsync(string path);
        Task<TopicDescription> GetTopicAsync(string path);
        Task<SubscriptionDescription> GetSubscriptionAsync(string topicPath, string name);
        Uri Address { get; }
    }

    public class NamespaceManagerWrapper : INamespaceManagerWrapper
    {
        private readonly NamespaceManager _namespaceManager;

        public NamespaceManagerWrapper(NamespaceManager namespaceManager)
        {
            _namespaceManager = namespaceManager;
        }

        public async Task<IEnumerable<QueueDescription>> GetQueuesAsync()
        {
            return await _namespaceManager.GetQueuesAsync();
        }

        public async Task<IEnumerable<TopicDescription>> GetTopicsAsync()
        {
            return await _namespaceManager.GetTopicsAsync();
        }

        public async Task<IEnumerable<SubscriptionDescription>> GetSubscriptionsAsync(string topicPath)
        {
            return await _namespaceManager.GetSubscriptionsAsync(topicPath);
        }

        public async Task<QueueDescription> GetQueueAsync(string path)
        {
            return await _namespaceManager.GetQueueAsync(path);
        }

        public async Task<TopicDescription> GetTopicAsync(string path)
        {
            return await _namespaceManager.GetTopicAsync(path);
        }

        public async Task<SubscriptionDescription> GetSubscriptionAsync(string topicPath, string name)
        {
            return await _namespaceManager.GetSubscriptionAsync(topicPath, name);
        }

        public Uri Address => _namespaceManager.Address;
    }
}
