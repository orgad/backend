import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PickService {

  constructor(private http:HttpClient) { }

  private pickUrl = "/api/out/pck/";
  private list = "list";
  private details = "";

  getList(page:number,waveCode:string):Observable<PickingModelReusltList>
  {
    let url = this.pickUrl+this.list+"?page="+page;
    if(waveCode!=undefined)
    {
      url = url+"&waveCode="+waveCode;
    }
    console.log(url);
    return this.http.get<PickingModelReusltList>(url);
  }

  getDetails(id:number):Observable<PickingResult>
  {
    let url = this.pickUrl+this.details+id;
    return this.http.get<PickingResult>(url);
  }
}
