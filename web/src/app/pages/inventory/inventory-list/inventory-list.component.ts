import { Component, OnInit } from '@angular/core';
import { InventoryService } from 'src/app/services/inventory/inventory.service';

@Component({
  selector: 'app-inventory-list',
  templateUrl: './inventory-list.component.html',
  styleUrls: ['./inventory-list.component.css']
})
export class InventoryListComponent implements OnInit {

  invtList:InvtModel[];
  listOfDisplayData: InvtModel[] = [];
  mapOfCheckedId: { [key: string]: boolean } = {};
  isCollapse: boolean = true;
  isAllDisplayDataChecked: boolean = true;
  isIndeterminate: boolean = true;
  
  constructor(private invtService : InventoryService) { }

  ngOnInit() {
     this.getInvtList();
  }

  private getInvtList():void{
    this.invtService.getInvtList().subscribe(
      result=> {
        this.invtList =  result.result.data;
      }
    );
  }

  currentPageDataChange($event: InvtModel[]): void {
    this.listOfDisplayData = $event;
    this.refreshStatus();
  }

  
  refreshStatus(): void {

  }

  checkAll(value: boolean): void {

  }

}
