import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AsnCheckListComponent } from './asn-check-list.component';

describe('AsnCheckListComponent', () => {
  let component: AsnCheckListComponent;
  let fixture: ComponentFixture<AsnCheckListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AsnCheckListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AsnCheckListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
