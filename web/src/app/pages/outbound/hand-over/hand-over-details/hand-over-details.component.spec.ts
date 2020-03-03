import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HandOverDetailsComponent } from './hand-over-details.component';

describe('HandOverDetailsComponent', () => {
  let component: HandOverDetailsComponent;
  let fixture: ComponentFixture<HandOverDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HandOverDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HandOverDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
