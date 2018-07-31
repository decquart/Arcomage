import { Injectable, EventEmitter,  } from '@angular/core';
import { Castle } from '../models/castle';


@Injectable()

export class SharedService{
    onCastleEvent: EventEmitter<Castle[]> = new EventEmitter();
    onScoreEvent: EventEmitter<number> = new EventEmitter();
}