import { Component, Input } from '@angular/core';
import { Castle } from '../models/castle';
import { CastleService } from "./castle.service";
import { SharedService } from '../card/shared.service';



@Component({
    selector: 'castle',
    templateUrl: './castle.component.html',
    styleUrls: ['./castle.component.css']
})

export class CastleComponent{
    castles: Castle[];
    errorMessage: string;
   
    constructor(private castleService: CastleService, private sharedService: SharedService){
        sharedService.onCastleEvent.subscribe(
            (onCastle) => {
              this.castles = onCastle;
            }
        );
    }

    getCastles(){
        this.castleService.getCastles().subscribe(
            castles => this.castles = castles,
            error => this.errorMessage = <any>error
        );
    }        

    ngOnInit(): void{
        this.getCastles();
    } 
}