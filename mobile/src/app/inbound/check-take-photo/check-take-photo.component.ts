import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { AsnCheckService } from '../services/asn-check.service';
import { ToastService } from 'ng-zorro-antd-mobile';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-check-take-photo',
  templateUrl: './check-take-photo.component.html',
  styleUrls: ['./check-take-photo.component.css']
})
export class CheckTakePhotoComponent implements OnInit {

  scanForm: FormGroup;
  files: Array<any> = [];
  id:number;
  code: string;

  srcA: string;
  srcB: string;
  src1: string;
  src2: string;
  src3: string;

  constructor(
    private _location:Location,
    private route:ActivatedRoute,
    private asnCheckService: AsnCheckService,
    private _toast: ToastService) { }

  ngOnInit() {
    this.buildForm();
    this.id = this.route.snapshot.params["id"];
    this.code = this.route.snapshot.queryParams["code"];
  }

  buildForm(): void {
    this.scanForm = new FormGroup(
      {
        barcode: new FormControl()
      }
    );
  }

  goBack():void{
    this._location.back();
  }

  onFocus(){

  }

  onReset(){

  }

  onTake(v, e) {
    let file = e.target.files[0];
    this.files.push(file);
    var reader = new FileReader();
    reader.onload = function (e1) {
      let img = document.getElementById(v) as HTMLImageElement;
      img.src = (e1.target as any).result.toString();
    }
    reader.readAsDataURL(file);
  }

  onSubmit(): void {
    this._toast.info("uploading");
    //数据上传
    this.asnCheckService.Save(this.files)
      .subscribe(r => {
        this._toast.info(r.toString());
        console.log(r);
      }
      );
  }
}
