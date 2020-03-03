import { fakeAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { TabBarExampleComponent } from './tab-bar-example.component';

describe('TabBarExampleComponent', () => {
  let component: TabBarExampleComponent;
  let fixture: ComponentFixture<TabBarExampleComponent>;

  beforeEach(fakeAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ TabBarExampleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TabBarExampleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should compile', () => {
    expect(component).toBeTruthy();
  });
});
