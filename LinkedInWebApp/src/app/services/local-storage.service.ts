import { Injectable } from '@angular/core';
import { User } from '../models/user.model';
import jwt_decode from 'jwt-decode';
const USER_KEY = 'auth-user';


@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  constructor() { }
  clean(): void {
    window.sessionStorage.clear();
  }

  public saveToken(token: any): void {
    window.sessionStorage.removeItem(USER_KEY);
    window.sessionStorage.setItem(USER_KEY,token);
  }

  public getUser(): string | null {
    const user = window.sessionStorage.getItem(USER_KEY);
    if (user) {
      return user;
    }

    return null;
  }

  public logout(): void {
    window.sessionStorage.clear();
  }

  public isLoggedIn(): boolean {
    const user = this.getUser();
    if (user) {
      
      return true;
    }
    return false;
  }

  public returnUser(): User | null
  {
    const token = this.getUser();

    if (!token) {
      return null;
    }

    const user : any = 
    {
      email: JSON.parse(window.atob(token.split('.')[1]))["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"],
      name:  JSON.parse(window.atob(token.split('.')[1]))["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"],
      role:  JSON.parse(window.atob(token.split('.')[1]))["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"],
    };

    return user
  }
  
}