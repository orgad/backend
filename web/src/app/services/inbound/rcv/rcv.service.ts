import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RcvService {

  private rcvUrl = '/api/in/opt';
  private list = "/list";

  constructor(private http: HttpClient) {

  }

  getRcv(code: string, page: number): Observable<RcvModelResultList> {
    var url = this.rcvUrl + this.list + "?page=" + page;
    if (code != "") {
      url += "&code=" + code;
    }
    console.log(url);
    return this.http.get<RcvModelResultList>(url);
  }
}
