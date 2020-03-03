import { NgModule } from '@angular/core';
import { ExampleComponent } from './example.component';
import { ExampleRoutingModule } from './example-routing.module';
import { CommonModule } from '@angular/common';
import { TabBarExampleComponent } from './tab-bar-example/tab-bar-example.component';
import { NgZorroAntdMobileModule } from 'ng-zorro-antd-mobile';
import { ListFormExampleComponent } from './list-form-example/list-form-example.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    ExampleRoutingModule,
    CommonModule,
    NgZorroAntdMobileModule,
    ReactiveFormsModule
  ],
  declarations: [
    ExampleComponent,
    TabBarExampleComponent,
    ListFormExampleComponent
  ],
  exports:[ExampleComponent]
})
export class ExampleModule { }
