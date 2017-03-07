import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { ServiceBusQueryService } from '../service-bus-query.service';
import { TopicDetail } from '../topic-detail';

@Component({
  selector: 'app-topic-detail',
  templateUrl: './topic-detail.component.html',
  styleUrls: ['./topic-detail.component.css']
})
export class TopicDetailComponent implements OnInit {

  path: string;
  topicDetail: TopicDetail = new TopicDetail();

  constructor(
    private route: ActivatedRoute,
    private serviceBusQueryService: ServiceBusQueryService) { }

  ngOnInit() {
    this.route.params
      .subscribe((params: Params) => {
        this.path = params['path']
        this.refresh();
      });
  }

  refresh() {
    this.serviceBusQueryService.getTopic(this.path)
      .then(topicDetail => {
        this.topicDetail = topicDetail;
      })
  }

}
