import { Injectable } from '@angular/core';
import { HttpService } from './http.services';
import { Observable } from 'rxjs/Observable';


@Injectable()

export class GameService{
    private checkWinnerUrl = "https://localhost:44347/api/game/stats/";
    constructor(private httpService: HttpService){
    }

    getWinnerId(): Observable<string>{
        return this.httpService.get(this.checkWinnerUrl + localStorage.getItem('id')
          );             
      }   
}