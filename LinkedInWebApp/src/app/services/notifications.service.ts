import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NotificationsService {
  private apiUrl = 'http://localhost:5152/api';

  constructor(private http: HttpClient) {}

  getConnectionRequests(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/GetConnectedUsers`);
  }

  acceptConnectionRequest(requestId: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/ChangeStatusOfRequest`, {
      requestId,
      status: 'accepted',
    });
  }

  rejectConnectionRequest(requestId: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/ChangeStatusOfRequest`, {
      requestId,
      status: 'rejected',
    });
  }

  getInterestNotes(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/notifications/interest-notes`);
  }

  getComments(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/notifications/comments`);
  }
}
