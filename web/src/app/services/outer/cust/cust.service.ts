import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustService {

  private url = "/api/outer/cust/";
  private custlist = "customer/list";

  private brandlist = "brand/list";

  constructor(private http: HttpClient) { }

  public getCustList(): Observable<BasicDataModelResult> {
    return this.http.get<BasicDataModelResult>(this.url + this.custlist);
  }

  public getBrandList(custId: string): Observable<BasicDataModelResult> {
    return this.http.get<BasicDataModelResult>(this.url + this.brandlist + "/" + custId);
  }
}
