import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WhService {

  private url ="/api/outer/wh";
  private list = "/warehouse/list";

  constructor(private http:HttpClient)  {
    
  } 

  public getWarehouse():Observable<BasicDataModelResult>
  {
     return this.http.get<BasicDataModelResult>(this.url+this.list);
  }
}
