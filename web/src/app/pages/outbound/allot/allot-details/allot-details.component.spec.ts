import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AllotDetailsComponent } from './allot-details.component';

describe('AllotDetailsComponent', () => {
  let component: AllotDetailsComponent;
  let fixture: ComponentFixture<AllotDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AllotDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AllotDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
