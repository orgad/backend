import { Injectable } from '@angular/core';
import { WhService } from './wh/wh.service';
import { CustService } from './cust/cust.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BasicDataService {

  constructor(private whService: WhService, private custService: CustService) { }

  public getWhList(): Observable<BasicDataModelResult> {
    return this.whService.getWarehouse();
  }

  public getCustList(): Observable<BasicDataModelResult> {
    return this.custService.getCustList();
  }

  public getBrandList(custId:string): Observable<BasicDataModelResult> {
    return this.custService.getBrandList(custId);
  }
}
