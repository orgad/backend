import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AsnDetailImportComponent } from './asn-detail-import.component';

describe('AsnDetailImportComponent', () => {
  let component: AsnDetailImportComponent;
  let fixture: ComponentFixture<AsnDetailImportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AsnDetailImportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AsnDetailImportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
