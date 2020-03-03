import { Component, OnInit } from '@angular/core';
import { AsnService } from 'src/app/services/inbound/asn/asn.service';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-asn-details',
  templateUrl: './asn-details.component.html',
  styleUrls: ['./asn-details.component.css']
})
export class AsnDetailsComponent implements OnInit {

  id: number;
  asn: Asn = {
    code: "", batchNo: "", whId: 10001, custId: 20001, brandId: 30001, bizCode: "", goodsType: "", invoiceNo: "", isCiq: false, detailList: null,
    ciqDetailList: null
  };

  validateForm: FormGroup;
  whs: [{ id: string, name: string }, { id: string, name: string }];

  constructor(private asnService: AsnService, private fb: FormBuilder, private route: ActivatedRoute) {
    this.validateForm = this.fb.group(["validateForm"]);
  }

  ngOnInit() {

    this.initDetailsForm();

    this.id = this.route.snapshot.params["id"];

    //获得参数
    this.getAsn();

    this.whs = [{ id: "10002", name: "Beijing" }, { id: "10001", name: "Shanghai" }];

  }

  initDetailsForm(): void {
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
  }

  getAsn(): void {
    this.asnService.getAsn(this.id).
      subscribe(
        result => {
          this.asn = result.asn;
          this.showAsn();
        }
      );
  }

  showAsn() {
    this.validateForm.get("ctrl_whId").setValue(this.asn.whId.toString());
    this.validateForm.get("ctrl_custId").setValue(this.asn.custId.toString());
    this.validateForm.get("ctrl_brandId").setValue(this.asn.brandId.toString());
    this.validateForm.get("ctrl_bizCode").setValue(this.asn.bizCode.toString());
    this.validateForm.get("ctrl_goodsType").setValue(this.asn.goodsType.toString());
    this.validateForm.get("ctrl_isCiq").setValue(this.asn.isCiq);
  }

  doDownload(): void {
    this.asnService.download(this.id).subscribe(item => {
      // 下载类型 xls
      const contentType = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet';
      const blob = new Blob([item], { type: contentType });
      const url = window.URL.createObjectURL(blob);
      // 打开新窗口方式进行下载
      window.open(url);
    }
    );
  }

  doPrint():void
  {
    const printContent = document.getElementById("report");
    const WindowPrt = window.open('', '', 'left=0,top=0,width=900,height=900,toolbar=0,scrollbars=0,status=0');
    WindowPrt.document.write(printContent.innerHTML);
    WindowPrt.document.close();
    WindowPrt.focus();
    WindowPrt.print();
    WindowPrt.close();
  }
}
