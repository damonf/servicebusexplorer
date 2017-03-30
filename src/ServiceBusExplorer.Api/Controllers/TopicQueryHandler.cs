using System;
using System.Threading.Tasks;
using MediatR;
using ServiceBusExplorer.Api.Infrastructure;
using ServiceBusExplorer.Api.Model;

namespace ServiceBusExplorer.Api.Controllers
{
    public class TopicQueryHandler : IAsyncRequestHandler<GetTopic, TopicDetailModel>
    {
        private readonly INamespaceManagerWrapper _namespaceManager;

        public TopicQueryHandler(
            IAppSettings appSettings,
            INamespaceManagerProvider namespaceManagerProvider
            )
        {
            var connectionString = appSettings.ServiceBusConnectionString;
            _namespaceManager = namespaceManagerProvider.CreateFromConnectionString(connectionString);
        }

        public async Task<TopicDetailModel> Handle(GetTopic message)
        {
            var topicDescription = await _namespaceManager.GetTopicAsync(message.Path);

            return new TopicDetailModel
            {
                Status = Enum.GetName(topicDescription.Status.GetType(), topicDescription.Status),
                IsReadonly = topicDescription.IsReadOnly,
                SizeInBytes = topicDescription.SizeInBytes,
                MaxSizeInMegabytes = topicDescription.MaxSizeInMegabytes,
                CreatedAt = topicDescription.CreatedAt,
                AccessedAt = topicDescription.AccessedAt,
                UpdatedAt = topicDescription.UpdatedAt,

                DeadLetterMessageCount = topicDescription.MessageCountDetails.DeadLetterMessageCount,
                ActiveMessageCount = topicDescription.MessageCountDetails.ActiveMessageCount,
                ScheduledMessageCount = topicDescription.MessageCountDetails.ScheduledMessageCount,
                TransferDeadLetterMessageCount = topicDescription.MessageCountDetails.TransferDeadLetterMessageCount,
                TransferMessageCount = topicDescription.MessageCountDetails.TransferMessageCount,

                EnablePartitioning = topicDescription.EnablePartitioning,
                RequiresDuplicateDetection = topicDescription.RequiresDuplicateDetection,
                EnableBatchedOperations = topicDescription.EnableBatchedOperations,
                IsAnonymousAccessible = topicDescription.IsAnonymousAccessible,
                SupportOrdering = topicDescription.SupportOrdering,
                EnableExpress = topicDescription.EnableExpress,
                UserMetadata = topicDescription.UserMetadata,
                AvailabilityStatus = Enum.GetName(topicDescription.AvailabilityStatus.GetType(), topicDescription.AvailabilityStatus),
                DefaultMessageTimeToLive = topicDescription.DefaultMessageTimeToLive.ToReadableString(),
                AutoDeleteOnIdle = topicDescription.AutoDeleteOnIdle.ToReadableString(),
                DuplicateDetectionHistoryTimeWindow = topicDescription.DuplicateDetectionHistoryTimeWindow.ToReadableString(),
                SubscriptionCount = topicDescription.SubscriptionCount,
                EnableFilteringMessagesBeforePublishing = topicDescription.EnableFilteringMessagesBeforePublishing
            };
        }
    }
}
