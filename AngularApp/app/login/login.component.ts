import { Component } from '@angular/core'
import { HttpService } from '../services/http.service'
import { Router } from '@angular/router'

@Component({
    selector: 'login',
    template: 
    `<div>
        <label for="userData">Enter user email</label>
        <input type="text" [(ngModel)]="email" required />
    </div>
    <button (click)="getUser()">Sign in</button>
    <div>User: {{email}}</div>`
})
export class LoginComponent {
    private email: string

    constructor(private httpService: HttpService, private router: Router) { }

    getUser() {
        if (this.email != null)
            this.httpService.get(`api/users/${this.email}`)
                .subscribe(data => {
                    localStorage.setItem('login', data.Id)
                    this.router.navigate([{ outlets: { main: ['general', data.Email], login: null } }], { skipLocationChange: true })
                })        
    }
}