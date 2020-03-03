import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PickDetailsComponent } from './pick-details.component';

describe('PickDetailsComponent', () => {
  let component: PickDetailsComponent;
  let fixture: ComponentFixture<PickDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PickDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PickDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
