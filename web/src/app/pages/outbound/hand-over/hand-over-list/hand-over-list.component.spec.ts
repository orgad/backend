import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HandOverListComponent } from './hand-over-list.component';

describe('HandOverListComponent', () => {
  let component: HandOverListComponent;
  let fixture: ComponentFixture<HandOverListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HandOverListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HandOverListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
