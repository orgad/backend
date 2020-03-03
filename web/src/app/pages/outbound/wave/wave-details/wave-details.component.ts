import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { NzMessageService, NzConfigService } from 'ng-zorro-antd';
import { ActivatedRoute } from '@angular/router';
import { WaveService } from 'src/app/services/outbound/wave/wave.service';
import { PickService } from 'src/app/services/outbound/pick/pick.service';

@Component({
  selector: 'app-wave-details',
  templateUrl: './wave-details.component.html',
  styleUrls: ['./wave-details.component.css']
})
export class WaveDetailsComponent implements OnInit {

  whs : BasicData[];
  headerForm: FormGroup;
  id:number;
  entity:WaveModel={   id: 0,
    whId: 0,
    size: "",
    skuCatQty: 0,
    skuQty: 0,
    code: "",
    createdBy: "",
    createdTime: null,
    lastModifiedBy: "",
    lastModifiedTime: null,};
  details:PickingModel[];
  waveCode:string;

  constructor(private fb:FormBuilder,private messageService:NzMessageService, private route:ActivatedRoute,
    private waveService:WaveService,private pickService:PickService) {
    this.headerForm = fb.group(["headerForm"]);
   }

  ngOnInit() {
    this.initDetailsForm();
    this.id= this.route.snapshot.params["id"];
    this.getEntity();
  }

  initDetailsForm():void{
    this.headerForm.addControl("ctrl_whId",new FormControl());
    this.headerForm.addControl("ctrl_custId",new FormControl());
    this.headerForm.addControl("ctrl_brandId",new FormControl());
    this.headerForm.addControl("ctrl_code",new FormControl());
    this.headerForm.addControl("ctrl_batchNo",new FormControl());
    this.headerForm.addControl("ctrl_refNo",new FormControl());
    this.headerForm.addControl("ctrl_bizCode",new FormControl());
    this.headerForm.addControl("ctrl_goodsType",new FormControl());
    this.headerForm.addControl("ctrl_invoiceNo",new FormControl());
    this.headerForm.addControl("ctrl_isCiq",new FormControl());
  }

  private getEntity(){
    this.waveService.getList(0,this.id).subscribe(r=>{
      this.entity = r.result.data[0];
      this.waveCode = this.entity.code;
      this.getDetails(this.waveCode);
      this.messageService.info("getEntity:"+r.success.toString());
    });
  }

  private getDetails(waveCode:string){
  this.pickService.getList(0,waveCode).subscribe(r=>{
      this.details = r.result.data;
      this.messageService.info(r.success.toString());
    });
 }
}
