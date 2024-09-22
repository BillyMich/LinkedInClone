import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LocalStorageService } from './local-storage/local-storage.service';
import { UpdateUserSettingsDto } from '../models/updateUserSettingsDto.model';
import { AppConfig } from '../config/app-config';

@Injectable({
  providedIn: 'root',
})
export class SettingsService {
  private apiUrl = `${AppConfig.apiUrl}/user`;
  private readonly updateUserSettings = `${this.apiUrl}/updateUserSettings`;
  private readonly updateProfilePicture = `${this.apiUrl}/updateProfilePicture`;
  private readonly getProfilePictureFromId = `${this.apiUrl}/GetProfilePictureFromId`;

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
    return this.http.post(this.updateUserSettings, data, {
      headers,
    });
  }

  uploadPhoto(file: File): Observable<any> {
    const headers = this.getHeaders();
    const formData = new FormData();
    formData.append('file', file);
    return this.http.post(this.updateProfilePicture, formData, {
      headers,
    });
  }

  getProfilePictureUrl(userId: number): string {
    return `${this.getProfilePictureFromId}/${userId}`;
  }
}
