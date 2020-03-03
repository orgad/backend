import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { AllotService } from 'src/app/services/outbound/allot/allot.service';
import { NzMessageService } from 'ng-zorro-antd';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-allot-details',
  templateUrl: './allot-details.component.html',
  styleUrls: ['./allot-details.component.css']
})
export class AllotDetailsComponent implements OnInit {

  whs : BasicData[];
  headerForm: FormGroup;
  allot : Allot;
  id:number;

  constructor(private fb:FormBuilder,private route:ActivatedRoute,
    private messageService:NzMessageService,
    private allotService:AllotService) {
    this.headerForm = fb.group(["headerForm"]);
   }

  ngOnInit() {
    this.initDetailsForm();
    this.id = this.route.snapshot.params["id"];
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
     this.allotService.getDetails(this.id).subscribe(r=>{
       this.allot = r.result
       this.messageService.info(r.success.toString());
     });
  }

}
