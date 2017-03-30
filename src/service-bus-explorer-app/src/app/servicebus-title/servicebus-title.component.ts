import { Component, OnInit } from '@angular/core';

import { ServiceBusQueryService } from '../service-bus-query.service';

@Component({
  selector: 'app-servicebus-title',
  templateUrl: './servicebus-title.component.html',
  styleUrls: ['./servicebus-title.component.css']
})
export class ServicebusTitleComponent implements OnInit {

  title: string;

  constructor(private serviceBusQueryService: ServiceBusQueryService) { }

  ngOnInit() {
    this.serviceBusQueryService.getName()
      .then(name => {
        this.title = name;
      });
  }

}
