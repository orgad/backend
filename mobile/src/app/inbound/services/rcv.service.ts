import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RcvService {

  private inboundUrl = '/api/mobile/in/inbound/';
  private rcvList = 'rcv/list';
  private scan = "rcv/scan/";
  private rcv:Rcv;

  constructor(private http:HttpClient) { }

  getRcvList():Observable<InboundModelResult>
  {
    let url = this.inboundUrl + this.rcvList;
    return this.http.get<InboundModelResult>(url);
  }

  saveInboudDetail(inboundId:any,barcode:string)
  {
    this.rcv = {id:0,orderId:inboundId,optCode:"",skuId:0,sku:"",barcode:barcode,carton:"",qty:1};
    let url = this.inboundUrl + this.scan + inboundId;
     return this.http.post(url,this.rcv);
  }
}
