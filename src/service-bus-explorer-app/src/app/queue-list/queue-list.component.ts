import { Component, OnInit, Input } from '@angular/core';

import { QueueDescription } from '../queue-description';

@Component({
  selector: 'app-queue-list',
  templateUrl: './queue-list.component.html',
  styleUrls: ['./queue-list.component.css']
})
export class QueueListComponent implements OnInit {

  @Input()
  queues: QueueDescription[];

  constructor() { }

  ngOnInit() {
  }

}
