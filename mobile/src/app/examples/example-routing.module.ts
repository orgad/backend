import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { ExampleComponent } from './example.component';
import { TabBarExampleComponent } from './tab-bar-example/tab-bar-example.component';
import { ListFormExampleComponent } from './list-form-example/list-form-example.component';

const routes: Routes = [
  { path: "", component: ExampleComponent },
  { path: "example/tabbar", component: TabBarExampleComponent },
  { path: "example/listform", component:ListFormExampleComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExampleRoutingModule { }
