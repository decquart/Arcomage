import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { CardListComponent } from './card/card-list.component';
import { CardService } from './card/card.service';
import {HttpClientModule} from '@angular/common/http';
import { CastleComponent } from './castle/castle.component';
import { CastleService } from './castle/castle.service';
import {RouterModule} from '@angular/router';
import { GameOverComponent } from './game/game-over.component';

@NgModule({
  declarations: [
      CardListComponent, AppComponent, CastleComponent, GameOverComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    RouterModule.forRoot([
      {path: ':id', component: AppComponent},
      {path: 'gameover', component: GameOverComponent},
      {path: '**', redirectTo:'', pathMatch: 'full'}
    ])
  ],
  providers: [CardService, CastleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
