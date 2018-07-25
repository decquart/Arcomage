import { Card } from "../models/card";
import { Component } from '@angular/core';
import { CardService } from "./card.service";
import { CastleService } from '../castle/castle.service';
import { CastleComponent } from "../castle/castle.component";
import {flatMap} from 'rxjs/operators';
import { Castle } from "../models/castle";
import { SharedService } from "./shared.service";

@Component({
    selector: 'my-card-list',
    templateUrl: './card-list.component.html',
    styleUrls: ['./card-list.component.css']
})

export class CardListComponent{
    cards: Card[];
    errorMessage: string;

    constructor(private cardService: CardService, private castleService: CastleService,
            private sharedService: SharedService){
    }

    useCard(card: Card){
        this.cardService.applyCard(card.name).pipe(flatMap(() => {
            return this.cardService.getCards();
        })).subscribe(
            cards => {this.cards = cards;
                this.castleService.getCastles().subscribe(
                    castles => this.sharedService.onCastleEvent.emit(castles)
                ); 
            },
            error => this.errorMessage = <any>error
        )
    }

    discardCard(card: Card){
        this.cardService.discard(card.name).pipe(flatMap(() => {
            return this.cardService.getCards();
        })).subscribe(
            cards => { 
                this.cards = cards; 
                    this.castleService.getCastles().subscribe(
                       castles => this.sharedService.onCastleEvent.emit(castles)
                    ); 
                },
            error => this.errorMessage = <any>error
        )
    }

    getPlayerCards(){
        return this.cardService.getCards().subscribe(
            cards => this.cards = cards,
            error => this.errorMessage = <any>error
        );
    }
 
    ngOnInit(): void{
        this.getPlayerCards();
    }
}