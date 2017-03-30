import { IQueueUpdate } from './service-bus-update';

export class QueueDescription {
  name: string;
  activeMessageCount: number;
  deadLetterMessageCount: number;

  constructor(queueUpdate: IQueueUpdate) {
    this.name = queueUpdate.name;
    this.update(queueUpdate);
  }

  update(queueUpdate: IQueueUpdate) {
    this.activeMessageCount = queueUpdate.activeMessageCount;
    this.deadLetterMessageCount = queueUpdate.deadLetterMessageCount;
  }
}
