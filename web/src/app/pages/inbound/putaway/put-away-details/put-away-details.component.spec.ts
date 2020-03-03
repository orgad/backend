import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PutAwayDetailsComponent } from './put-away-details.component';

describe('PutAwayDetailsComponent', () => {
  let component: PutAwayDetailsComponent;
  let fixture: ComponentFixture<PutAwayDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PutAwayDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PutAwayDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
