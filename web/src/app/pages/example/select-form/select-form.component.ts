import { Component } from '@angular/core';

@Component({
  selector: 'app-select-form',
  templateUrl: './select-form.component.html',
  styleUrls: ['./select-form.component.css']
})
export class SelectFormComponent {

  asn: Asn = {
    code: "",
    batchNo: "",
    whId: 10001,
    custId: 20001,
    brandId: 30001,
    bizCode: "",
    goodsType: "",
    invoiceNo: "",
    isCiq: false,
    detailList: null,
    ciqDetailList: null
  };

  ngOnInit() {
    this.asn.whId = 20001;
  }
}
