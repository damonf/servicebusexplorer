export class QueueDetail {
  status: string;
  isReadonly: boolean;
  sizeInBytes: number;
  createdAt: Date;
  accessedAt: Date;
  updatedAt: Date;
  messageCount: number;
  activeMessageCount: number;
  deadLetterMessageCount: number;
  scheduledMessageCount: number;
  transferMessageCount: number;
  transferDeadLetterMessageCount: number;
}
