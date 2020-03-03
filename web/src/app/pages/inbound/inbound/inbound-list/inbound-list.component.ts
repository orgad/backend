import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { InboundService } from 'src/app/services/inbound/rcv/inbound.service';
import { NzMessageService } from 'ng-zorro-antd';
import { QueryFormInboundData } from 'src/app/datas/query-form-inbound-data';

@Component({
  selector: 'inbound-list',
  templateUrl: './inbound-list.component.html',
  styleUrls: ['./inbound-list.component.css']
})

export class InboundListComponent implements OnInit {

  controlArray: Array<{ index: number, id: string, code: string, show: boolean }> = [];
  queryForm: FormGroup;
  queryInbound: QueryInbound = { whId: 10001, custId: 20001, code: "", brandId: 30001, batchNo: "", status: "None", rcvStatus: "", qcStatus: "", paStatus: "" };
  isVisible = false;
  isCollapse = true;
  inboundList: InboundModel[];

  listOfDisplayData: InboundModel[] = [];
  isAllDisplayDataChecked = false;
  isOperating = false;
  isIndeterminate = false;

  mapOfCheckedId: { [key: string]: boolean } = {};
  numberOfChecked = 0;

  validateForm: FormGroup;
  inbound: InboundModel = { id: 0, whId: 0, custId: 0, brandId: 0, bizCode: '', goodsType: '', invoiceNo: '', isCiq: false };

  pageIndex: number = 1;
  pageSize: number = 20;
  total:number;

  constructor(private inboundService: InboundService, private message: NzMessageService, private fb: FormBuilder) {
    this.queryForm = this.fb.group(["queryForm"]);
    this.validateForm = this.fb.group(["validateForm"]);
  }

  ngOnInit() {
    this.controlArray = QueryFormInboundData;

    for (let i = 0; i < this.controlArray.length; i++) {
      this.controlArray[i].show = i < 6;
      this.queryForm.addControl(`q_ctrl_inbound_` + this.controlArray[i].id, new FormControl());
    }

    this.validateForm.addControl("ctrl_inbound_whId", new FormControl());
    this.validateForm.addControl("ctrl_inbound_custId", new FormControl());
    this.validateForm.addControl("ctrl_inbound_brandId", new FormControl());
    this.validateForm.addControl("ctrl_inbound_bizCode", new FormControl());
    this.validateForm.addControl("ctrl_inbound_goodsType", new FormControl());
    this.validateForm.addControl("ctrl_inbound_invoiceNo", new FormControl());
    this.validateForm.addControl("ctrl_inbound_isCiq", new FormControl());
  }

  toggleCollapse(): void {
    this.isCollapse = !this.isCollapse;
    this.controlArray.forEach((c, index) => {
      c.show = this.isCollapse ? index < 6 : true;
    });
  }

  resetForm(): void {
    this.queryForm.reset();
  }

  doQuery(): void {
    this.queryInbound.code = this.queryForm.controls["q_ctrl_inbound_code"].value;
    this.queryInbound.batchNo = this.queryForm.controls["q_ctrl_inbound_batchNo"].value;

    this.getList(this.pageIndex);
  }

  currentPageDataChange($event: AsnModel[]): void {
    this.listOfDisplayData = $event;
    this.refreshStatus();
  }

  private getList(pageIndex: number): void {
    this.inboundService.getList(pageIndex - 1, this.queryInbound.whId, this.queryInbound.code, this.queryInbound.batchNo)
      .subscribe(item => {
        console.log(item);
        this.inboundList = item.data;
        this.total = item.totalCount;
      });
  }

  changePageIndex(pageIndex) {
    this.pageIndex = pageIndex;
    this.getList(this.pageIndex);
  }
  changePageSize(pageSize) {
    this.pageSize = pageSize;
    this.getList(this.pageIndex);
  }

  handleOk(): void {
    this.inbound.whId = this.validateForm.controls["ctrl_inbound_whId"].value;
    this.inbound.whId = this.validateForm.controls["ctrl_inbound_whId"].value;
    this.inbound.custId = this.validateForm.controls["ctrl_inbound_custId"].value;
    this.inbound.brandId = this.validateForm.controls["ctrl_inbound_brandId"].value;
    this.inbound.bizCode = this.validateForm.controls["ctrl_inbound_bizCode"].value;
    this.inbound.goodsType = this.validateForm.controls["ctrl_inbound_goodsType"].value;
    this.inbound.invoiceNo = this.validateForm.controls["ctrl_inbound_invoiceNo"].value;
    this.inbound.isCiq = this.validateForm.controls["ctrl_inbound_isCiq"].value;

    this.setInbound(this.inbound);
  }

  setInbound(inbound: InboundModel): void {
    this.inboundService.setInbound(inbound)
      .subscribe(item => {
        this.doOK(true);
      });
  }

  doOK(flag: boolean): void {
    this.isVisible = !flag;
  }

  handleCancel(): void {
    console.log('Button cancel clicked!');
    this.isVisible = false;
  }

  doAdd(): void {
    //弹窗
    this.isVisible = true;
  }

  private getCheckedIds(): Array<number> {
    let ids: number[] = [];

    for (let item of this.listOfDisplayData) {
      var r = this.mapOfCheckedId[item.id];
      if (r) {
        ids.push(item.id);
      }
    }
    return ids;
  }

  doRcv(): void {
    var ids = this.getCheckedIds();
    this.inboundService.checkInbounds(ids).subscribe(
      result =>
        this.message.info(ids + " rcv " + result.inbound.code)
    );
  }

  doQc(): void {
    var ids = this.getCheckedIds();
    this.inboundService.qcInbounds(ids).subscribe(
      result =>
        this.message.info(ids + " qc " + result.inbound.code)
    );
  }

  doPutAway(): void {
    var ids = this.getCheckedIds();
    this.inboundService.putawayInbounds(ids).subscribe(
      result =>
        this.message.info(ids + " putaway " + result.inbound.code)
    );
  }


  refreshStatus(): void {

  }

  checkAll(value: boolean): void {
    this.listOfDisplayData.forEach(item => this.mapOfCheckedId[item.id] = value);
  }

  operateData(): void {

  }

}
