import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { catchError } from 'rxjs/operators/catchError';
import { tap } from 'rxjs/operators/tap';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()

export class HttpService{
    constructor(private http: HttpClient){}

    get(url: string): Observable<any>{
        return this.http.get<any>(url).pipe(
        tap(data => console.log('All: ' + JSON.stringify(data))),
          catchError(this.handleError)
        );             
      }

    delete(url: string){
      this.http.delete<any>(url, httpOptions).pipe(
      tap(data => console.log('All: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );     
    }

    private handleError(err: HttpErrorResponse) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        let errorMessage = ``;
        if (err.error instanceof Error) {
          // A client-side or network error occurred. Handle it accordingly.
          errorMessage = `An error occurred: ${err.error.message}`;
        } else {
          // The backend returned an unsuccessful response code.
          // The response body may contain clues as to what went wrong,
          errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
        }
        console.error(errorMessage);
        return Observable.throw(errorMessage);
      }
}