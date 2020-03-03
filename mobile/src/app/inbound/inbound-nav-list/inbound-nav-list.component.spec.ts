import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InboundNavListComponent } from './inbound-nav-list.component';

describe('InboundNavListComponent', () => {
  let component: InboundNavListComponent;
  let fixture: ComponentFixture<InboundNavListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InboundNavListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InboundNavListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
