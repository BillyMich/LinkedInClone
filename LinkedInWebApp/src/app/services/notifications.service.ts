import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LocalStorageService } from './local-storage/local-storage.service';
import { ContactRequestChangeStatusDto } from '../presentation/network/models/network.model';
import {
  ContactRequestOfUserDto,
  PostNotificationDto,
} from '../presentation/notifications/models/notification.models';

@Injectable({
  providedIn: 'root',
})
export class NotificationsService {
  private apiUrl = 'http://localhost:5152/api';

  constructor(
    private http: HttpClient,
    private localStorageService: LocalStorageService
  ) {}

  private getHeaders(): HttpHeaders {
    const token = this.localStorageService.getUserToken();
    return new HttpHeaders({
      Authorization: `Bearer ${token}`,
      'Content-Type': 'application/json',
    });
  }

  getConnectionRequests(): Observable<ContactRequestOfUserDto> {
    const headers = this.getHeaders();
    return this.http.get<ContactRequestOfUserDto>(
      `${this.apiUrl}/getPendingConnectContacts`,
      { headers }
    );
  }

  acceptConnectionRequest(
    changeStatusRequest: ContactRequestChangeStatusDto
  ): Observable<any> {
    const headers = this.getHeaders();
    return this.http.post<any>(
      `${this.apiUrl}/ChangeStatusOfRequest`,
      changeStatusRequest,
      { headers }
    );
  }

  getInterestNotes(): Observable<any[]> {
    const headers = this.getHeaders();
    return this.http.get<any[]>(
      `${this.apiUrl}/GetApplyApplicantsNotification`,
      {
        headers,
      }
    );
  }

  getComments(): Observable<PostNotificationDto> {
    const headers = this.getHeaders();
    return this.http.get<PostNotificationDto>(
      `${this.apiUrl}/post/GetNotificationInPost`,
      {
        headers,
      }
    );
  }
}
