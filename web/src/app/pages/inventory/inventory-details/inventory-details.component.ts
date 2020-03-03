import { Component, OnInit } from '@angular/core';
import { InventoryService } from 'src/app/services/inventory/inventory.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-inventory-details',
  templateUrl: './inventory-details.component.html',
  styleUrls: ['./inventory-details.component.css']
})
export class InventoryDetailsComponent implements OnInit {


  sku: string;
  invtDetails : InvtDetailModel[];
  listOfDisplayData: InvtDetailModel[] = [];
  mapOfCheckedId: { [key: string]: boolean } = {}; 
  isCollapse: boolean = true;
  isAllDisplayDataChecked: boolean = true;
  isIndeterminate: boolean = true;

  constructor(private invtService:InventoryService,private route :ActivatedRoute) { }

  ngOnInit() {
    this.sku = this.route.snapshot.params["id"];
    this.getDetails();
  }
   
   private getDetails():void{
    this.invtService.getInvtDetails(this.sku).subscribe(
      result=> {
        this.invtDetails =  result.result.data;
      }
    );
   }

   currentPageDataChange($event: InvtDetailModel[]): void {
    this.listOfDisplayData = $event;
    this.refreshStatus();
  }

  refreshStatus(): void {

  }

  checkAll(value: boolean): void {

  }
  
}
