import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-upload-example',
  templateUrl: './upload-example.component.html'
})
export class UploadExampleComponent {
  file:any;
  uploadUrl ="/api/in/asn/importdetail?id=1512&code=ASN2020012200006";

  url = "/api/mobile/in/asn/check/3/detail-list-upload";

  constructor(private http:HttpClient){}


  onTake(e)
  { 
    this.file = e.target.files[0];
    const formData = new FormData();
    formData.append('file', this.file as any);
    formData.append('fileDesc',"测试数据");

    this.http.post(this.url,formData)
    .subscribe(x=>console.log(x));

  }
}
