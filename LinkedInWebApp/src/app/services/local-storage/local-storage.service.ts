import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { User } from '../../models/user.model';

const USER_KEY = 'currentUser';

@Injectable({
  providedIn: 'root',
})
export class LocalStorageService {
  constructor(@Inject(PLATFORM_ID) private platformId: Object) {}

  public saveToken(token: any): void {
    if (isPlatformBrowser(this.platformId)) {
      window.sessionStorage.removeItem(USER_KEY);
      window.sessionStorage.setItem(USER_KEY, token);
    }
  }

  getUserToken() {
    if (isPlatformBrowser(this.platformId)) {
      const user = window.sessionStorage.getItem(USER_KEY);
      if (user) {
        return user;
      }
    }
    return null;
  }

  getUser() {
    if (isPlatformBrowser(this.platformId)) {
      const user = window.sessionStorage.getItem(USER_KEY);
      if (user) {
        return user;
      }
    }
    return null;
  }

  public logout(): void {
    window.sessionStorage.clear();
  }

  isLoggedIn() {
    if (isPlatformBrowser(this.platformId)) {
      return !!window.sessionStorage.getItem(USER_KEY);
    }
    return false;
  }
  
  public returnUser(): User | null {
    const token = this.getUserToken();
  
    if (!token) {
      return null;
    }
  
    try {
      const payload = JSON.parse(window.atob(token.split('.')[1]));
      const user: any = {
        id: payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'], 
        email: payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'],
        name: payload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'],
        role: payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'],
      };
  
      return user;
    } catch (e) {
      console.error('Error decoding token', e);
      return null;
    }
  }
  
}
