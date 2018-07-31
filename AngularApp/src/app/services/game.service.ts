import { Injectable } from '@angular/core';
import { HttpService } from './http.services';
import { Observable } from 'rxjs/Observable';


@Injectable()

export class GameService{
    private checkWinnerUrl = "https://localhost:44347/api/game/check/";
    private getScoreUrl = "https://localhost:44347/api/game/scores/";
    constructor(private httpService: HttpService){
    }

    getEndGameMessage(): Observable<string>{
        return this.httpService.get(this.checkWinnerUrl + 
            localStorage.getItem('id'));             
      };   

      getPlayerScore(): Observable<number>{
        return this.httpService.get(this.getScoreUrl + 
            localStorage.getItem('id'));
      };

}