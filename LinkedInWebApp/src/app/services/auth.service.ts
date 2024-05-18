// src/app/services/auth.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:????/api';

  constructor(private http: HttpClient) {}

  login(email: string, password: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/login`, { email, password })
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
    return this.http.post<any>(`${this.apiUrl}/register`, user)
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
