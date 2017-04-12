using System;

namespace ServiceBusExplorer.Api.Models
{
    public class TopicDetailModel
    {
        public string Status { get; set; }
        public bool IsReadonly { get; set; }
        public long SizeInBytes { get; set; }
        public long MaxSizeInMegabytes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime AccessedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public long DeadLetterMessageCount { get; set; }
        public long ActiveMessageCount { get; set; }
        public long ScheduledMessageCount { get; set; }
        public long TransferDeadLetterMessageCount { get; set; }
        public long TransferMessageCount { get; set; }

        public bool EnablePartitioning { get; set; }
        public bool RequiresDuplicateDetection { get; set; }
        public bool EnableBatchedOperations { get; set; }
        public bool IsAnonymousAccessible { get; set; }
        public bool SupportOrdering { get; set; }
        public bool EnableExpress { get; set; }
        public string UserMetadata { get; set; }
        public string AvailabilityStatus { get; set; }
        public string DefaultMessageTimeToLive { get; set; }
        public string AutoDeleteOnIdle { get; set; }
        public string DuplicateDetectionHistoryTimeWindow { get; set; }
        public int SubscriptionCount { get; set; }
        public bool EnableFilteringMessagesBeforePublishing { get; set; }
    }
}
