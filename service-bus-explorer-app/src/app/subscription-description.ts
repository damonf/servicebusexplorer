import { ISubscriptionUpdate } from './service-bus-update';

export class SubscriptionDescription {
  name: string;
  activeMessageCount: number;
  deadLetterMessageCount: number;

  constructor(subscriptionUpdate: ISubscriptionUpdate) {
    this.name = subscriptionUpdate.name;
    this.update(subscriptionUpdate);
  }

  update(subscriptionUpdate: ISubscriptionUpdate) {
    this.activeMessageCount = subscriptionUpdate.activeMessageCount;
    this.deadLetterMessageCount = subscriptionUpdate.deadLetterMessageCount;
  }
}
