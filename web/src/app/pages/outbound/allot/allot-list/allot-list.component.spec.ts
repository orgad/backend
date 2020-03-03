import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AllotListComponent } from './allot-list.component';

describe('AllotListComponent', () => {
  let component: AllotListComponent;
  let fixture: ComponentFixture<AllotListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AllotListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AllotListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
