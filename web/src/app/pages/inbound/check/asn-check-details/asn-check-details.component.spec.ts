import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AsnCheckDetailsComponent } from './asn-check-details.component';

describe('AsnCheckDetailsComponent', () => {
  let component: AsnCheckDetailsComponent;
  let fixture: ComponentFixture<AsnCheckDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AsnCheckDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AsnCheckDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
