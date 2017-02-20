import { NgZone, Component, OnInit } from '@angular/core';
import 'rxjs/add/operator/toPromise';

import { ServiceBusQueryService } from '../service-bus-query.service';
import { IServiceBusUpdate } from '../service-bus-update';
import { ServiceBusDescription } from '../service-bus-description';
import { TopicDescription } from '../topic-description';
import { SignalrHubService } from '../signalr-hub.service';

@Component({
  selector: 'app-service-bus-description',
  templateUrl: './service-bus-description.component.html',
  styleUrls: ['./service-bus-description.component.css']
})
export class ServiceBusDescriptionComponent implements OnInit {

  serviceBusDescription: ServiceBusDescription = new ServiceBusDescription();

  constructor(
    private ngZone: NgZone,
    private serviceBusQueryService: ServiceBusQueryService,
    private signalrHubService: SignalrHubService) {
  }

  ngOnInit(): void {

    this.serviceBusQueryService.getUpdate()
      .then(update => {
        this.serviceBusDescription.update(update);
        this.serviceBusDescription.queuesOpen = true;
        this.serviceBusDescription.topicsOpen = true;
      })
      .catch(this.handleError);

    this.signalrHubService.serviceBusUpdate().subscribe(
      (update: IServiceBusUpdate) => {
        console.log(update);
        this.ngZone.run(() => {
          this.serviceBusDescription.update(update);
        });
      },
      (err: any) => {
        console.log(err);
      }
    )
  }

  private handleError(error: any): void {
    // TODO: show error in UI
    console.error('An error occurred', error);
  }

}
