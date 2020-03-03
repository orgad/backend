import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QcScanComponent } from './qc-scan.component';

describe('QcScanComponent', () => {
  let component: QcScanComponent;
  let fixture: ComponentFixture<QcScanComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QcScanComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QcScanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
