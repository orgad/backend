import { Component, OnInit } from '@angular/core';
import { RcvService } from 'src/app/services/inbound/rcv/rcv.service';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-rcv-list',
  templateUrl: './rcv-list.component.html',
  styleUrls: ['./rcv-list.component.css']
})
export class RcvListComponent implements OnInit {

  rcvList: RcvModel[];
  total: number;
  pageIndex: number = 1;
  pageSize: number = 20;
  listOfDisplayData: QcModel[] = [];
  mapOfCheckedId: { [key: string]: boolean } = {};
  numberOfChecked = 0;
  controlArray: Array<{ index: number, id: string, code: string, show: boolean }> = [];
  queryForm: FormGroup;
  isCollapse: boolean = true;
  isAllDisplayDataChecked: boolean = true;
  isIndeterminate: boolean = true;

  constructor(private rcvService: RcvService, private fb: FormBuilder) {
    this.queryForm = this.fb.group(["queryForm"]);
  }

  ngOnInit() {
    this.initQueryForm();
    this.getRcvList();
  }

  initQueryForm(): void {
    this.controlArray.push({ index: 0, code: 'warehouse', id: 'whId', show: false });
    this.controlArray.push({ index: 1, code: 'customer', id: 'custId', show: false });
    this.controlArray.push({ index: 2, code: 'brand', id: 'brandId', show: false });
    this.controlArray.push({ index: 3, code: 'code', id: 'InboundCode', show: false });
    this.controlArray.push({ index: 4, code: 'batchNo', id: 'batchNo', show: false });

    for (let i = 0; i < this.controlArray.length; i++) {
      this.controlArray[i].show = i < 6;
      this.queryForm.addControl(`query.` + this.controlArray[i].id, new FormControl());
    }
  }

  doSearch(): void {
    this.getRcvList();
  }

  private getRcvList(): void {
    var code = this.queryForm.controls["query.InboundCode"].value;
    this.rcvService.getRcv(code, this.pageIndex - 1).subscribe(
      result => {
        this.rcvList = result.result.data;
        this.total = result.result.totalCount;
      }
    );
  }

  resetForm(): void {

  }

  checkAll(value: boolean): void {

  }

  toggleCollapse(): void {
    this.isCollapse = !this.isCollapse;
    this.controlArray.forEach((c, index) => {
      c.show = this.isCollapse ? index < 6 : true;
    });
  }

  currentPageDataChange($event: QcModel[]): void {
    this.listOfDisplayData = $event;
    this.refreshStatus();
  }

  changePageIndex(pageIndex) {
    this.pageIndex = pageIndex;
    this.getRcvList();
  }
  changePageSize(pageSize) {
    this.pageSize = pageSize;
    this.getRcvList();
  }

  refreshStatus(): void {

  }

}
