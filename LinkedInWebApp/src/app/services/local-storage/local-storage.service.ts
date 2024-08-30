import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { User } from '../../models/user.model';

const USER_KEY = 'auth-user';
const TOKEN_KEY = 'auth-token'; 

@Injectable({
  providedIn: 'root',
})
export class LocalStorageService {
  constructor(@Inject(PLATFORM_ID) private platformId: Object) {}

  public saveToken(token: string): void {
    if (isPlatformBrowser(this.platformId)) {
      window.sessionStorage.removeItem(TOKEN_KEY);
      window.sessionStorage.setItem(TOKEN_KEY, token);
    }
  }

  public getToken(): string | null {
    if (isPlatformBrowser(this.platformId)) {
      return window.sessionStorage.getItem(TOKEN_KEY);
    }
    return null;
  }

  public removeToken(): void {
    if (isPlatformBrowser(this.platformId)) {
      window.sessionStorage.removeItem(TOKEN_KEY);
    }
  }

  public saveUser(user: string): void {
    if (isPlatformBrowser(this.platformId)) {
      window.sessionStorage.removeItem(USER_KEY);
      window.sessionStorage.setItem(USER_KEY, user);
    }
  }

  public getUser(): string | null {
    if (isPlatformBrowser(this.platformId)) {
      return window.sessionStorage.getItem(USER_KEY);
    }
    return null;
  }

  public clearSession(): void {
    if (isPlatformBrowser(this.platformId)) {
      window.sessionStorage.clear();
    }
  }

  public isLoggedIn(): boolean {
    if (isPlatformBrowser(this.platformId)) {
      return !!window.sessionStorage.getItem(USER_KEY);
    }
    return false;
  }

  public returnUser(): User | null {
    const token = this.getToken();

    if (!token) {
      return null;
    }

    const user: any = {
      email: JSON.parse(window.atob(token.split('.')[1]))[
        'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'
      ],
      name: JSON.parse(window.atob(token.split('.')[1]))[
        'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'
      ],
      role: JSON.parse(window.atob(token.split('.')[1]))[
        'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
      ],
    };

    return user;
  }
}
