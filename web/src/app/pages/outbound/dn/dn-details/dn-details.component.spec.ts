import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DnDetailsComponent } from './dn-details.component';

describe('DnDetailsComponent', () => {
  let component: DnDetailsComponent;
  let fixture: ComponentFixture<DnDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DnDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DnDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
