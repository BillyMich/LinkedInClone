import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LocalStorageService } from './local-storage/local-storage.service';

@Injectable({
  providedIn: 'root',
})
export class DiscussionService {
  private apiUrl = 'http://localhost:5152/api/message';

  constructor(
    private http: HttpClient,
    private localStorageService: LocalStorageService
  ) {}

  private getHeaders(): HttpHeaders {
    const token = this.localStorageService.getUserToken();
    return new HttpHeaders().set('Authorization', `Bearer ${token}`);
  }

  getConversations(): Observable<any[]> {
    const headers = this.getHeaders();
    return this.http.get<any[]>(`${this.apiUrl}/conversations`, { headers });
  }

  getMessages(conversationId: string): Observable<any[]> {
    const headers = this.getHeaders();
    return this.http.get<any[]>(
      `${this.apiUrl}/conversations/${conversationId}/messages`,
      { headers }
    );
  }

  sendMessage(conversationId: string, content: string): Observable<any> {
    const headers = this.getHeaders();
    return this.http.post<any>(
      `${this.apiUrl}/conversations/${conversationId}/messages`,
      { content },
      { headers }
    );
  }
}
