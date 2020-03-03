import { Component, OnInit } from '@angular/core';
import { getLodop } from 'src/assets/LodopFuncs.js';

@Component({
  selector: 'app-print',
  templateUrl: './print.component.html',
  styleUrls: ['./print.component.css']
})
export class PrintComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  btnClickPrint():void
  {
    console.log(getLodop);
    getLodop.needCLodop();
    /*
     let LODOP = getLodop();
     LODOP.PRINT_INIT("");
     LODOP.ADD_PRINT_TEXT(50, 231, 260, 39, "打印内容");
     LODOP.PREVIEW();
    */
  }
}
