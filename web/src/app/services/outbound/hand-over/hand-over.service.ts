import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HandOverService {

  private handOverUrl = "/api/out/handover/";
  private list = "list";
  private one = "";
  private details = "details/list?operatorUserName=rickli&HId="
  private create = "createbyids";

  constructor(private http: HttpClient) { }

  getList(pageIndex: number): Observable<HandOverModelResultList> {
    let url = this.handOverUrl + this.list;
    url = url + "?page=" + pageIndex;
    return this.http.get<HandOverModelResultList>(url);
  }

  getOne(id:number):Observable<HandOverResult>
  {
    let url = this.handOverUrl + this.one + id;
    return this.http.get<HandOverResult>(url);
  }

  getDetails(id:number): Observable<HandOverDetailModelResultList> {
    let url = this.handOverUrl + this.details + id;
    return this.http.get<HandOverDetailModelResultList>(url);
  }

  postGen(outboundIds:number[]):Observable<HandOverModelResultList>{
      let url = this.handOverUrl+this.create + outboundIds;
      url = url+"?operatorUserName=rickli";
      console.log(url);
      return this.http.post<HandOverModelResultList>(url,outboundIds);  
  }
}
