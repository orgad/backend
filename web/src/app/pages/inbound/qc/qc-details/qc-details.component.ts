import { Component, OnInit } from '@angular/core';
import { QcService } from 'src/app/services/inbound/qc/qc.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-qc-details',
  templateUrl: './qc-details.component.html',
  styleUrls: ['./qc-details.component.css']
})
export class QcDetailsComponent implements OnInit {

  id:number;
  qc:QcModel = null;
  qcList : QcDetail[];
  constructor(private qcService:QcService,private route:ActivatedRoute) { }

  ngOnInit() {
     this.id = this.route.snapshot.params["id"];
     this.getQc();
     this.getDetails();
  }

  getQc():void{
    this.qcService.getQc(this.id).subscribe(
      r=> {this.qc = r.qc;
        console.log(this.qc);
      }
    );
  }

  getDetails():void{
    this.qcService.getDetails(this.id).subscribe(  
      r=>{ 

        this.qcList = r.qcDs;
        
      }
    );
  }

}
