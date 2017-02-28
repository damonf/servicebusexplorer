import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { ServiceBusQueryService } from '../service-bus-query.service';
import { QueueDetail } from '../queue-detail';

@Component({
  selector: 'app-queue-detail',
  templateUrl: './queue-detail.component.html',
  styleUrls: ['./queue-detail.component.css']
})
export class QueueDetailComponent implements OnInit {

  path: string;
  queueDetail: QueueDetail = new QueueDetail();

  constructor(
    private route: ActivatedRoute,
    private serviceBusQueryService: ServiceBusQueryService) { }

  ngOnInit() {
    this.route.params
      .subscribe((params: Params) => {
        this.path = params['path'];

        this.serviceBusQueryService.getQueue(this.path)
          .then(queueDetail => {
            this.queueDetail = queueDetail;
          })
      });
  }

}
