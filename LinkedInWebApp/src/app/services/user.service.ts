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
    const userId = parseInt(id, 10);
    return this.http.get<any>(`${this.apiUrl}/getUser/${userId}`);
  }

  exportUserData(ids: string[], format: string): Observable<Blob> {
    const params = ids.map(id => `ids=${id}`).join('&');
    const url = format === 'xml' 
      ? `${this.apiUrl}/getUsersXML?${params}` 
      : `${this.apiUrl}/getUsersJson?${params}`;
  
    return this.http.get(url, {
      responseType: 'blob' 
    });
  }
  // eikonika pros to paron
  getConnectedProfessionals(): Observable<any[]> {
    return this.http.post<any[]>(`${this.apiUrl}/getUsers`, {});
  }

  searchProfessionals(query: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/searchProfessionals`, {
      params: { query },
    });
  }
}
