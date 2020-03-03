import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsExampleComponent } from './details-example.component';

describe('DetailsExampleComponent', () => {
  let component: DetailsExampleComponent;
  let fixture: ComponentFixture<DetailsExampleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailsExampleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailsExampleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
