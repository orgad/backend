import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { InboundService } from 'src/app/services/inbound/rcv/inbound.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-inbound-details',
  templateUrl: './inbound-details.component.html',
  styleUrls: ['./inbound-details.component.css']
})
export class InboundDetailsComponent implements OnInit {

  validateForm: FormGroup;
  id: number;
  inbound: Inbound = {
    code: '', batchNo: '', brandId: 0, custId: 0, isCiq: false, bizCode: '',
    detailList: null, asnId: 0, whId: 0, goodsType: '', invoiceNo: ''
  };
  whs: any[];

  constructor(private inboundService: InboundService, private fb: FormBuilder, private route: ActivatedRoute) {
    this.validateForm = this.fb.group(["validateForm"]);
  }

  ngOnInit() {
    this.initvalidateForm();
    this.id = this.route.snapshot.params["id"];
    //获得参数
    this.getInbound();
  }

  initvalidateForm() {
    this.validateForm.addControl("ctrl_whId", new FormControl());
    this.validateForm.addControl("ctrl_custId", new FormControl());
    this.validateForm.addControl("ctrl_brandId", new FormControl());
    this.validateForm.addControl("ctrl_code", new FormControl());
    this.validateForm.addControl("ctrl_batchNo", new FormControl());
    this.validateForm.addControl("ctrl_refNo", new FormControl());
    this.validateForm.addControl("ctrl_bizCode", new FormControl());
    this.validateForm.addControl("ctrl_goodsType", new FormControl());
    this.validateForm.addControl("ctrl_invoiceNo", new FormControl());
    this.validateForm.addControl("ctrl_isCiq", new FormControl());
    this.validateForm.addControl("ctrl_asnId", new FormControl());
  }

  getInbound(): void {
    this.inboundService.getInbound(this.id).
      subscribe(
        result => {
          this.inbound = result.inbound;
          console.log(this.inbound);
          this.showInbound();
        }
      );
  }

  showInbound() {
    console.log(this.inbound.whId.toString());
    this.validateForm.get("ctrl_whId").setValue(this.inbound.whId.toString());
    this.validateForm.get("ctrl_custId").setValue(this.inbound.custId.toString());
    this.validateForm.get("ctrl_brandId").setValue(this.inbound.brandId.toString());
    this.validateForm.get("ctrl_bizCode").setValue(this.inbound.bizCode.toString());
    this.validateForm.get("ctrl_goodsType").setValue(this.inbound.goodsType.toString());
    this.validateForm.get("ctrl_asnId").setValue(this.inbound.asnId.toString());
  }

}
