import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QcListComponent } from './qc-list.component';

describe('QcListComponent', () => {
  let component: QcListComponent;
  let fixture: ComponentFixture<QcListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QcListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QcListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
