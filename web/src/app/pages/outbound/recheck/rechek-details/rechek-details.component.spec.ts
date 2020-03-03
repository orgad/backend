import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RechekDetailsComponent } from './rechek-details.component';

describe('RechekDetailsComponent', () => {
  let component: RechekDetailsComponent;
  let fixture: ComponentFixture<RechekDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RechekDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RechekDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
