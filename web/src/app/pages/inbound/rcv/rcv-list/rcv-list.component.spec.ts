import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RcvListComponent } from './rcv-list.component';

describe('RcvListComponent', () => {
  let component: RcvListComponent;
  let fixture: ComponentFixture<RcvListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RcvListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RcvListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
