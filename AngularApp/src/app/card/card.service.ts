import { Card } from '../models/card';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable()

export class CardService{
    private cardUrl = 'https://localhost:44347/api/game/';
    constructor(private http: HttpClient){

    }
    getCards(): Observable<Card[]>{
      return this.http.get<Card[]>(this.cardUrl + 'cards').pipe(
        tap(data => console.log('All: ' + JSON.stringify(data))),
          catchError(this.handleError)
        );             
    }

    applyCard(cardName: string): Observable<Card>{
      return this.http.get(this.cardUrl + 'play/' + cardName).pipe(
        tap(data => console.log('All: ' + JSON.stringify(data))),
          catchError(this.handleError)
        );             
    }

    discard(cardName: string): Observable<Card>{
      return this.http.get(this.cardUrl + 'discard/' + cardName).pipe(
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