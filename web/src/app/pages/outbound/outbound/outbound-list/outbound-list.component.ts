import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { OutboundService } from 'src/app/services/outbound/outbound/outbound.service';
import { AllotService } from 'src/app/services/outbound/allot/allot.service';
import { NzMessageService } from 'ng-zorro-antd';
import { RecheckService } from 'src/app/services/outbound/recheck/recheck.service';
import { HandOverService } from 'src/app/services/outbound/hand-over/hand-over.service';

@Component({
  selector: 'app-outbound-list',
  templateUrl: './outbound-list.component.html',
  styleUrls: ['./outbound-list.component.css']
})
export class OutboundListComponent implements OnInit {

  controlArray: Array<{ index: number, id: string, code: string, show: boolean }> = [];

  queryForm: FormGroup;
  isCollapse = true;

  /*分页用 */
  total = 0;
  pageIndex = 1;
  pageSize = 20;

  isAllDisplayDataChecked = false;
  isOperating = false;
  isIndeterminate = false;
  /*显示用*/
  listOfDisplayData: any = [];
  /*显示用*/
  mapOfCheckedId: { [key: string]: boolean } = {};
  numberOfChecked = 0;

  outboundList: OutboundModel[];

  constructor(private fb: FormBuilder, private outboundService: OutboundService,
    private allotService: AllotService, private recheckService: RecheckService, private handOverService: HandOverService,
    private messageService: NzMessageService) {
    this.queryForm = this.fb.group(["queryForm"]);
  }

  ngOnInit() {
    this.initQueryForm();
  }

  private initQueryForm(): void {
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
    this.resetStatus();
  }

  private getList(pageIndex: number) {
    this.outboundService.getList(pageIndex - 1).subscribe(
      r => {
        this.outboundList = r.data;
        this.total = r.totalCount;
      }
    );
  }

  currentPageDataChange($event: AsnModel[]): void {
    this.listOfDisplayData = $event;
    this.refreshStatus();
  }

  changePageIndex(pageIndex) {
    this.pageIndex = pageIndex;
    this.getList(this.pageIndex);
  }

  changePageSize(pageSize) {
    this.pageSize = pageSize;
    this.getList(this.pageIndex);
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

  refreshStatus(): void {
    //this.listOfDisplayData.forEach(item => this.mapOfCheckedId[item.id] = false);
    //this.messageService.info("refresh");
  }

  private resetStatus(): void {
    this.listOfDisplayData.forEach(item => this.mapOfCheckedId[item.id] = false);
  }

  doCheck(): void {
    let ids = this.getCheckedIds();
    this.allotService.postGen(ids).subscribe(
      r => this.messageService.info(r.success.toString())
    );
  }

  checkAll(value: boolean): void {

  }

  doWave(): void {

  }

  doPick(): void {

  }

  doRecheck(): void {
    let ids = this.getCheckedIds();
    this.recheckService.postGen(ids).subscribe(
      r => this.messageService.info(r.success.toString())
    );
  }

  doHandOver(): void {
    let ids = this.getCheckedIds();
    this.handOverService.postGen(ids).subscribe(
      r => this.messageService.info(r.success.toString())
    );
  }

}
