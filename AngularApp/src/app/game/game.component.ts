import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'game',
    templateUrl: './game.component.html',
    styleUrls: ['./game.component.css']
})

export class GameComponent implements OnInit{
    private id: string;

    constructor(private route: ActivatedRoute){
        
    }

    ngOnInit(): void{
        this.id = location.pathname.slice(6,location.pathname.length);
        localStorage.setItem('id', this.id);
        console.log(localStorage.getItem('id'));
      }
}