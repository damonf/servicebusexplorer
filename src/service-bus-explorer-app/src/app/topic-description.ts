import { SubscriptionDescription } from './subscription-description';
import * as _ from "lodash";

import { ITopicUpdate } from './service-bus-update';

export class TopicDescription {
  name: string;
  activeMessageCount: number;
  deadLetterMessageCount: number;
  subscriptions: SubscriptionDescription[] = [];
  open: boolean;
  subscriptionsOpen: boolean;

  constructor(topicUpdate: ITopicUpdate) {
    this.name = topicUpdate.name;
    this.update(topicUpdate);
  }

  update(topicUpdate: ITopicUpdate) {
    this.activeMessageCount = topicUpdate.activeMessageCount;
    this.deadLetterMessageCount = topicUpdate.deadLetterMessageCount;

    // remove gone subscriptions
    _.remove(this.subscriptions, subscription => !_.some(topicUpdate.subscriptions, ['name', subscription.name] ));

    // update existing subscriptions
    _.forEach(this.subscriptions, subscription => {
      const found = _.find(topicUpdate.subscriptions, ['name', subscription.name]);

      if (found) {
        subscription.update(found);
      }
    });

    // add new subscriptions
    const newSubscriptions =  _.map(_.differenceBy(topicUpdate.subscriptions, this.subscriptions, 'name'), x => new SubscriptionDescription(x));
    this.subscriptions.push(...newSubscriptions);
  }
}
