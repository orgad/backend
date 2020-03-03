import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WaveDetailsComponent } from './wave-details.component';

describe('WaveDetailsComponent', () => {
  let component: WaveDetailsComponent;
  let fixture: ComponentFixture<WaveDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WaveDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WaveDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
