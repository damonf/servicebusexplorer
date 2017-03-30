/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ServiceBusCommandService } from './service-bus-command.service';

describe('ServiceBusCommandService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ServiceBusCommandService]
    });
  });

  it('should ...', inject([ServiceBusCommandService], (service: ServiceBusCommandService) => {
    expect(service).toBeTruthy();
  }));
});
