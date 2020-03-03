import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { RcvService } from '../services/rcv.service';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-rcv-scan',
  templateUrl: './rcv-scan.component.html',
  styleUrls: ['./rcv-scan.component.css']
})
export class RcvScanComponent implements OnInit {

  scanForm: FormGroup;
  inboundId: string;

  onFocus: object = {
    focus: false
  };

  constructor(private rcvService: RcvService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.buildForm();
    this.inboundId = this.route.snapshot.params["id"];
  }

  onSubmit(): void {
    let barcode = this.scanForm.controls["barcode"].value;
    this.rcvService.saveInboudDetail(this.inboundId, barcode).subscribe(r =>
      console.log(r));
  }

  buildForm(): void {
    this.scanForm = new FormGroup(
      {
        carton: new FormControl(),
        barcode: new FormControl()
      }
    );
  }

}
