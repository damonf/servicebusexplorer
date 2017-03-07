export class SubscriptionDetail {
  status: string;
  isReadonly: boolean;
  createdAt: Date;
  accessedAt: Date;
  updatedAt: Date;
  messageCount: number;
  activeMessageCount: number;
  deadLetterMessageCount: number;
  scheduledMessageCount: number;
  transferMessageCount: number;
  transferDeadLetterMessageCount: number;
  enablePartitioning : boolean;
  enableDeadLetteringOnMessageExpiration: boolean;
  enableDeadLetteringOnFilterEvaluationExceptions: boolean;
  requiresSession: boolean;
  enableBatchedOperations: boolean;
  maxDeliveryCount: number;
  userMetadata: string;
  forwardTo: string;
  forwardDeadLetteredMessagesTo: string;
  availabilityStatus: string;
  lockDuration: string;
  defaultMessageTimeToLive: string;
  autoDeleteOnIdle: string;
}
