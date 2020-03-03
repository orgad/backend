import { Routes, RouterModule } from '@angular/router';

import { NgModule } from '@angular/core';
import { InboundNavListComponent } from './inbound-nav-list.component';
import { InboundListComponent } from '../inbound-list/inbound-list.component';
import { RcvScanComponent } from '../rcv-scan/rcv-scan.component';
import { QcScanComponent } from '../qc-scan/qc-scan.component';
import { PutAwayScanComponent } from '../put-away-scan/put-away-scan.component';
import { CheckTakePhotoComponent } from '../check-take-photo/check-take-photo.component';
import { CheckListComponent } from '../check-list/check-list.component';
import { CheckUpdateComponent } from '../check-update/check-update.component';
import { RcvListComponent } from '../rcv-list/rcv-list.component';

const routes: Routes = [
  { path: "", component: InboundNavListComponent },
  { path: "inbound/check-list", component: CheckListComponent },
  { path: "inbound/check-update/:id", component: CheckUpdateComponent },
  { path: 'inbound/take-photo/:id', component: CheckTakePhotoComponent },
  { path: 'inbound/list', component: InboundListComponent },
  { path: 'inbound/rcv-list', component: RcvListComponent },
  { path: 'inbound/rcv-scan/:id', component: RcvScanComponent },
  { path: 'inbound/qc-scan', component: QcScanComponent },
  { path: 'inbound/put-away-scan', component: PutAwayScanComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class InboundNavListRoutingModule { }
