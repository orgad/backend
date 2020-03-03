import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd';
import { ActivatedRoute } from '@angular/router';
import { RecheckService } from 'src/app/services/outbound/recheck/recheck.service';

@Component({
  selector: 'app-rechek-details',
  templateUrl: './rechek-details.component.html',
  styleUrls: ['./rechek-details.component.css']
})
export class RechekDetailsComponent implements OnInit {

  whs : BasicData[];
  headerForm: FormGroup;
  id:number;
  recheck:Recheck;

  constructor(private fb:FormBuilder,private messageService:NzMessageService, private route:ActivatedRoute,
    private recheckService:RecheckService) {
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
    
    this.recheckService.getDetails(this.id).subscribe(r=>{
      this.recheck = r.result
      this.messageService.info(r.success.toString());
    }); 
  }

}
