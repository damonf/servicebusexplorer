import { Injectable, Inject } from '@angular/core';
import { APP_CONFIG, AppConfig } from './app.config';

import { ApiClientService } from './api-client.service';
import { IServiceBusUpdate } from './service-bus-update';
import { QueueDetail } from './queue-detail';

@Injectable()
export class ServiceBusQueryService {

  constructor(
    @Inject(APP_CONFIG) private config: AppConfig,
    private apiClientService: ApiClientService) { }

  getUpdate(): Promise<IServiceBusUpdate> {
    return this.apiClientService.get(this.config.apiEndpoint + 'ServiceBus')
               .toPromise()
               .then(response =>
                 response.json() as IServiceBusUpdate);
  }

  getName(): Promise<string> {
    return this.apiClientService.get(this.config.apiEndpoint + 'ServiceBus/Name')
               .toPromise()
               .then(response =>
                 response.json() as string);
  }

  getQueue(path: string): Promise<QueueDetail> {
    return this.apiClientService.get(`${this.config.apiEndpoint}Queue/${path}`)
               .toPromise()
               .then(response =>
                 response.json() as QueueDetail);
  }
}
