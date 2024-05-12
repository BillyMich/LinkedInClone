import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:????/api'; 

  constructor(private http: HttpClient) { }

  login(email: string, password: string): Observable<any> {
    let url = `${this.apiUrl}/login`;
    let data = {email, password};
    return this.http.post(url,data);
  }

  register(user: any): Observable<any> {
    let url = `${this.apiUrl}/register`;
    return this.http.post(url, user);
  }
  
}
