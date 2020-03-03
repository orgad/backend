import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AsnDetailsComponent } from './asn-details.component';

describe('AsnDetailsComponent', () => {
  let component: AsnDetailsComponent;
  let fixture: ComponentFixture<AsnDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AsnDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AsnDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
