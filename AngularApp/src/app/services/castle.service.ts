import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpService } from './http.services';
import { Castle } from '../models/castle';

@Injectable()

export class CastleService{
    private castleUrl = 'https://localhost:44347/api/game/castles/';
    constructor(private httpService: HttpService){

    }

    getCastles(): Observable<Castle[]>{
        return this.httpService.get(this.castleUrl + localStorage.getItem('id')
          );             
      }   
}