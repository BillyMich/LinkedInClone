import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private apiUrl = 'http://localhost:5152/api';

  constructor(private http: HttpClient) {}

  getAllUsers(): Observable<any[]> {
    return this.http.post<any[]>(`${this.apiUrl}/getUsers`, {});
  }

  updateUser(id: string, user: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/update-User-Settings`, user);
  }

  getUserById(id: string): Observable<any> {
    const userId = parseInt(id, 10); // convert to int
    return this.http.post<any>(`${this.apiUrl}/getUser`, { id: userId });
  }

  exportUserData(id: string, format: string): Observable<any> {
    if (format === 'xml') {
      return this.http.get(`${this.apiUrl}/getUsersXML`, {
        params: { id },
        responseType: 'text', 
      });
    } else if (format === 'json') {
      return this.http.get(`${this.apiUrl}/getUsersJson`, {
        params: { id },
        responseType: 'json',
      });
    }
    throw new Error('Invalid format specified');
  }
}
