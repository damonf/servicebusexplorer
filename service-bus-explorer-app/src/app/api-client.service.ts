import { Injectable } from '@angular/core';
import { Http, RequestOptionsArgs, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ApiClientService {

  constructor(private http: Http) { }

  get(url: string, options?: RequestOptionsArgs):  Observable<Response> {
    return this.http.get(url, options);
  }
}
