import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InboundListComponent } from './inbound-list.component';

describe('InboundListComponent', () => {
  let component: InboundListComponent;
  let fixture: ComponentFixture<InboundListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InboundListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InboundListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
