import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AsnCheckService {
  
  private baseUrl:string = "/api/mobile/in/asn/check/";

  urls = "/api/mobile/in/asn/check/3/detail-list-upload";
  url = "/api/mobile/in/asn/check/3/detail-upload";

  constructor(private http: HttpClient) { }

  list():Observable<AsnCheckModelResult>{
    let url = this.baseUrl + "asn-check-list";
    return this.http.get<AsnCheckModelResult>(url);
  }

  get(id:number):Observable<AsnCheck>{
    let url = this.baseUrl+id;
    return this.http.get<AsnCheck>(url);
  }

  update(id:number,data:any){
    let url = this.baseUrl+"update/"+id;
    return this.http.put(url,data);
  }

  Save(files: any[]) {
    const formData = new FormData();
    for (let i = 0; i < files.length; i++) {
      formData.append('files', files[i] as any, i.toString());
    }
    formData.append('fileDesc', "测试数据");
    return this.http.post(this.urls, formData);
  }
}
