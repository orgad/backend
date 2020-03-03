import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InventoryService {

  invtUrl = "/api/invt/";
  list = "list";
  details = "detail/list";

  constructor(private http:HttpClient) { 
    
  } 

  getInvtList():Observable<InvtModelResultList>
  {
    let url = this.invtUrl + this.list;
    return this.http.get<InvtModelResultList>(url);
  }

  getInvtDetails(sku:string):Observable<InvtDetailModelResultList>
  {
    let url = this.invtUrl + this.details + "?sku="+sku;
    console.log(url);
    return this.http.get<InvtDetailModelResultList>(url);
  }
}
