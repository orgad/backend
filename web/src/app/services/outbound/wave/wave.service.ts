import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WaveService {

  constructor(private http:HttpClient) { }

  private waveUrl = "/api/out/wave/";
  private list="list";
  private create="create";

 getList(page:number,id:number):Observable<WaveModelResultList>{
    let url = this.waveUrl+this.list+"?page="+page;
    return this.http.get<WaveModelResultList>(url);
  }

 createWave(custId:number):Observable<WaveModelResultList>{
    let url = this.waveUrl+this.create;
    return this.http.post<WaveModelResultList>(url,custId)
  }
}
