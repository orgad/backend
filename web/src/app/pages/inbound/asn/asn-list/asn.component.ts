import { Component } from '@angular/core';
import { AsnService } from 'src/app/services/inbound/asn/asn.service';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd';
import { BasicDataService } from 'src/app/services/outer/basic-data.service';
import { QueryFormAsnData } from 'src/app/datas/query-form-asn-data';
import { Router } from '@angular/router';

@Component({
  selector: 'app-asn',
  templateUrl: './asn.component.html',
  styleUrls: ['./asn.component.css']
})
export class AsnComponent {

  /*查询组件*/
  controlArray: Array<{ index: number, id: string, code: string, show: boolean }> = [];

  queryForm: FormGroup;
  isCollapse = true;

  /*分页用 */
  total = 0;
  pageIndex = 1;
  pageSize = 20;

  /* 查询参数 */
  queryAsn: QueryAsn = {
    whId: 10001, custId: 20001, asnCode: "", brandId: 30001, batchNo: "", asnStatus: "", checkStatus: "", isCiq: null,
    bizCode: "", goodsType: "", invoiceNo: ""
  };

  isAllDisplayDataChecked = false;
  isOperating = false;
  isIndeterminate = false;
  /*显示用*/
  listOfDisplayData: AsnModel[] = [];
  /*显示用*/
  mapOfCheckedId: { [key: string]: boolean } = {};
  numberOfChecked = 0;

  whs: BasicData[];
  custs: BasicData[];
  brands: BasicData[];
  asnList: AsnModel[];

  constructor(
    private asnService: AsnService,
    private messageService: NzMessageService,
    private basicDataService: BasicDataService,
    private fb: FormBuilder,
    private router: Router) {
    this.queryForm = this.fb.group(["queryForm"]);
    this.validateForm = this.fb.group(["validateForm"]);
  }

  ngOnInit(): void {
    this.initQueryForm();
    this.initAddForm();
    this.getBasicDatas();
  }

  initQueryForm(): void {
    this.controlArray = QueryFormAsnData;

    for (let i = 0; i < QueryFormAsnData.length; i++) {
      this.controlArray[i].show = i < 6;
      this.queryForm.addControl(`queryAsn.` + this.controlArray[i].id, new FormControl());
    }
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

  private resetStatus(): void {
    this.listOfDisplayData.forEach(item => this.mapOfCheckedId[item.id] = false);
  }

  doSearch(): void {
    this.queryAsn.whId = this.queryForm.controls["queryAsn.whId"].value;
    this.queryAsn.custId = this.queryForm.controls["queryAsn.custId"].value;
    this.queryAsn.brandId = this.queryForm.controls["queryAsn.brandId"].value;
    this.queryAsn.asnCode = this.queryForm.controls["queryAsn.asnCode"].value;
    this.queryAsn.asnStatus = this.queryForm.controls["queryAsn.asnStatus"].value;
    this.queryAsn.checkStatus = this.queryForm.controls["queryAsn.checkStatus"].value;
    this.queryAsn.isCiq = this.queryForm.controls["queryAsn.isCiq"].value;
    this.queryAsn.goodsType = this.queryForm.controls["queryAsn.goodsType"].value;
    this.queryAsn.bizCode = this.queryForm.controls["queryAsn.bizCode"].value;
    this.getAsnList();
    this.resetStatus();
  }

  private getAsnList(): void {
    let queryString = "";
    if (this.queryAsn.whId != null) {
      queryString += "&whId=" + this.queryAsn.whId;
    }
    if (this.queryAsn.custId != null) {
      queryString += "&custId=" + this.queryAsn.custId;
    }
    if (this.queryAsn.brandId != null) {
      queryString += "&brandId=" + this.queryAsn.brandId;
    }

    if (this.queryAsn.asnCode != null) {
      queryString += "&asnCode=" + this.queryAsn.asnCode;
    }

    if (this.queryAsn.asnStatus != null) {
      queryString += "&status=" + this.queryAsn.asnStatus;
    }

    if (this.queryAsn.checkStatus != null) {
      queryString += "&checkStatus=" + this.queryAsn.checkStatus;
    }

    if (this.queryAsn.isCiq != null) {
      queryString += "&isCiq=" + this.queryAsn.isCiq;
    }

    if (this.queryAsn.bizCode != null) {
      queryString += "&bizCode=" + this.queryAsn.bizCode;
    }

    if (this.queryAsn.goodsType != null) {
      queryString += "&goodsType=" + this.queryAsn.goodsType;
    }

    this.asnService.getAsnList(this.pageIndex - 1, queryString)
      .subscribe(item => {
        this.total = item.totalCount;
        this.asnList = item.data;
        this.messageService.info("get asn list : " + item.totalCount);
      });
  }

  currentPageDataChange($event: AsnModel[]): void {
    this.listOfDisplayData = $event;
    this.refreshStatus();
  }

  changePageIndex(pageIndex) {
    this.pageIndex = pageIndex;
    this.getAsnList();
  }

  changePageSize(pageSize) {
    this.pageSize = pageSize;
    this.getAsnList();
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

  /*到货确认 */
  doCheck(): void {
    var ids = this.getCheckedIds();
    if (ids == null || ids.length==0) {
      this.messageService.warning("Please Select Any Asn.");
      return;
    }
    this.asnService.affirmAsn(ids).subscribe(
      result => this.messageService.info(result.toString())
    );
  }

  /*验货确认 */
  doAffirm(): void {
    var ids = this.getCheckedIds();
    if (ids == null || ids.length==0) {
      this.messageService.warning("Please Select Any Asn.");
      return;
    }
    this.asnService.checkAsn(ids).subscribe(
      result => this.messageService.info(result.toString())
    );
  }

  /* 新增开始 */
  validateForm: FormGroup;
  isVisible = false;
  asn: AsnModel = { id: 0, whId: 0, custId: 0, brandId: 0, bizCode: "", goodsType: "", invoiceNo: "", isCiq: false, status: '', checkStatus: '', pieceQty: 0 }

  initAddForm(): void {
    this.validateForm.addControl("asn.whId", new FormControl());
    this.validateForm.addControl("asn.custId", new FormControl());
    this.validateForm.addControl("asn.brandId", new FormControl());
    this.validateForm.addControl("asn.bizCode", new FormControl());
    this.validateForm.addControl("asn.goodsType", new FormControl());
    this.validateForm.addControl("asn.invoiceNo", new FormControl());
    this.validateForm.addControl("asn.isCiq", new FormControl());
  }

  doAdd(): void {
    //弹窗
    this.isVisible = true;
  }

  doImport(): void {
    //页面跳转
    var ids = this.getCheckedIds();
    if (ids.length==0 || ids == undefined) {
      
      this.messageService.warning("Please Select Any Asn.");
      return;
    }
    console.log(ids);

    this.router.navigateByUrl("in/asn/asnDetails/importdetail/" + ids[0]);
  }

  getBasicDatas(): void {
    this.basicDataService.getWhList().subscribe(
      result => this.whs = result.data
    );
    this.basicDataService.getCustList().subscribe(
      result => {
        this.custs = result.data;
      }
    );
  }

  onChange(value: string) {
    this.validateForm.controls["asn.brandId"].setValue(null);
    this.getBrandByCustId(value);
  }

  getBrandByCustId(custId: string) {
    this.basicDataService.getBrandList(custId).subscribe(
      result => {
        this.brands = result.data;
      }
    );
  }

  handleOk(): void {
    //获取参数
    this.asn.whId = this.validateForm.controls["asn.whId"].value;
    this.asn.custId = this.validateForm.controls["asn.custId"].value;
    this.asn.brandId = this.validateForm.controls["asn.brandId"].value;
    this.asn.bizCode = this.validateForm.controls["asn.bizCode"].value;
    this.asn.goodsType = this.validateForm.controls["asn.goodsType"].value;
    this.asn.invoiceNo = this.validateForm.controls["asn.invoiceNo"].value;
    this.asn.isCiq = this.validateForm.controls["asn.isCiq"].value;
    this.setAsn(this.asn);
  }

  private setAsn(asn: AsnModel): void {
    this.asnService.setAsn(asn)
      .subscribe(item => {
        this.doOK(item != null);
      });
  }

  doOK(flag: boolean): void {
    this.isVisible = !flag;
  }

  handleCancel(): void {
    this.isVisible = false;
  }

  refreshStatus(): void {

  }

  checkAll(value: boolean): void {
    this.listOfDisplayData.forEach(item => this.mapOfCheckedId[item.id] = value);
  }

  operateData(): void {

  }
}
