import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LocalStorageService } from './local-storage/local-storage.service';
import { UpdateUserSettingsDto } from '../models/updateUserSettingsDto.model';

@Injectable({
  providedIn: 'root',
})
export class SettingsService {
  private apiUrl = 'http://localhost:5152/api/user';

  constructor(
    private http: HttpClient,
    private localStorageService: LocalStorageService
  ) {}

  private getHeaders(): HttpHeaders {
    const token = this.localStorageService.getUserToken();
    return new HttpHeaders().set('Authorization', `Bearer ${token}`);
  }

  changeEmailPassword(data: UpdateUserSettingsDto): Observable<any> {
    const headers = this.getHeaders();
    return this.http.post(`${this.apiUrl}/updateUserSettings`, data, {
      headers,
    });
  }

  uploadPhoto(file: File): Observable<any> {
    const headers = this.getHeaders();
    const formData = new FormData();
    formData.append('file', file);
    return this.http.post(`${this.apiUrl}/updateProfilePicture`, formData, {
      headers,
    });
  }

  // Update this method to return a direct URL for the profile picture
  getProfilePictureUrl(userId: number): string {
    return `${this.apiUrl}/GetProfilePictureFromId/${userId}`;
  }
}
