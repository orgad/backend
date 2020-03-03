import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd';
import { ActivatedRoute } from '@angular/router';
import { HandOverService } from 'src/app/services/outbound/hand-over/hand-over.service';

@Component({
  selector: 'app-hand-over-details',
  templateUrl: './hand-over-details.component.html',
  styleUrls: ['./hand-over-details.component.css']
})
export class HandOverDetailsComponent implements OnInit {

  whs : BasicData[];
  headerForm: FormGroup;
  id:number;
  handOver:HandOver;
  handOverDetails:HandOverDetail[];

  constructor(private fb:FormBuilder,private messageService:NzMessageService, private route:ActivatedRoute,
    private handOverService:HandOverService) {
    this.headerForm = fb.group(["headerForm"]);
   }

  ngOnInit() {
    this.initDetailsForm();
    this.id= this.route.snapshot.params["id"];
    this.getDetails();
  }

  initDetailsForm():void{
    this.headerForm.addControl("ctrl_whId",new FormControl());
    this.headerForm.addControl("ctrl_custId",new FormControl());
    this.headerForm.addControl("ctrl_brandId",new FormControl());
    this.headerForm.addControl("ctrl_code",new FormControl());
    this.headerForm.addControl("ctrl_batchNo",new FormControl());
    this.headerForm.addControl("ctrl_refNo",new FormControl());
    this.headerForm.addControl("ctrl_bizCode",new FormControl());
    this.headerForm.addControl("ctrl_goodsType",new FormControl());
    this.headerForm.addControl("ctrl_invoiceNo",new FormControl());
    this.headerForm.addControl("ctrl_isCiq",new FormControl());
  }

  getDetails(){
    
    this.handOverService.getDetails(this.id).subscribe(r=>{
      this.handOverDetails = r.result.data;
      this.messageService.info(r.success.toString());
    }); 
  }
}
