import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: 'app-details-example',
  templateUrl: './details-example.component.html',
  styleUrls: ['./details-example.component.css']
})
export class DetailsExampleComponent implements OnInit {

  whs : BasicData[];
  headerForm: FormGroup;
  id:number;
  entity:any;

  constructor(private fb:FormBuilder,private messageService:NzMessageService, private route:ActivatedRoute) {
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
    /*
    this.XXXService.getDetails(this.id).subscribe(r=>{
      this.entity = r.result;
      this.messageService.info(r.success.toString());
    });
    */
 }

}
