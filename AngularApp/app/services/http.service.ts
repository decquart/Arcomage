
import { configuration } from '../app.constants'
import { Injectable } from '@angular/core'
import { Http, Response, Headers } from '@angular/http'
import { Observable } from 'rxjs/Observable'
import "rxjs/add/operator/map"
import "rxjs/add/operator/catch"
import "rxjs/add/observable/throw"

@Injectable()
export class HttpService {
    private headers = new Headers({
        'Content-Type': "application/json",
    })

    constructor(private http: Http) {}

    get(url: string): Observable<any> {
        return this.http.get(configuration.baseUrls.server + url, { headers: this.headers })
            .map((resp: Response) => resp.json())
            .catch((error: any) => { return Observable.throw(error) })
    }

    post(url: string, body: string = null) {
        return this.http.post(configuration.baseUrls.server + url,
            (body == null) ? '' : body, { headers: this.headers })
                .map((resp: Response) => resp.json()).subscribe()
    }
}