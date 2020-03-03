import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MessageService } from '../../message/message.service';

@Injectable({
  providedIn: 'root'
})
export class AsnService {

  /*根路径*/
  private asnUrl = '/api/in/asn';
  private asnList = '/list';
  private asnAdd = '?operatorUserName=rickli';
  private asnDetails = '/details';
  private asnUpload='/importdetail';
  private asnDown = "/download/";
  private asnaffirm = '/affirm?operatorUserName=rickli';
  private asncheck = '/check-affirm?operatorUserName=rickli';

  constructor(private http: HttpClient) { }

  getAsnList(pageIndex:number,queryString:string): Observable<AsnModelResult> {
    var url = this.asnUrl + this.asnList;
    url += "?pageIndex="+pageIndex+""+ queryString;
    console.log(url);
    return this.http.get<AsnModelResult>(url);
  }

  getAsn(id: number): Observable<AsnResult> {
    var url = this.asnUrl + this.asnDetails + "/" + id;
    return this.http.get<AsnResult>(url);
  }

  setAsn(asn:AsnModel) {
    var url = this.asnUrl + this.asnAdd;
    return this.http.post(url, asn);
  }

  getUploadUrl():string{
    return this.asnUrl + this.asnUpload;
  }

  download(id:number)
  {
      var url = this.asnUrl + this.asnDetails + this.asnDown + id;       
      return this.http.get(url,{ responseType: "blob"});
  }

  //到货确认
  affirmAsn(ids:number[])
  {
    var url = this.asnUrl + this.asnaffirm;
    return this.http.post(url, ids);
  }
  
  //验货确认
  checkAsn(ids:number[])
  {
    var url = this.asnUrl + this.asncheck;
    return this.http.post(url, ids);
  }
}
