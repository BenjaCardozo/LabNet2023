import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { CategoriesModel } from '../../../models/northwind/categories/categories.model';
import { environment } from '../../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  private categoriesUrl: string = environment.northwind + 'api/categories/'

  constructor(private http: HttpClient) { }

  getCategories(): Observable<CategoriesModel[]> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this.http.get<CategoriesModel[]>(this.categoriesUrl, { headers: headers })
    .pipe(
      catchError(this.errorHandler)
    )
  }

  getCategoriesById(categoryId: number): Observable<CategoriesModel> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this.http.get<CategoriesModel>(this.categoriesUrl + categoryId, { headers: headers })
    .pipe(
      catchError(this.errorHandler)
    )
  }

  addCategory(category: CategoriesModel): Observable<CategoriesModel> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this.http.post<CategoriesModel>(this.categoriesUrl, category, { headers: headers })
    .pipe(
      catchError(this.errorHandler)
    )
  }

  updateCategory(categoryId: number, category: CategoriesModel): Observable<void> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this.http.put<void>(this.categoriesUrl + categoryId, category, { headers: headers })
    .pipe(
      catchError(this.errorHandler)
    )
  }

  deleteCategory(categoryId: number): Observable<void> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this.http.delete<void>(this.categoriesUrl + categoryId, { headers: headers })
    .pipe (
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
