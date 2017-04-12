using System;

namespace ServiceBusExplorer.Api.Models
{
    public class SubscriptionDetailModel
    {
        public string Status { get; set; }
        public bool IsReadonly { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime AccessedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public long MessageCount { get; set; }
        public long DeadLetterMessageCount { get; set; }
        public long ActiveMessageCount { get; set; }
        public long ScheduledMessageCount { get; set; }
        public long TransferDeadLetterMessageCount { get; set; }
        public long TransferMessageCount { get; set; }

        public bool EnableDeadLetteringOnMessageExpiration { get; set; }
        public bool EnableDeadLetteringOnFilterEvaluationExceptions { get; set; }
        public bool RequiresSession { get; set; }
        public bool EnableBatchedOperations { get; set; }
        public int MaxDeliveryCount { get; set; }
        public string UserMetadata { get; set; }
        public string ForwardTo { get; set; }
        public string ForwardDeadLetteredMessagesTo { get; set; }
        public string AvailabilityStatus { get; set; }
        public string LockDuration { get; set; }
        public string DefaultMessageTimeToLive { get; set; }
        public string AutoDeleteOnIdle { get; set; }
    }
}
