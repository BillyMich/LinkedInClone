import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { NewContactRequestDto } from '../presentation/network/models/network.model';
import { LocalStorageService } from './local-storage/local-storage.service';
import { CreateUserExperience } from '../models/experience.model';
import { CreateUserEducationDto } from '../models/education.model';

@Injectable({
  providedIn: 'root',
})
export class UserService {
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

  getConnectedUsers(): Observable<any[]> {
    const headers = this.getHeaders();

    return this.http.get<any[]>(`${this.apiUrl}/GetConnectedUsers`, {
      headers,
    });
  }

  getNonConnectedUsers(): Observable<any[]> {
    const headers = this.getHeaders();

    return this.http.get<any[]>(`${this.apiUrl}/GetNonConnectedUsers`, {
      headers,
    });
  }

  createContactRequest(contactRequest: NewContactRequestDto): Observable<any> {
    const headers = this.getHeaders();
    return this.http.post<any>(
      `${this.apiUrl}/user/CreateContactRequest`,
      contactRequest,
      { headers }
    );
  }

  changeRequestStatus(requestId: string, status: string): Observable<any> {
    const headers = this.getHeaders();
    return this.http.post<any>(
      `${this.apiUrl}/user/ChangeStatusOfRequest`,
      {
        requestId,
        status,
      },
      { headers }
    );
  }

  updateUser(id: string, user: any): Observable<any> {
    const headers = this.getHeaders();
    return this.http.post<any>(`${this.apiUrl}/user/updateUserSettings`, user, {
      headers,
    });
  }

  getUserById(id: number): Observable<any> {
    const headers = this.getHeaders();
    return this.http.get<any>(`${this.apiUrl}/user/getUser/${id}`, { headers });
  }

  exportUserData(ids: string[], format: string): Observable<Blob> {
    const headers = this.getHeaders();
    const params = ids.map((id) => `ids=${id}`).join('&');
    const url =
      format === 'xml'
        ? `${this.apiUrl}/user/getUsersXML?${params}`
        : `${this.apiUrl}/user/getUsersJson?${params}`;

    return this.http.get(url, {
      headers,
      responseType: 'blob',
    });
  }

  searchProfessionals(query: string): Observable<any[]> {
    const headers = this.getHeaders();
    return this.http.get<any[]>(`${this.apiUrl}/user/searchProfessionals`, {
      headers,
      params: { query },
    });
  }

  getAllUsers(): Observable<any[]> {
    const headers = this.getHeaders();
    return this.http.get<any[]>(`${this.apiUrl}/user/getUsers`, { headers });
  }

  updateUserExperience(experienceData: CreateUserExperience): Observable<any> {
    const headers = this.getHeaders();
    const url = `${this.apiUrl}/user/updateUserExperience`;
    return this.http.post<any>(url, experienceData, { headers });
  }

  updateUserEducation(educationData: CreateUserEducationDto): Observable<any> {
    const headers = this.getHeaders();
    const url = `${this.apiUrl}/user/updateUserEducation`;
    return this.http.post<any>(url, educationData, { headers });
  }

  getUserExperience(userId: number): Observable<CreateUserExperience[]> {
    const headers = this.getHeaders();
    const url = `${this.apiUrl}/user/getUserExperience/${userId}`;
    return this.http.get<CreateUserExperience[]>(url, { headers });
  }

  getUserEducation(userId: number): Observable<CreateUserEducationDto[]> {
    const headers = this.getHeaders();
    const url = `${this.apiUrl}/user/getUserEducation/${userId}`;
    return this.http.get<CreateUserEducationDto[]>(url, { headers });
  }
}
