import { Component, OnInit } from '@angular/core';
import { FormControl, FormBuilder, FormGroup } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd';
import { WaveService } from 'src/app/services/outbound/wave/wave.service';

@Component({
  selector: 'app-wave-list',
  templateUrl: './wave-list.component.html',
  styleUrls: ['./wave-list.component.css']
})
export class WaveListComponent implements OnInit {

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
  list: WaveModel[];

  constructor(private fb: FormBuilder, private messageService: NzMessageService,
    private waveService:WaveService) {
    this.queryForm = this.fb.group(["queryForm"]);
  }

  ngOnInit() {
    this.initQueryForm();
  }

  initQueryForm(): void {

    this.controlArray= [];

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
    this.resetStatus();
  }

  getList(pageIndex:number){
    return this.waveService.getList(pageIndex-1,0).subscribe(
      item=>{this.list = item.result.data;
        this.total=item.result.totalCount;
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
    this.messageService.info("refresh");
  }

  resetStatus():void{
    this.listOfDisplayData.forEach(item => this.mapOfCheckedId[item.id] = false);
  }

  doCheck(): void {
    let ids = this.getCheckedIds();
  }

  checkAll(value: boolean): void {

  }

}
