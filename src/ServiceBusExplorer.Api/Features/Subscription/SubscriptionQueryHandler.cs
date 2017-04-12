using System;
using System.Threading.Tasks;
using MediatR;
using ServiceBusExplorer.Api.Infrastructure;
using ServiceBusExplorer.Api.Models;

namespace ServiceBusExplorer.Api.Features.Subscription
{
    public class SubscriptionQueryHandler : IAsyncRequestHandler<GetSubscription, SubscriptionDetailModel>
    {
        private readonly INamespaceManagerWrapper _namespaceManager;

        public SubscriptionQueryHandler(
            IAppSettings appSettings,
            INamespaceManagerProvider namespaceManagerProvider
            )
        {
            var connectionString = appSettings.ServiceBusConnectionString;
            _namespaceManager = namespaceManagerProvider.CreateFromConnectionString(connectionString);
        }

        public async Task<SubscriptionDetailModel> Handle(GetSubscription message)
        {
            var subscriptionDescription = await _namespaceManager.GetSubscriptionAsync(message.TopicPath, message.Name);

            return new SubscriptionDetailModel
            {
                Status = Enum.GetName(subscriptionDescription.Status.GetType(), subscriptionDescription.Status),
                IsReadonly = subscriptionDescription.IsReadOnly,
                CreatedAt = subscriptionDescription.CreatedAt,
                AccessedAt = subscriptionDescription.AccessedAt,
                UpdatedAt = subscriptionDescription.UpdatedAt,

                MessageCount = subscriptionDescription.MessageCount,
                DeadLetterMessageCount = subscriptionDescription.MessageCountDetails.DeadLetterMessageCount,
                ActiveMessageCount = subscriptionDescription.MessageCountDetails.ActiveMessageCount,
                ScheduledMessageCount = subscriptionDescription.MessageCountDetails.ScheduledMessageCount,
                TransferDeadLetterMessageCount = subscriptionDescription.MessageCountDetails.TransferDeadLetterMessageCount,
                TransferMessageCount = subscriptionDescription.MessageCountDetails.TransferMessageCount,

                EnableDeadLetteringOnMessageExpiration = subscriptionDescription.EnableDeadLetteringOnMessageExpiration,
                EnableDeadLetteringOnFilterEvaluationExceptions = subscriptionDescription.EnableDeadLetteringOnFilterEvaluationExceptions,
                RequiresSession = subscriptionDescription.RequiresSession,
                EnableBatchedOperations = subscriptionDescription.EnableBatchedOperations,
                MaxDeliveryCount = subscriptionDescription.MaxDeliveryCount,
                UserMetadata = subscriptionDescription.UserMetadata,
                ForwardTo = subscriptionDescription.ForwardTo,
                ForwardDeadLetteredMessagesTo = subscriptionDescription.ForwardDeadLetteredMessagesTo,
                AvailabilityStatus = Enum.GetName(subscriptionDescription.AvailabilityStatus.GetType(), subscriptionDescription.AvailabilityStatus),
                LockDuration = subscriptionDescription.LockDuration.ToReadableString(),
                DefaultMessageTimeToLive = subscriptionDescription.DefaultMessageTimeToLive.ToReadableString(),
                AutoDeleteOnIdle = subscriptionDescription.AutoDeleteOnIdle.ToReadableString(),
            };
        }
    }
}
