import { fakeAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { AsnComponent } from './asn.component';

describe('AsnComponent', () => {
  let component: AsnComponent;
  let fixture: ComponentFixture<AsnComponent>;

  beforeEach(fakeAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ AsnComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AsnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should compile', () => {
    expect(component).toBeTruthy();
  });
});
