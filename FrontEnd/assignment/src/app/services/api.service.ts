import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable(
  {providedIn: 'root'}
)
export class ApiService {

  private apiURL: string = 'http://localhost:53499/api/v1/';
  private httpOptions = {
      headers: new HttpHeaders({
          'Content-Type': 'application/json'
      })
  };

  constructor(public http: HttpClient) {
  }

  get(endpoint: string, params?: any) {

    return this.http.get(this.apiURL + endpoint, this.httpOptions);
}

post(endpoint: string, body: any) {
    return this.http.post(this.apiURL + endpoint, body, this.httpOptions);
}

put(endpoint: string, body: any) {
    return this.http.put(this.apiURL + endpoint, body, this.httpOptions);
}

delete(endpoint: string) {
    return this.http.delete(this.apiURL + endpoint, this.httpOptions);
}

patch(endpoint: string, body: any) {
    return this.http.put(this.apiURL + endpoint, body, this.httpOptions);
}

}
