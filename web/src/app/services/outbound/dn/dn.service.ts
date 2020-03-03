import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DnService {

  private dnUrl = "/api/out/dn/";
  private list = "list";
  private details = "/";

  constructor(private http:HttpClient) { }

  getList(page:number):Observable<DnModelResultList>
  {
     let url = this.dnUrl+this.list+"?page="+page;
     console.log(url);
     return this.http.get<DnModelResultList>(url);
  }

  getDetails(id:number):Observable<DnResult>
  {
    let url = this.dnUrl+this.details+id;
     return this.http.get<DnResult>(url);
  }
}
