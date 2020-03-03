import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DnListComponent } from './dn-list.component';

describe('DnListComponent', () => {
  let component: DnListComponent;
  let fixture: ComponentFixture<DnListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DnListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DnListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
