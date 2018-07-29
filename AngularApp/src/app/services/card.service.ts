import { Card } from '../models/card';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from './http.services';

@Injectable()

export class CardService{
    private cardUrl = 'https://localhost:44347/api/game/';

    constructor(private httpService: HttpService){

    }
    getCards(): Observable<Card[]>{ 
      return this.httpService.get(this.cardUrl + 'cards/' +
       localStorage.getItem('id'));             
    }

    applyCard(cardName: string): Observable<any>{
      return this.httpService.get(this.cardUrl + 'play/' + cardName + '/' +
        localStorage.getItem('id')
        );             
    }

    discard(cardName: string): Observable<any>{
      return this.httpService.get(this.cardUrl + 'discard/' + cardName + '/' +
      localStorage.getItem('id')
        );             
    }
}