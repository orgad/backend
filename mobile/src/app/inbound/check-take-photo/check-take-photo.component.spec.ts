import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CheckTakePhotoComponent } from './check-take-photo.component';

describe('CheckTakePhotoComponent', () => {
  let component: CheckTakePhotoComponent;
  let fixture: ComponentFixture<CheckTakePhotoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CheckTakePhotoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CheckTakePhotoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
