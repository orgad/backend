import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { AsnService } from 'src/app/services/inbound/asn/asn.service';


@Component({
  selector: 'app-asn-detail-import',
  templateUrl: './asn-detail-import.component.html',
  styleUrls: ['./asn-detail-import.component.css']
})
export class AsnDetailImportComponent implements OnInit {

  
  id :number;
  code : number;
  uploadUrl:string;
  
  constructor(private route:ActivatedRoute,
    private asnService:AsnService) {
      this.uploadUrl = this.asnService.getUploadUrl();
     }

  ngOnInit() {
    this.id = this.route.snapshot.params["id"];
    this.uploadUrl  = this.uploadUrl + "?id="+ this.id + "&code=" + this.route.snapshot.params["id"];
    console.log(this.uploadUrl);
  }

}
