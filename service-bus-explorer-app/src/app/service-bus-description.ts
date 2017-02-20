import { TopicDescription } from './topic-description';
import { QueueDescription } from './queue-description';
import * as _ from "lodash";

import { IServiceBusUpdate, IQueueUpdate, ITopicUpdate } from './service-bus-update';

export class ServiceBusDescription {
  queues: QueueDescription[] = [];
  topics: TopicDescription[] = [];
  queuesOpen: boolean = false;
  topicsOpen: boolean = false;

  constructor(serviceBusUpdate: IServiceBusUpdate = null) {
    if (serviceBusUpdate) {
      this.update(serviceBusUpdate);
    }
  }

  update(serviceBusUpdate: IServiceBusUpdate) {
    this.updateQueues(this.queues, serviceBusUpdate.queues);
    this.updateTopics(this.topics, serviceBusUpdate.topics);
  }

  updateQueues(queues: QueueDescription[], queueUpdate: IQueueUpdate[]) {
    // remove gone queues
    _.remove(queues, queue => !_.some(queueUpdate, ['name', queue.name] ));

    // update existing queues
    _.forEach(queues, queue => {
      const found = _.find(queueUpdate, ['name', queue.name]);

      if (found) {
        queue.update(found);
      }
    });

    // add new queues
    const newQueues =  _.map(_.differenceBy(queueUpdate, queues, 'name'), q => new QueueDescription(q));
    queues.push(...newQueues);
  }

  updateTopics(topics: TopicDescription[], topicUpdate: ITopicUpdate[]) {
    // remove gone topics
    _.remove(topics, topic => !_.some(topicUpdate, ['name', topic.name] ));

    // update existing topics
    _.forEach(topics, topic => {
      const found = _.find(topicUpdate, ['name', topic.name]);

      if (found) {
        topic.update(found);
      }
    });

    // add new topics
    const newTopics = _.map(_.differenceBy(topicUpdate, topics, 'name'), t => new TopicDescription(t));
    topics.push(...newTopics);
  }
}
