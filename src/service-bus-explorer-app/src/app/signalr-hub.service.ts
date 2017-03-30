import { Injectable, Inject } from '@angular/core';
import { APP_CONFIG, AppConfig } from './app.config';
import {Subject} from "rxjs/Subject";
import { Observable } from "rxjs/Observable";

import { WindowRefService } from './window-ref.service'
import { IServiceBusUpdate } from './service-bus-update';

@Injectable()
export class SignalrHubService {
  // private _window: Window;
  private _window: any;
  private hubProxy: SignalR.Hub.Proxy;
  private hubConnection: SignalR.Hub.Connection;

  private serviceBusUpdateSubject: Subject<IServiceBusUpdate>;

  constructor(
    @Inject(APP_CONFIG) private config: AppConfig,
    windowRef: WindowRefService
    ) {

    this._window = windowRef.nativeWindow;

    if (this._window.$ === undefined || this._window.$.hubConnection === undefined) {
        throw new Error("SignalR does not appear to be loaded");
    }

    this.hubConnection = this._window.$.hubConnection();
    this.hubConnection.url = config.signalRHubUrl;
    this.hubProxy = this.hubConnection.createHubProxy(config.signalRHubName);

    this.hubConnection.stateChanged((change: SignalR.StateChanged) => {
      console.log(change.newState);
    });

    this.hubProxy.on("serviceBusUpdate", (message: IServiceBusUpdate) => {
      if (!this.serviceBusUpdateSubject) { return; }

      this.serviceBusUpdateSubject.next(message);
    });
  }

  start() : void {
    this.hubConnection.start()
      .done(() => {
        console.log('hub started')
      })
      .fail((error: any) => {
        console.log('hub error starting:' + error)
      });
  }

  serviceBusUpdate(): Observable<IServiceBusUpdate> {
    if (!this.serviceBusUpdateSubject) {
      this.serviceBusUpdateSubject = new Subject<IServiceBusUpdate>();
    }

    return this.serviceBusUpdateSubject.asObservable();
  }

}
