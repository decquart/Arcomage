import { Component, OnInit, OnDestroy } from '@angular/core'
import { Router } from '@angular/router'

@Component({
    selector: 'card-root',
    template: `
    <div>
        <nav class='navbar navbar-default'>
            <div class='container-fluid'>
                <a class='navbar-brand'>{{pageTitle}}</a>
                <ul class='nav navbar-nav'>
                    <li>Home</li>
                    <li>Product List</li>
                </ul>
            </div>
        </nav>        
     </div>
    `
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