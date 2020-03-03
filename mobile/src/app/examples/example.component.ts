import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-example',
  templateUrl: './example.component.html',
  styleUrls: ['./example.component.css']
})
export class ExampleComponent implements OnInit {

  data: Array<{ id: number, icon: string, text: string }> = [
    { id: 0, icon: "assets/img/all.png", text: "标签页" },
    { id: 1, icon: "assets/img/all.png", text: "列表表单" },
  ];

  constructor(private router:Router) { }

  ngOnInit() {
  }

  click(event): void {
    let val = event.data.id;
    if (val == 0) {
      this.router.navigateByUrl("example/tabbar");
    }
    if (val == 1) {
      this.router.navigateByUrl("example/listform");
    }
    console.log(val);
  }

}
