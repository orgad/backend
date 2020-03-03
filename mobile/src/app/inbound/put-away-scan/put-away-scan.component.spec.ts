import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PutAwayScanComponent } from './put-away-scan.component';

describe('PutAwayScanComponent', () => {
  let component: PutAwayScanComponent;
  let fixture: ComponentFixture<PutAwayScanComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PutAwayScanComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PutAwayScanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
