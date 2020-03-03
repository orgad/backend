import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SearchFormComponent } from './pages/example/search-form/search-form.component';
import { EditformComponent } from './pages/example/editform/editform.component';
import { AsnComponent } from './pages/inbound/asn/asn-list/asn.component';
import { AsnDetailsComponent } from './pages/inbound/asn/asn-details/asn-details.component';
import { SelectFormComponent } from './pages/example/select-form/select-form.component';
import { AsnCheckListComponent } from './pages/inbound/check/asn-check-list/asn-check-list.component';
import { AsnCheckDetailsComponent } from './pages/inbound/check/asn-check-details/asn-check-details.component';
import { InboundListComponent } from './pages/inbound/inbound/inbound-list/inbound-list.component';
import { InboundDetailsComponent } from './pages/inbound/inbound/inbound-details/inbound-details.component';
import { QcListComponent } from './pages/inbound/qc/qc-list/qc-list.component';
import { QcDetailsComponent } from './pages/inbound/qc/qc-details/qc-details.component';
import { PutAwayListComponent } from './pages/inbound/putaway/put-away-list/put-away-list.component';
import { PutAwayDetailsComponent } from './pages/inbound/putaway/put-away-details/put-away-details.component';
import { RcvListComponent } from './pages/inbound/rcv/rcv-list/rcv-list.component';
import { InventoryListComponent } from './pages/inventory/inventory-list/inventory-list.component';
import { InventoryDetailsComponent } from './pages/inventory/inventory-details/inventory-details.component';
import { DnListComponent } from './pages/outbound/dn/dn-list/dn-list.component';
import { DnDetailsComponent } from './pages/outbound/dn/dn-details/dn-details.component';
import { OutboundListComponent } from './pages/outbound/outbound/outbound-list/outbound-list.component';
import { OutboundDetailsComponent } from './pages/outbound/outbound/outbound-details/outbound-details.component';
import { AllotListComponent } from './pages/outbound/allot/allot-list/allot-list.component';
import { AllotDetailsComponent } from './pages/outbound/allot/allot-details/allot-details.component';
import { RechekListComponent } from './pages/outbound/recheck/rechek-list/rechek-list.component';
import { RechekDetailsComponent } from './pages/outbound/recheck/rechek-details/rechek-details.component';
import { HandOverListComponent } from './pages/outbound/hand-over/hand-over-list/hand-over-list.component';
import { HandOverDetailsComponent } from './pages/outbound/hand-over/hand-over-details/hand-over-details.component';
import { PickListComponent } from './pages/outbound/pick/pick-list/pick-list.component';
import { PickDetailsComponent } from './pages/outbound/pick/pick-details/pick-details.component';
import { WaveListComponent } from './pages/outbound/wave/wave-list/wave-list.component';
import { WaveDetailsComponent } from './pages/outbound/wave/wave-details/wave-details.component';
import { DetailsExampleComponent } from './pages/example/details-example/details-example.component';
import { ListExampleComponent } from './pages/example/list-example/list-example.component';
import { UploadExampleComponent } from './pages/example/upload-example/upload-example.component';
import { AsnDetailImportComponent } from './pages/inbound/asn/asn-detail-import/asn-detail-import.component';
import { PrintComponent } from './pages/example/print/print.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/welcome' },
  { path: 'welcome', loadChildren: () => import('./pages/welcome/welcome.module').then(m => m.WelcomeModule) },
  { path: 'searchform', component: SearchFormComponent },
  { path: 'editform', component: EditformComponent },
  { path: 'list', component: ListExampleComponent },
  { path: 'details/:id', component: DetailsExampleComponent },
  { path: 'selectform', component: SelectFormComponent },
  { path: 'uploadform', component: UploadExampleComponent },
  { path: 'print', component: PrintComponent },
  { path: 'in/asn', component: AsnComponent },
  { path: 'in/asn/asnDetails/:id', component: AsnDetailsComponent },
  { path: 'in/asn/asnDetails/importdetail/:id', component: AsnDetailImportComponent },
  { path: 'in/asnCheck', component: AsnCheckListComponent },
  { path: 'in/asnCheckDetails/:id', component: AsnCheckDetailsComponent },
  { path: 'in/inbound', component: InboundListComponent },
  { path: 'in/inboundDetails/:id', component: InboundDetailsComponent },
  { path: 'in/rcv', component: RcvListComponent },
  { path: 'in/qc', component: QcListComponent },
  { path: 'in/qcDetails/:id', component: QcDetailsComponent },
  { path: 'in/putAway', component: PutAwayListComponent },
  { path: 'in/putAwayDetails/:id', component: PutAwayDetailsComponent },
  { path: 'invt', component: InventoryListComponent },
  { path: 'invtDetails/:id', component: InventoryDetailsComponent },
  { path: 'dn', component: DnListComponent },
  { path: 'dnDetails/:id', component: DnDetailsComponent },
  { path: 'outbound', component: OutboundListComponent },
  { path: 'outboundDetails/:id', component: OutboundDetailsComponent },
  { path: 'allot', component: AllotListComponent },
  { path: 'allotDetails/:id', component: AllotDetailsComponent },
  { path: 'wave', component: WaveListComponent },
  { path: 'waveDetails/:id', component: WaveDetailsComponent },
  { path: 'picking', component: PickListComponent },
  { path: 'pickingDetails/:id', component: PickDetailsComponent },
  { path: 'recheck', component: RechekListComponent },
  { path: 'recheckDetails/:id', component: RechekDetailsComponent },
  { path: 'handOver', component: HandOverListComponent },
  { path: 'handOverDetails/:id', component: HandOverDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
