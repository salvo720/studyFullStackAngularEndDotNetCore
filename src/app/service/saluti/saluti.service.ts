import { catchError, map, Observable, throwError } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SalutiService {
  saluti:string;
  error:string
  apiUrl:string

  constructor(private http:HttpClient) {
    this.saluti = '';
    this.error = '';
    this.apiUrl = 'https://localhost:7285/saluti/getsaluti';
  }

  getSaluti():string {
    return "saluti";
  }

  getSalutiObservable(nome:string):Observable<string> {
    return  this.http.get<Observable<string>>(this.apiUrl + '/' + nome).pipe(
      map( (saluti:any) => saluti ),
      catchError(this.handleErrorObs)
    );
  }

  handleErrorObs(error: any): Observable<string> {
    return throwError(error.message || error);
  }

}
