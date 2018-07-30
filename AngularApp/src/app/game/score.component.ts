import { Component, OnInit } from '@angular/core';
import { GameService } from '../services/game.service';
import { SharedService } from '../services/shared.service';
import { THROW_IF_NOT_FOUND } from '../../../node_modules/@angular/core/src/di/injector';


@Component({
    selector: 'score',
    templateUrl: './score.component.html',
    styleUrls: ['./score.component.css']
})

export class ScoreComponent implements OnInit{
    score: number;
    
    constructor(private gameService: GameService, private sharedService: SharedService){
        sharedService.onScoreEvent.subscribe(
            (onScore) => {
              this.score = onScore;
            }
        );
    }
    
    getScores(){
        this.gameService.getPlayerScore().subscribe(
            score => this.score = score
        )
    }

    ngOnInit(): void{
        this.getScores();
    }
}