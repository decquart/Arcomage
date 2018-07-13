import {NgModule} from '@angular/core'
import {BrowserModule} from '@angular/platform-browser'
import {FormsModule} from '@angular/forms'
import {HttpModule} from '@angular/http'
import {AppRoutingModule} from './app.routing.module'

import { HttpService } from './services/http.service'

import { AppComponent } from './app.component'
import { LoginComponent } from './login/login.component'



@NgModule({
    imports: [BrowserModule, FormsModule, HttpModule, AppRoutingModule],
    declarations: [AppComponent, LoginComponent],
    providers: [HttpService],
    bootstrap: [AppComponent]
})
export class AppModule {}