import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule }   from '@angular/router';

import { APP_CONFIG, APP_CONFIG_OBJECT } from './app.config';
import { AppComponent } from './app.component';
import { ApiClientService } from './api-client.service';
import { ServiceBusQueryService } from './service-bus-query.service';
import { ServiceBusDescriptionComponent } from './service-bus-description/service-bus-description.component';
import { QueueListComponent } from './queue-list/queue-list.component';
import { TopicListComponent } from './topic-list/topic-list.component';
import { WindowRefService } from './window-ref.service';
import { SignalrHubService } from './signalr-hub.service';
import { QueueDetailComponent } from './queue-detail/queue-detail.component';
import { TopicDetailComponent } from './topic-detail/topic-detail.component';
import { SubscriptionDetailComponent } from './subscription-detail/subscription-detail.component';
import { ServicebusTitleComponent } from './servicebus-title/servicebus-title.component';

@NgModule({
  declarations: [
    AppComponent,
    ServiceBusDescriptionComponent,
    QueueListComponent,
    TopicListComponent,
    QueueDetailComponent,
    TopicDetailComponent,
    SubscriptionDetailComponent,
    ServicebusTitleComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    NgbModule.forRoot(),
    RouterModule.forRoot([
      {
        path: 'queue-detail/:path',
        component: QueueDetailComponent
      },
      {
        path: 'subscription-detail/:topicPath/:path',
        component: SubscriptionDetailComponent
      },
      {
        path: 'topic-detail/:path',
        component: TopicDetailComponent
      }
    ])
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
