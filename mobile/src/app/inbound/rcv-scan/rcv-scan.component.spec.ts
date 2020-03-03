import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RcvScanComponent } from './rcv-scan.component';

describe('RcvScanComponent', () => {
  let component: RcvScanComponent;
  let fixture: ComponentFixture<RcvScanComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RcvScanComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RcvScanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
