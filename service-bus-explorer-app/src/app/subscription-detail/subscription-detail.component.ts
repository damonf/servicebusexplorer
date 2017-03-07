import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params }   from '@angular/router';

import { ServiceBusQueryService } from '../service-bus-query.service';
import { SubscriptionDetail } from '../subscription-detail';

@Component({
  selector: 'app-subscription-detail',
  templateUrl: './subscription-detail.component.html',
  styleUrls: ['./subscription-detail.component.css']
})
export class SubscriptionDetailComponent implements OnInit {

  topicPath: string;
  path: string;
  subscriptionDetail: SubscriptionDetail = new SubscriptionDetail();

  constructor(
    private route: ActivatedRoute,
    private serviceBusQueryService: ServiceBusQueryService) { }

  ngOnInit() {
    this.route.params
      .subscribe((params: Params) => {
        this.topicPath = params['topicPath'];
        this.path = params['path'];
        this.refresh();
      });
  }

  refresh(): void {
    this.serviceBusQueryService.getSubscription(this.topicPath, this.path)
      .then(subscriptionDetail => {
        this.subscriptionDetail = subscriptionDetail;
      })
  }

}
