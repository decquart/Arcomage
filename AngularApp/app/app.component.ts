import { Component, OnInit, OnDestroy } from '@angular/core'
import { Router } from '@angular/router'

@Component({
    selector: 'app',
    template: 
    `<router-outlet name='login'></router-outlet>
     <router-outlet name='main'></router-outlet>
     <router-outlet></router-outlet>`
})
export class AppComponent implements OnInit, OnDestroy {
    constructor(private router: Router) {}

    ngOnInit() {
        this.router.navigate(
            [{ outlets: { main: null, login: ['login'] } }], { skipLocationChange: true })
    }

    ngOnDestroy() {
        localStorage.removeItem('login')
    }
}