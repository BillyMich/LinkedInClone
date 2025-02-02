// src/app/services/auth.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { UserLoginDto } from '../../presentation/authentication/models/login-request.model';
import { LocalStorageService } from '../local-storage/local-storage.service';

const apiUrl = environment.apiPath;

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = 'http://localhost:5152/api';

  constructor(
    private http: HttpClient,
    private localStorageService: LocalStorageService
  ) {}

  login(email: string, password: string): Observable<any> {
    const loginRequest = new UserLoginDto(email, password);

    return this.http.post<any>(`${apiUrl}/login`, loginRequest).pipe(
      map((response) => {
        if (response && response.user) {
          localStorage.setItem('currentUser', JSON.stringify(response.user));
        }
        console.log('Login response', response);
        this.localStorageService.saveToken(response.access_token);
        return response;
      })
    );
  }

  register(user: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/register`, user);
  }

  logout(): void {
    localStorage.removeItem('currentUser');
    this.localStorageService.logout();
  }

  getCurrentUser() {
    return this.localStorageService.returnUser();
  }
}
