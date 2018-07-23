import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'game',
    templateUrl: './game.component.html',
})

export class GameComponent{
    private id: string;

    constructor(private route: ActivatedRoute){
        
    }

    ngOnInit(): void{
        this.id = location.pathname.slice(6,location.pathname.length);
        localStorage.setItem('id', this.id);
        console.log(localStorage.getItem('id'));
      }
}