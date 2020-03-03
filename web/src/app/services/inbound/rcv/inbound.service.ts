import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class InboundService {
  private inboundUrl = '/api/in/inbound/';
  private inboundList = 'list';
  private inboundAdd = 'add?operatorUserName=rickli';
  private inboundDetails = 'details/';
  private check = 'check?operatorUserName=rickli';
  private qc = 'qc?operatorUserName=rickli';
  private putaway = 'putaway?operatorUserName=rickli';

  constructor(private http: HttpClient) { }

  /**
 * Handle Http operation that failed.
 * Let the app continue.
 * @param operation - name of the operation that failed
 * @param result - optional value to return as the observable result
 */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  /** Log a HeroService message with the MessageService */
  private log(message: string) {
    //this.messageService.add(`HeroService: ${message}`);
    console.log("normal message:" + message);
  }

  getList(page: number, whId: number, code: string, bactchNo: string): Observable<InboundModelResult> {
    var url = this.inboundUrl + this.inboundList + "?page=" + page;
    if (code != null) url += "code=" + code;
    if (bactchNo != null) url += "&bactchNo=" + bactchNo;

    return this.http.get<InboundModelResult>(url)
      .pipe(
        tap(_ => this.log(url)),
        catchError(this.handleError<any>('getInboundList', []))
      );;
  }

  setInbound(inbound: InboundModel) {
    var url = this.inboundUrl + this.inboundAdd;
    return this.http.post<InboundModelResult>(url, inbound);
  }

  getInbound(id: number): Observable<InboundResult> {
    var url = this.inboundUrl + this.inboundDetails + id;
    console.log("revDetails:" + url);
    return this.http.get<InboundResult>(url);
  }

  checkInbounds(ids: number[]): Observable<InboundResult> {
    var url = this.inboundUrl + this.check;
    return this.http.put<InboundResult>(url, ids);
  }

  qcInbounds(ids: number[]): Observable<InboundResult> {
    var url = this.inboundUrl + this.qc;
    console.log(url);
    return this.http.put<InboundResult>(url, ids);
  }

  putawayInbounds(ids: number[]): Observable<InboundResult> {
    var url = this.inboundUrl + this.putaway;
    console.log(url);
    return this.http.post<InboundResult>(url, ids);
  }
}
