import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'root',
  templateUrl: './app.component.html' , 
})
export class AppComponent implements OnInit {
  title = 'Arcomage';
  private id: string;

  constructor(private route: ActivatedRoute){ 
    
  }

  ngOnInit(): void{
    this.id = location.pathname.slice(1,location.pathname.length);
    localStorage.setItem('id', this.id);
    console.log(localStorage.getItem('id'));
  }   
}
