import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { DnService } from 'src/app/services/outbound/dn/dn.service';

@Component({
  selector: 'app-dn-details',
  templateUrl: './dn-details.component.html',
  styleUrls: ['./dn-details.component.css']
})
export class DnDetailsComponent implements OnInit {

  whs: BasicData[];
  headerForm: FormGroup;
  id: number;
  dn: Dn = { id: 0, code: "", batchNo: "", custId: "", refNo: "", transCode: "", srcCode: "", status: "", expectAt: null, detailDTOList: null };

  constructor(private fb: FormBuilder, private dnService: DnService, private route: ActivatedRoute) {
    this.id = this.route.snapshot.params["id"];
    this.headerForm = this.fb.group(["headerForm"]);
  }

  ngOnInit() {
    this.initDetailsForm();
    this.getDetails();
    this.show();
  }

  initDetailsForm(): void {
    this.headerForm.addControl("ctrl_whId", new FormControl());
    this.headerForm.addControl("ctrl_custId", new FormControl());
    this.headerForm.addControl("ctrl_brandId", new FormControl());
    this.headerForm.addControl("ctrl_code", new FormControl());
    this.headerForm.addControl("ctrl_batchNo", new FormControl());
    this.headerForm.addControl("ctrl_refNo", new FormControl());
    this.headerForm.addControl("ctrl_bizCode", new FormControl());
    this.headerForm.addControl("ctrl_goodsType", new FormControl());
    this.headerForm.addControl("ctrl_invoiceNo", new FormControl());
    this.headerForm.addControl("ctrl_isCiq", new FormControl());
  }

  private show() {

    this.headerForm.get("ctrl_code").setValue(this.dn.code);
  }

  private getDetails() {
    this.dnService.getDetails(this.id).subscribe(r => {
      this.dn = r.result;
      
    }
    );
  }

}
