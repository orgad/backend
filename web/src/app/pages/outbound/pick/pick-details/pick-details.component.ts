import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd';
import { ActivatedRoute } from '@angular/router';
import { PickService } from 'src/app/services/outbound/pick/pick.service';

@Component({
  selector: 'app-pick-details',
  templateUrl: './pick-details.component.html',
  styleUrls: ['./pick-details.component.css']
})
export class PickDetailsComponent implements OnInit {

  whs : BasicData[];
  headerForm: FormGroup;
  id:number;
  entity:any;

  constructor(private fb:FormBuilder,private messageService:NzMessageService, private route:ActivatedRoute,
    private pickService:PickService) {
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
    
    this.pickService.getDetails(this.id).subscribe(r=>{
      this.entity = r.result;
      this.messageService.info(r.success.toString());
    });
    
 }

}
