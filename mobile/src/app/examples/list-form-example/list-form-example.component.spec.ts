import { fakeAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { ListFormExampleComponent } from './list-form-example.component';

describe('ListFormExampleComponent', () => {
  let component: ListFormExampleComponent;
  let fixture: ComponentFixture<ListFormExampleComponent>;

  beforeEach(fakeAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ ListFormExampleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListFormExampleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should compile', () => {
    expect(component).toBeTruthy();
  });
});
