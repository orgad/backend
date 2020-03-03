import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RechekListComponent } from './rechek-list.component';

describe('RechekListComponent', () => {
  let component: RechekListComponent;
  let fixture: ComponentFixture<RechekListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RechekListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RechekListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
