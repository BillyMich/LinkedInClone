// src/app/services/auth.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { LoginRequest } from '../models/login-request.model';


const apiUrl = environment.apiPath;

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) {}

  login(email: string, password: string): Observable<any> {

    const loginRequest = new LoginRequest(email, password);

    return this.http.post<any>(`${apiUrl}/login`, {loginRequest})
      .pipe(
        map(response => {
          // successful login
          return response;
        }),
        catchError(error => {
          //  login error
          console.error('Login error', error);
          return of(null);
        })
      );
  }

  register(user: any): Observable<any> {
    return this.http.post<any>(`${apiUrl}/register`, user)
      .pipe(
        map(response => {
          // successful registration
          return response;
        }),
        catchError(error => {
          // registration error
          console.error('Registration error', error);
          return of(null);
        })
      );
  }
}
