import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PutAwayService {

  private putAwayUrl = '/api/in/putaway';
  private list = "-list";

  constructor(private http: HttpClient) { }

  getPutAwayList()
  {
    return this.http.get<PutAwayModelResult>(this.putAwayUrl+this.list);
  }
}
