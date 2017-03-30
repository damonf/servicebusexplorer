export class TopicDetail {
  status: string;
  isReadonly: boolean;
  sizeInBytes: number;
  maxSizeInMegabytes: number;
  createdAt: Date;
  accessedAt: Date;
  updatedAt: Date;
  deadLetterMessageCount: number;
  scheduledMessageCount: number;
  transferMessageCount: number;
  transferDeadLetterMessageCount: number;
  enablePartitioning : boolean;
  requiresDuplicateDetection: boolean;
  enableBatchedOperations: boolean;
  isAnonymousAccessible: boolean;
  supportOrdering: boolean;
  enableExpress: boolean;
  userMetadata: string;
  availabilityStatus: string;
  defaultMessageTimeToLive: string;
  autoDeleteOnIdle: string;
  duplicateDetectionHistoryTimeWindow: string;
  subscriptionCount: number;
  enableFilteringMessagesBeforePublishing: boolean;
}
