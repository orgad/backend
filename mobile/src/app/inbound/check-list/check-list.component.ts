import { Component, OnInit } from '@angular/core';
import { AsnCheckService } from '../services/asn-check.service';
import {Location} from '@angular/common';

@Component({
  selector: 'app-check-list',
  templateUrl: './check-list.component.html',
  styleUrls: ['./check-list.component.css']
})
export class CheckListComponent implements OnInit {

  constructor(
    private _location:Location,
    private asnCheckService:AsnCheckService) { }

  list : AsnCheckModel[];

  ngOnInit() {
    this.getList();
  }

  goBack():void{
    this._location.back();
  }
   
  private getList():void{
      this.asnCheckService.list().subscribe(
        r=> {
          this.list = r.data;
          //console.log(this.list);
        }
      );
  }

}
