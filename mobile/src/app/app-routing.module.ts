import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NavListComponent } from './nav-list/nav-list.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/nav' },
  { path: 'nav', component: NavListComponent },
  { path: 'example', loadChildren: () => import('./examples/example.module').then(m => m.ExampleModule) },
  { path: 'inbound', loadChildren: () => import('./inbound/inbound-nav-list/inbound-nav-list.module').then(m => m.InboundNavListModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
