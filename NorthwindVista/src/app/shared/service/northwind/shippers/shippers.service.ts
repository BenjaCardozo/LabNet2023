import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ShippersModel } from '../../../models/northwind/shippers/shippersModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ShippersService {

  constructor(private http: HttpClient) { }

  getShippers(): Observable<ShippersModel[]> {
    let endpoint = 'api/shippers';
    return this.http.get<ShippersModel[]>(environment.northwind+ endpoint);
  }

  // getShipperById(shipperId: number): Observable<ShippersModel> {
  //   const url = `${this.apiUrl}/${shipperId}`;
  //   return this.http.get<ShippersModel>(url);
  // }

  // addShipper(shipper: ShippersModel): Observable<ShippersModel> {
  //   return this.http.post<ShippersModel>(this.apiUrl, shipper);
  // }

  // updateShipper(shipperId: number, shipper: ShippersModel): Observable<void> {
  //   const url = `${this.apiUrl}/${shipperId}`;
  //   return this.http.put<void>(url, shipper);
  // }

  // deleteShipper(shipperId: number): Observable<void> {
  //   const url = `${this.apiUrl}/${shipperId}`;
  //   return this.http.delete<void>(url);
  // }
}
