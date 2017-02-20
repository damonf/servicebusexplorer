/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { SignalrHubService } from './signalr-hub.service';

describe('SignalrHubService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SignalrHubService]
    });
  });

  it('should ...', inject([SignalrHubService], (service: SignalrHubService) => {
    expect(service).toBeTruthy();
  }));
});
