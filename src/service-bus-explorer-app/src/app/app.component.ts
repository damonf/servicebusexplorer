import { Component, OnInit } from '@angular/core';

import { SignalrHubService } from './signalr-hub.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit {

  constructor(
    private signalrHubService: SignalrHubService) {
  }

  ngOnInit(): void {
    this.signalrHubService.start();
  }

}
