import { Component, OnInit } from '@angular/core';
import { QcService } from 'src/app/services/inbound/qc/qc.service';

@Component({
  selector: 'app-qc-list',
  templateUrl: './qc-list.component.html',
  styleUrls: ['./qc-list.component.css']
})
export class QcListComponent implements OnInit {

  qcList : QcModel[];
  total : number;

  listOfDisplayData: QcModel[] = [];
  mapOfCheckedId: { [key: string]: boolean } = {};
  numberOfChecked = 0;
  isCollapse: boolean = true;
  isAllDisplayDataChecked: boolean = true;
  isIndeterminate: boolean = true;

  constructor(private qcService:QcService) { }

  ngOnInit() {
    this.getQcList();
  }

  getQcList():void
  {
    this.qcService.getQcList().subscribe(
        result=> { 
          this.qcList =  result.data;
          this.total = result.totalCount;
        }
    );
  }

  currentPageDataChange($event: QcModel[]): void {
    this.listOfDisplayData = $event;
    this.refreshStatus();
  }

  checkAll(value: boolean): void {

  }

  refreshStatus(): void {

  }

}
