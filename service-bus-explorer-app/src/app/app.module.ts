import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { APP_CONFIG, APP_CONFIG_OBJECT } from './app.config';
import { AppComponent } from './app.component';
import { ApiClientService } from './api-client.service';
import { ServiceBusQueryService } from './service-bus-query.service';
import { ServiceBusDescriptionComponent } from './service-bus-description/service-bus-description.component';
import { QueueListComponent } from './queue-list/queue-list.component';
import { TopicListComponent } from './topic-list/topic-list.component';
import { WindowRefService } from './window-ref.service';
import { SignalrHubService } from './signalr-hub.service';

@NgModule({
  declarations: [
    AppComponent,
    ServiceBusDescriptionComponent,
    QueueListComponent,
    TopicListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    NgbModule.forRoot()
  ],
  providers: [
    { provide: APP_CONFIG, useValue: APP_CONFIG_OBJECT },
    ServiceBusQueryService,
    ApiClientService,
    WindowRefService,
    SignalrHubService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
