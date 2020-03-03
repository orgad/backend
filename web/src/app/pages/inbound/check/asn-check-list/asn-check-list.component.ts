import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd';
import { AsnCheckService } from 'src/app/services/inbound/asn/asn-check.service';

@Component({
  selector: 'app-asn-check-list',
  templateUrl: './asn-check-list.component.html',
  styleUrls: ['./asn-check-list.component.css']
})
export class AsnCheckListComponent implements OnInit {

  controlArray: Array<{ index: number, id: string, code: string, show: boolean }> = [];
  queryForm: FormGroup;
  isCollapse = true;
  asnCheckList: AsnCheckModel[];

  isAllDisplayDataChecked = false;
  isOperating = false;
  isIndeterminate = false;
  listOfDisplayData: AsnModel[] = [];

  mapOfCheckedId: { [key: string]: boolean } = {};
  numberOfChecked = 0;

  total: number;
  pageSize: number = 20;
  pageIndex: number = 1;

  constructor(private asnCheckService: AsnCheckService, private messageService: NzMessageService, private fb: FormBuilder) {
    this.queryForm = this.fb.group(["queryForm"]);
  }

  ngOnInit() {
    this.initQueryForm();
  }

  initQueryForm(): void {
    this.controlArray.push({ index: 0, code: 'checkcode', id: 'checkCode', show: false });
    this.controlArray.push({ index: 1, code: 'asnCode', id: 'asnCode', show: false });

    for (let i = 0; i < this.controlArray.length; i++) {
      this.controlArray[i].show = i < 6;
      this.queryForm.addControl(`query.` + this.controlArray[i].id, new FormControl());
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

  doSearch(): void {
    this.getList(this.pageIndex);
  }

  currentPageDataChange($event: AsnModel[]): void {
    this.listOfDisplayData = $event;
    this.refreshStatus();
  }

  private getList(pageIndex: number) {
    let code = this.queryForm.controls["query.asnCode"].value;

    this.asnCheckService.getList(pageIndex - 1, code)
      .subscribe(result => {
        this.asnCheckList = result.data;
        this.total = result.totalCount;
        console.log(this.total);
        //this.messageService.info(this.total.toString());
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

  refreshStatus(): void {

  }

  checkAll(value: boolean): void {

  }

}
