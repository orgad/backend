import { fakeAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { EditformComponent } from './editform.component';

describe('EditformComponent', () => {
  let component: EditformComponent;
  let fixture: ComponentFixture<EditformComponent>;

  beforeEach(fakeAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ EditformComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should compile', () => {
    expect(component).toBeTruthy();
  });
});
