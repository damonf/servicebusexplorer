import { Injectable, Inject } from '@angular/core';
import { APP_CONFIG, AppConfig } from './app.config';

import { ApiClientService } from './api-client.service';

@Injectable()
export class ServiceBusCommandService {

  constructor(
    @Inject(APP_CONFIG) private config: AppConfig,
    private apiClientService: ApiClientService) { }

  enableAutoRefresh(): Promise<any> {
    return this.apiClientService.post(this.config.apiEndpoint + 'Hub/Start', {})
               .toPromise()
  }

  disableAutoRefresh(): Promise<any> {
    return this.apiClientService.post(this.config.apiEndpoint + 'Hub/Stop', {})
               .toPromise();
  }
}
