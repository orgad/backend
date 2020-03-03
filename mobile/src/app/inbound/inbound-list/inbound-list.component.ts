import { Component, OnInit } from '@angular/core';
import { RcvService } from '../services/rcv.service';

@Component({
  selector: 'app-inbound-list',
  templateUrl: './inbound-list.component.html',
  styleUrls: ['./inbound-list.component.css']
})
export class InboundListComponent implements OnInit {

  list:InboundModel[];

  constructor(private inboundService:RcvService) { }

  ngOnInit() {
    this.getList();
  }

  private getList():void{
    //this.inboundService.getList().subscribe(r=>this.list = r.data);
  }

}
