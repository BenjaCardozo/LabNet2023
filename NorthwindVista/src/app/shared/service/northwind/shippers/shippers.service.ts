import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { ShippersModel } from 'src/app/shared/models/northwind/shippers/shippersModel';
import { environment } from '../../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ShippersService {
  private shippersUrl: string = environment.northwind + 'api/shippers/';

  constructor(private http: HttpClient) { }

  getShippers(): Observable<ShippersModel[]> {
    return this.http.get<ShippersModel[]>(this.shippersUrl)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  getShipperById(shipperId: number): Observable<ShippersModel> {
    return this.http.get<ShippersModel>(this.shippersUrl + shipperId)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  getShipperByString(companyName: string | null): Observable<ShippersModel[]>{
    return this.http.get<ShippersModel[]>(this.shippersUrl + 'GetShippersByString/' + {companyName})
    .pipe(
      catchError(this.errorHandler)
    )
  }

   addShipper(shipper: ShippersModel): Observable<ShippersModel> {
     return this.http.post<ShippersModel>(this.shippersUrl, shipper)
     .pipe(
       catchError(this.errorHandler)
     )
   }

   updateShipper(shipperId: number, shipper: ShippersModel): Observable<void> {
     return this.http.put<void>(this.shippersUrl + shipperId, shipper)
     .pipe(
       catchError(this.errorHandler)
     )
   }

   deleteShipper(shipperId: number| null): Observable<void> {
     return this.http.delete<void>(this.shippersUrl+ shipperId)
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
