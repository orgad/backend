import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AsnCheckService } from '../services/asn-check.service';
import { ToastService } from 'ng-zorro-antd-mobile';
import { Location } from '@angular/common';

@Component({
  selector: 'app-check-update',
  templateUrl: './check-update.component.html',
  styleUrls: ['./check-update.component.css']
})
export class CheckUpdateComponent implements OnInit {

  scanForm: FormGroup;
  id: number;
  code: string;
  asnCheck: AsnCheck = {
    id: 0, code: '', cartonQty: 0, qty: 0, damageCartonQty: 0, damageQty: 0,
    asnBatchNo: null, asnBizCode: null, asnBrandId: 0, asnCartonQty: 0, asnCode: null, asnQty: 0
  };

  constructor(private route: ActivatedRoute,
    private _location: Location,
    private asnCheckService: AsnCheckService,
    private toastService: ToastService) { }

  ngOnInit() {
    this.buildForm();
    this.id = this.route.snapshot.params["id"];
    this.code = this.route.snapshot.queryParams["code"];
    this.getAsnCheck();
  }

  goBack(){
    this._location.back();
  }

  buildForm(): void {
    this.scanForm = new FormGroup(
      {
        cartonQty: new FormControl(),
        qty: new FormControl(),
        damageCartonQty: new FormControl(),
        damageQty: new FormControl()
      }
    );
  }

  getAsnCheck():void{
    this.asnCheckService.get(this.id).subscribe(r=>this.get(r));
  }

  private get(r:AsnCheck){
    this.scanForm.controls["cartonQty"].setValue(r.cartonQty);
    this.scanForm.controls["qty"].setValue(r.qty);
    this.scanForm.controls["damageCartonQty"].setValue(r.damageCartonQty);
    this.scanForm.controls["damageQty"].setValue(r.damageQty);
  }

  update(): void {

    this.asnCheck.cartonQty = this.scanForm.controls["cartonQty"].value;
    this.asnCheck.qty = this.scanForm.controls["qty"].value;
    this.asnCheck.damageCartonQty = this.scanForm.controls["damageCartonQty"].value;
    this.asnCheck.damageQty = this.scanForm.controls["damageQty"].value;

    this.asnCheckService.update(this.id, this.asnCheck)
      .subscribe(r =>
        this.toastService.info(r.toString())
      );
  }

}
