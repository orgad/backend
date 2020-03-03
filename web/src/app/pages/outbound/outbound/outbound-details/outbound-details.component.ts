import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { OutboundService } from 'src/app/services/outbound/outbound/outbound.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-outbound-details',
  templateUrl: './outbound-details.component.html',
  styleUrls: ['./outbound-details.component.css']
})
export class OutboundDetailsComponent implements OnInit {

  whs : BasicData[];
  headerForm: FormGroup;
  outbound : Outbound;
  id:number;

  constructor(private fb:FormBuilder,private outboundService:OutboundService,
    private route:ActivatedRoute) {
    this.headerForm = fb.group(["headerForm"]);
   }

  ngOnInit() {
    this.initDetailsForm();
    this.id = this.route.snapshot.params["id"];
    this.getDetails();
    this.setInbound();
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

  private setInbound():void
  {
    this.headerForm.get("ctrl_code").setValue(this.outbound.code);
  }

  getDetails():void{
    this.outboundService.getDetails(this.id).subscribe(
      r=>{
         this.outbound = r.result;
      }
    );
  }
}
