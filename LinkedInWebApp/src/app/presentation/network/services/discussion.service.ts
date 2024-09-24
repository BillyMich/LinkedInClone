import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LocalStorageService } from '../../../services/local-storage/local-storage.service';
import {
  GetChatDto,
  NewMessageDto,
} from '../../discussions/models/message.model';

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
    return this.http.get<any[]>(`${this.apiUrl}/GetChatsOfUser`, { headers });
  }

  getMessages(getChatDto: GetChatDto): Observable<any[]> {
    const headers = this.getHeaders();
    return this.http.post<any[]>(
      `${this.apiUrl}/GetMessageOfChat`,
      getChatDto,
      {
        headers,
      }
    );
  }

  sendMessage(newMessageDto: NewMessageDto): Observable<any> {
    const headers = this.getHeaders();
    return this.http.post<any>(`${this.apiUrl}/CreateMessage`, newMessageDto, {
      headers,
    });
  }
}
