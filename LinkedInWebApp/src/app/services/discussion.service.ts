import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DiscussionService {
  private apiUrl = 'http://localhost:4200/api'; 

  constructor(private http: HttpClient) {}

  getConversations(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/conversations`);
  }

  getMessages(conversationId: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/conversations/${conversationId}/messages`);
  }

  sendMessage(conversationId: string, content: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/conversations/${conversationId}/messages`, { content });
  }
}
