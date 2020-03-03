import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd';
import { AllotService } from 'src/app/services/outbound/allot/allot.service';

@Component({
  selector: 'app-allot-list',
  templateUrl: './allot-list.component.html',
  styleUrls: ['./allot-list.component.css']
})
export class AllotListComponent implements OnInit {

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

  altList:AllotModel[];

  constructor(private fb: FormBuilder,
    private messageService:NzMessageService,
    private allotService:AllotService) {
    this.queryForm = this.fb.group(["queryForm"]);
  }

  ngOnInit() {
    this.initQueryForm();
    
  }

  initQueryForm(): void {
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

  private getList(pageIndex:number){
    this.allotService.getList(pageIndex-1).subscribe(r=>{
      this.altList = r.data;
      this.messageService.info(r.totalCount.toString());
    });
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

  }

  doCheck(): void {
      let ids = this.getCheckedIds();
  }

  checkAll(value: boolean): void {

  }

}
