import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { CardListComponent } from './card/card-list.component';
import { CardService } from './card/card.service';
import {HttpClientModule} from '@angular/common/http';

@NgModule({
  declarations: [
      CardListComponent, AppComponent
  ],
  imports: [
    BrowserModule, HttpClientModule
  ],
  providers: [CardService],
  bootstrap: [AppComponent]
})
export class AppModule { }
