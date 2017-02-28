import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params }   from '@angular/router';

@Component({
  selector: 'app-subscription-detail',
  templateUrl: './subscription-detail.component.html',
  styleUrls: ['./subscription-detail.component.css']
})
export class SubscriptionDetailComponent implements OnInit {

  topicPath: string;
  path: string;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params
      .subscribe((params: Params) => {
        this.topicPath = params['topicPath'];
        this.path = params['path'];
      });
  }

}
