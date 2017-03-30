export interface IQueueUpdate {
  name: string;
  activeMessageCount: number;
  deadLetterMessageCount: number;
}

export interface ISubscriptionUpdate {
  name: string;
  activeMessageCount: number;
  deadLetterMessageCount: number;
}

export interface ITopicUpdate {
  name: string;
  activeMessageCount: number;
  deadLetterMessageCount: number;
  subscriptions: ISubscriptionUpdate[];
}

export interface IServiceBusUpdate {
  queues: IQueueUpdate[];
  topics: ITopicUpdate[];
}
