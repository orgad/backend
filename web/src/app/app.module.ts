import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IconsProviderModule } from './icons-provider.module';
import { NgZorroAntdModule, NZ_I18N, zh_CN, en_US } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { registerLocaleData, LocationStrategy, HashLocationStrategy } from '@angular/common';

import zh from '@angular/common/locales/zh';
import { SearchFormComponent } from './pages/example/search-form/search-form.component';
import { EditformComponent } from './pages/example/editform/editform.component';
import { SelectFormComponent } from './pages/example/select-form/select-form.component';

import { AsnComponent } from './pages/inbound/asn/asn-list/asn.component';
import { AsnDetailsComponent } from './pages/inbound/asn/asn-details/asn-details.component';
import { InboundListComponent } from './pages/inbound/inbound/inbound-list/inbound-list.component';
import { InboundDetailsComponent } from './pages/inbound/inbound/inbound-details/inbound-details.component';
import { MessagesComponent } from './pages/messages/messages.component';
import { AsnCheckListComponent } from './pages/inbound/check/asn-check-list/asn-check-list.component';
import { AsnCheckDetailsComponent } from './pages/inbound/check/asn-check-details/asn-check-details.component';
import { QcListComponent } from './pages/inbound/qc/qc-list/qc-list.component';
import { QcDetailsComponent } from './pages/inbound/qc/qc-details/qc-details.component';
import { PutAwayListComponent } from './pages/inbound/putaway/put-away-list/put-away-list.component';
import { PutAwayDetailsComponent } from './pages/inbound/putaway/put-away-details/put-away-details.component';
import { RcvListComponent } from './pages/inbound/rcv/rcv-list/rcv-list.component';
import { InventoryListComponent } from './pages/inventory/inventory-list/inventory-list.component';
import { InventoryDetailsComponent } from './pages/inventory/inventory-details/inventory-details.component';
import { DnListComponent } from './pages/outbound/dn/dn-list/dn-list.component';
import { OutboundListComponent } from './pages/outbound/outbound/outbound-list/outbound-list.component';
import { DnDetailsComponent } from './pages/outbound/dn/dn-details/dn-details.component';
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
import { ListExampleComponent } from './pages/example/list-example/list-example.component';
import { DetailsExampleComponent } from './pages/example/details-example/details-example.component';
import { UploadExampleComponent } from './pages/example/upload-example/upload-example.component';
import { AsnDetailImportComponent } from './pages/inbound/asn/asn-detail-import/asn-detail-import.component';
import { PrintComponent } from './pages/example/print/print.component';

registerLocaleData(zh);

export function createTranslateHttpLoader(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

@NgModule({
  declarations: [
    AppComponent,
    SearchFormComponent,
    EditformComponent,
    SelectFormComponent,
    MessagesComponent,
    ListExampleComponent,
    DetailsExampleComponent,
    UploadExampleComponent,
    PrintComponent,
    /* */
    AsnComponent,
    AsnDetailsComponent,
    AsnDetailImportComponent,
    AsnCheckListComponent,
    AsnCheckDetailsComponent,
    InboundListComponent,
    InboundDetailsComponent,
    RcvListComponent,
    QcListComponent,
    QcDetailsComponent,
    PutAwayListComponent,
    PutAwayDetailsComponent,
    /* */
    InventoryListComponent,
    InventoryDetailsComponent,
    /* */
    DnListComponent,
    DnDetailsComponent,
    OutboundListComponent,
    OutboundDetailsComponent,
    AllotListComponent,
    AllotDetailsComponent,
    WaveListComponent,
    WaveDetailsComponent,
    PickListComponent,
    PickDetailsComponent,
    RechekListComponent,
    RechekDetailsComponent,
    HandOverListComponent,
    HandOverDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    IconsProviderModule,
    NgZorroAntdModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: (createTranslateHttpLoader),
        deps: [HttpClient]
      }
    })
  ],
  providers: [
    { provide: NZ_I18N, useValue: en_US },
    { provide: LocationStrategy, useClass: HashLocationStrategy }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

