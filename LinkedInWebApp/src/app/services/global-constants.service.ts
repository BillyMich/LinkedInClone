import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { LocalStorageService } from './local-storage/local-storage.service';
import { GennericGlobalConstantDto } from '../models/gennericGlobalConstan.model';

@Injectable({
  providedIn: 'root',
})
export class GlobalConstantsService {
  private apiUrl = 'http://localhost:5152/api/global-constants'; // Replace with your API URL

  constructor(
    private http: HttpClient,
    private localStorageService: LocalStorageService // Inject the local storage service
  ) {}

  private getHeaders(): HttpHeaders {
    const token = this.localStorageService.getUserToken();
    return new HttpHeaders().set('Authorization', `Bearer ${token}`);
  }

  getProfessionalBranches(): Observable<GennericGlobalConstantDto[]> {
    const headers = this.getHeaders();
    return this.http
      .get<GennericGlobalConstantDto[]>(
        `${this.apiUrl}/GetProfessionalBranches`,
        { headers }
      )
      .pipe(catchError(this.handleError));
  }

  getJobTypes(): Observable<GennericGlobalConstantDto[]> {
    const headers = this.getHeaders();
    return this.http
      .get<GennericGlobalConstantDto[]>(`${this.apiUrl}/GetJobTypes`, {
        headers,
      })
      .pipe(catchError(this.handleError));
  }

  getReactions(): Observable<GennericGlobalConstantDto[]> {
    const headers = this.getHeaders();
    return this.http
      .get<GennericGlobalConstantDto[]>(`${this.apiUrl}/GetReactions`, {
        headers,
      })
      .pipe(catchError(this.handleError));
  }

  getWorkingLocations(): Observable<GennericGlobalConstantDto[]> {
    const headers = this.getHeaders();
    return this.http
      .get<GennericGlobalConstantDto[]>(`${this.apiUrl}/GetWorkingLocations`, {
        headers,
      })
      .pipe(catchError(this.handleError));
  }

  private handleError(error: any): Observable<never> {
    console.error('An error occurred:', error);
    return throwError(error);
  }
}
