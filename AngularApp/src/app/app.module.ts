import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { CardListComponent } from './card/card-list.component';
import {HttpClientModule} from '@angular/common/http';
import { CastleComponent } from './castle/castle.component';
import {RouterModule} from '@angular/router'; 
import { GameOverComponent } from './game/game-over.component';
import { GameComponent } from './game/game.component';
import { HttpService } from './services/http.services';
import { SharedService } from './services/shared.service';
import { CardService } from './services/card.service';
import { CastleService } from './services/castle.service';

@NgModule({
  declarations: [
      CardListComponent, AppComponent, CastleComponent, GameOverComponent, 
      GameComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    RouterModule.forRoot([
      {path: 'gameover', component: GameOverComponent},
      {path: 'game/:id', component: GameComponent},
      {path: '**', redirectTo:'', pathMatch: 'full'}
    ])
  ],
  providers: [CardService, CastleService, SharedService, HttpService],
  bootstrap: [AppComponent]
})
export class AppModule { }
