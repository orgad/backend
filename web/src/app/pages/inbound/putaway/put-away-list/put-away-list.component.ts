import { Component, OnInit } from '@angular/core';
import { PutAwayService } from 'src/app/services/inbound/put-away/put-away.service';

@Component({
  selector: 'app-put-away-list',
  templateUrl: './put-away-list.component.html',
  styleUrls: ['./put-away-list.component.css']
})
export class PutAwayListComponent implements OnInit {

  ptList : PutAwayModel[];
  total : number;

  listOfDisplayData: QcModel[] = [];
  mapOfCheckedId: { [key: string]: boolean } = {};
  numberOfChecked = 0;
  isCollapse: boolean = true;
  isAllDisplayDataChecked: boolean = true;
  isIndeterminate: boolean = true;

  constructor(private putAwayService:PutAwayService) { }

  ngOnInit() {
    this.getPutAwayList();
  }

  getPutAwayList():void
  {
    this.putAwayService.getPutAwayList().subscribe(
        result=> { 
          this.ptList =  result.data;
          this.total = result.totalCount;
        }
    );
  }

  currentPageDataChange($event: QcModel[]): void {
    this.listOfDisplayData = $event;
    this.refreshStatus();
  }

  refreshStatus(): void {

  }

  checkAll(value: boolean): void {

  }
}
