import { Component, OnInit, Input } from '@angular/core';

import { TopicDescription } from '../topic-description';

@Component({
  selector: 'app-topic-list',
  templateUrl: './topic-list.component.html',
  styleUrls: ['./topic-list.component.css']
})
export class TopicListComponent implements OnInit {

  @Input()
  topics: TopicDescription[];

  constructor() { }

  ngOnInit() {
  }

}
