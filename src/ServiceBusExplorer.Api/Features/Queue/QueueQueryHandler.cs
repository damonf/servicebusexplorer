using System;
using System.Threading.Tasks;
using MediatR;
using ServiceBusExplorer.Api.Infrastructure;
using ServiceBusExplorer.Api.Models;

namespace ServiceBusExplorer.Api.Features.Queue
{
    public class QueueQueryHandler : IAsyncRequestHandler<GetQueue, QueueDetailModel>
    {
        private readonly INamespaceManagerWrapper _namespaceManager;

        public QueueQueryHandler(
            IAppSettings appSettings,
            INamespaceManagerProvider namespaceManagerProvider
            )
        {
            var connectionString = appSettings.ServiceBusConnectionString;
            _namespaceManager = namespaceManagerProvider.CreateFromConnectionString(connectionString);
        }

        public async Task<QueueDetailModel> Handle(GetQueue message)
        {
            var queueDescription = await _namespaceManager.GetQueueAsync(message.Path);

            return new QueueDetailModel
            {
                Status = Enum.GetName(queueDescription.Status.GetType(), queueDescription.Status),
                IsReadonly = queueDescription.IsReadOnly,
                SizeInBytes = queueDescription.SizeInBytes,
                MaxSizeInMegabytes = queueDescription.MaxSizeInMegabytes,
                CreatedAt = queueDescription.CreatedAt,
                AccessedAt = queueDescription.AccessedAt,
                UpdatedAt = queueDescription.UpdatedAt,

                MessageCount = queueDescription.MessageCount,
                DeadLetterMessageCount = queueDescription.MessageCountDetails.DeadLetterMessageCount,
                ActiveMessageCount = queueDescription.MessageCountDetails.ActiveMessageCount,
                ScheduledMessageCount = queueDescription.MessageCountDetails.ScheduledMessageCount,
                TransferDeadLetterMessageCount = queueDescription.MessageCountDetails.TransferDeadLetterMessageCount,
                TransferMessageCount = queueDescription.MessageCountDetails.TransferMessageCount,

                EnablePartitioning = queueDescription.EnablePartitioning,
                EnableDeadLetteringOnMessageExpiration = queueDescription.EnableDeadLetteringOnMessageExpiration,
                RequiresDuplicateDetection = queueDescription.RequiresDuplicateDetection,
                RequiresSession = queueDescription.RequiresSession,
                EnableBatchedOperations = queueDescription.EnableBatchedOperations,
                IsAnonymousAccessible = queueDescription.IsAnonymousAccessible,
                SupportOrdering = queueDescription.SupportOrdering,
                EnableExpress = queueDescription.EnableExpress,

                MaxDeliveryCount = queueDescription.MaxDeliveryCount,
                UserMetadata = queueDescription.UserMetadata,
                ForwardTo = queueDescription.ForwardTo,
                ForwardDeadLetteredMessagesTo = queueDescription.ForwardDeadLetteredMessagesTo,
                AvailabilityStatus = Enum.GetName(queueDescription.AvailabilityStatus.GetType(), queueDescription.AvailabilityStatus),
                LockDuration = queueDescription.LockDuration.ToReadableString(),
                DefaultMessageTimeToLive = queueDescription.DefaultMessageTimeToLive.ToReadableString(),
                AutoDeleteOnIdle = queueDescription.AutoDeleteOnIdle.ToReadableString(),
                DuplicateDetectionHistoryTimeWindow = queueDescription.DuplicateDetectionHistoryTimeWindow.ToReadableString(),
            };
        }
    }
}
