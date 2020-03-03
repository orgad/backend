import { Component, OnInit } from '@angular/core';
import { AsnCheckService } from 'src/app/services/inbound/asn/asn-check.service';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-asn-check-details',
  templateUrl: './asn-check-details.component.html',
  styleUrls: ['./asn-check-details.component.css']
})
export class AsnCheckDetailsComponent implements OnInit {

  id: number;
  asnCheck: AsnCheck = {
    code: "", asnBatchNo: "", asnBizCode: "", asnBrandId: 0, asnCartonQty: 0, asnCode: "",
    id: 0, cartonQty: 0, damageCartonQty: 0, damageQty: 0
  };
  asnCheckDs: AsnCheckDetail[] = null;
  validateForm: FormGroup;

  whs: any[];

  constructor(private asnCheckService: AsnCheckService, private fb: FormBuilder, private route: ActivatedRoute) {
    this.validateForm = this.fb.group(["validateForm"]);
  }

  ngOnInit() {
    this.initForm();
    this.id = this.route.snapshot.params["id"];
    this.getAsnCheck();
  }

  private initForm() {
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
    this.validateForm.addControl("ctrl_asnCode", new FormControl());
  }

  getAsnCheck() {
    this.asnCheckService.getDetails(this.id).subscribe(
      result => {
        this.asnCheck = result.asnCheck;
        this.asnCheckDs = result.asnCheckDs;
      }
    );
  }

}
