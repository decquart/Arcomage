import { Card } from "../models/card";
import { Component } from '@angular/core';
import { CardService } from "./card.service";

@Component({
    selector: 'my-card-list',
    templateUrl: './card-list.component.html',
    styleUrls: ['./card-list.component.css']
})

export class CardListComponent{
    cards: Card[];
    selectedCard: Card;
    errorMessage: string;

    constructor(private cardService: CardService){
    }

    select(card: Card){
        this.selectedCard = card;
    }

    useCard(card: Card){
        this.cardService.applyCard(card.name).subscribe(
            selCard => this.selectedCard = selCard,
            error => this.errorMessage = <any>error
        )
        this.cardService.getCards().subscribe(
            cards => this.cards = cards,
            error => this.errorMessage = <any>error
        );
    }
    
    getPlayerCards(){
        this.cardService.getCards().subscribe(
            cards => this.cards = cards,
            error => this.errorMessage = <any>error
        );
    }
 
    ngOnInit(): void{
        this.getPlayerCards();
    }
}