import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RecheckService {

  private recheckUrl = "/api/out/check/";
  private list = "list";
  private details = "?operatorUserName=rickli"
  private create = "createbyids";

  constructor(private http: HttpClient) { }

  getList(pageIndex: number): Observable<RecheckModelResultList> {
    let url = this.recheckUrl + this.list;
    url = url + "?page=" + pageIndex;
    return this.http.get<RecheckModelResultList>(url);
  }

  getDetails(id:number): Observable<RecheckResult> {
    let url = this.recheckUrl + this.details + id;
    return this.http.get<RecheckResult>(url);
  }

  postGen(outboundIds:number[]):Observable<RecheckModelResultList>{
      let url = this.recheckUrl+this.create + outboundIds;
      url = url+"?operatorUserName=rickli";
      console.log(url);
      return this.http.post<RecheckModelResultList>(url,outboundIds);  
  }
}
