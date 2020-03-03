import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OutboundService {

  private outboundUrl = "/api/out/outbound/";
  private list = "list";
  private details = "/";
  private create ="create/";

  constructor(private http: HttpClient) { }

  getList(pageIndex: number): Observable<OutboundModelResult> {
    let url = this.outboundUrl + this.list;
    url = url + "?page=" + pageIndex;
    console.log(url);
    return this.http.get<OutboundModelResult>(url);
  }

  getDetails(id:number): Observable<OutboundResult> {
    let url = this.outboundUrl + this.details + id;
    return this.http.get<OutboundResult>(url);
  }

  set(dnIds:number[]):Observable<OutboundModelResultList>{
      let url = this.outboundUrl+this.create;
      url = url+"?operatorUserName=rickli";
      console.log(url);
      return this.http.post<OutboundModelResultList>(url,dnIds);  
  }
}
