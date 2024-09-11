import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LocalStorageService } from '../../../services/local-storage/local-storage.service';

@Injectable({
  providedIn: 'root',
})
export class SettingsService {
  private apiUrl = 'http://localhost:5152/api/user'; // Replace with your actual API URL

  constructor(
    private http: HttpClient,
    private localStorageService: LocalStorageService
  ) {}

  private getHeaders(): HttpHeaders {
    const token = this.localStorageService.getUserToken();
    return new HttpHeaders().set('Authorization', `Bearer ${token}`);
  }

  updateSettings(settings: any): Observable<any> {
    const headers = this.getHeaders();
    return this.http.post(`${this.apiUrl}/update`, settings, { headers });
  }

  changeEmailPassword(data: any): Observable<any> {
    const headers = this.getHeaders();
    return this.http.post(`${this.apiUrl}/change-email-password`, data, {
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

  getProfilePictureFromId(id: number): Observable<Blob> {
    const headers = this.getHeaders();
    return this.http.get(`${this.apiUrl}/GetProfilePictureFromId/${id}`, {
      headers,
      responseType: 'blob',
    });
  }
}
