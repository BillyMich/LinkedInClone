// src/app/services/user.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private apiUrl = 'http://localhost:5152/api';

  constructor(private http: HttpClient) {}

  getConnectedUsers(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/user/GetConnectedUsers`);
  }

  createContactRequest(targetUserId: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/CreateContactRequest`, {
      targetUserId,
    });
  }

  changeRequestStatus(requestId: string, status: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/user/ChangeStatusOfRequest`, {
      requestId,
      status,
    });
  }

  updateUser(id: string, user: any): Observable<any> {
    return this.http.post<any>(
      `${this.apiUrl}/user/update-User-Settings`,
      user
    );
  }

  getUserById(id: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/user/getUser/${id}`);
  }

  exportUserData(ids: string[], format: string): Observable<Blob> {
    const params = ids.map((id) => `ids=${id}`).join('&');
    const url =
      format === 'xml'
        ? `${this.apiUrl}/user/getUsersXML?${params}`
        : `${this.apiUrl}/user/getUsersJson?${params}`;

    return this.http.get(url, {
      responseType: 'blob',
    });
  }

  searchProfessionals(query: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/searchProfessionals`, {
      params: { query },
    });
  }

  getAllUsers(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/user/getUsers`);
  }
}
