import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgZorroAntdMobileModule } from 'ng-zorro-antd-mobile';

import { InboundNavListRoutingModule } from './inbound-nav-list-routing.module';
import { InboundNavListComponent } from './inbound-nav-list.component';
import { InboundListComponent } from '../inbound-list/inbound-list.component';
import { RcvListComponent } from '../rcv-list/rcv-list.component';
import { RcvScanComponent } from '../rcv-scan/rcv-scan.component';
import { QcScanComponent } from '../qc-scan/qc-scan.component';
import { PutAwayScanComponent } from '../put-away-scan/put-away-scan.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CheckTakePhotoComponent } from '../check-take-photo/check-take-photo.component';
import { CheckListComponent } from '../check-list/check-list.component';
import { CheckUpdateComponent } from '../check-update/check-update.component';

@NgModule({
  imports: [
    InboundNavListRoutingModule,
    CommonModule,
    NgZorroAntdMobileModule,
    ReactiveFormsModule
  ],
  declarations: [
    InboundNavListComponent,
    InboundListComponent,
    RcvListComponent,
    RcvScanComponent,
    QcScanComponent,
    PutAwayScanComponent,
    CheckListComponent,
    CheckUpdateComponent,
    CheckTakePhotoComponent
  ],
  exports: [InboundNavListComponent]
})
export class InboundNavListModule { }