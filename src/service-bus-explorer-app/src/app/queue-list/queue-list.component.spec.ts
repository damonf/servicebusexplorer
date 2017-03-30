/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { QueueListComponent } from './queue-list.component';

describe('QueueListComponent', () => {
  let component: QueueListComponent;
  let fixture: ComponentFixture<QueueListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QueueListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QueueListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
