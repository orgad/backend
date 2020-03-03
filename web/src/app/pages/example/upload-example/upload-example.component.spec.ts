import { fakeAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { UploadExampleComponent } from './upload-example.component';

describe('UploadExampleComponent', () => {
  let component: UploadExampleComponent;
  let fixture: ComponentFixture<UploadExampleComponent>;

  beforeEach(fakeAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ UploadExampleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UploadExampleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should compile', () => {
    expect(component).toBeTruthy();
  });
});
