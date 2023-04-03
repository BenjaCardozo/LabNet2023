import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { ShippersModel } from '../../models/shippers/shippers.model';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ShippersService {

  private shippersUrl: string = environment.northwind + 'api/shippers/';

  constructor(private http: HttpClient) { }

  getShippers(): Observable<ShippersModel[]> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this.http.get<ShippersModel[]>(this.shippersUrl, { headers: headers })
    .pipe(
      catchError(this.errorHandler)
    )
  }

  getShipperById(shipperId: number): Observable<ShippersModel> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this.http.get<ShippersModel>(this.shippersUrl + shipperId, { headers: headers })
    .pipe(
      catchError(this.errorHandler)
    )
  }

   addShipper(shipper: ShippersModel): Observable<ShippersModel> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this.http.post<ShippersModel>(this.shippersUrl, shipper, { headers: headers })
    .pipe(
      catchError(this.errorHandler)
    )
   }

   updateShipper(shipperId: number, shipper: ShippersModel): Observable<void> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this.http.put<void>(this.shippersUrl + shipperId, shipper, { headers: headers })
    .pipe(
      catchError(this.errorHandler)
    )
   }

   deleteShipper(shipperId: number | null): Observable<void> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this.http.delete<void>(this.shippersUrl+ shipperId, { headers: headers })
    .pipe(
      catchError(this.errorHandler)
    )
   }

  errorHandler(error:any) {
    let errorMessage = '';
    if(error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(()=>errorMessage);
  }
}
