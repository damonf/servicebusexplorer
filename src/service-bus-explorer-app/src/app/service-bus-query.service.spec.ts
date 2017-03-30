/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ServiceBusQueryService } from './service-bus-query.service';

describe('ServiceBusQueryService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ServiceBusQueryService]
    });
  });

  it('should ...', inject([ServiceBusQueryService], (service: ServiceBusQueryService) => {
    expect(service).toBeTruthy();
  }));
});
