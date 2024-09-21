import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LocalStorageService } from './local-storage/local-storage.service';

@Injectable({
  providedIn: 'root',
})
export class JobService {
  private apiUrl = 'http://localhost:5152/api';

  constructor(
    private http: HttpClient,
    private localStorageService: LocalStorageService
  ) {}

  private getHeaders(): HttpHeaders {
    const token = this.localStorageService.getUserToken();
    return new HttpHeaders().set('Authorization', `Bearer ${token}`);
  }

  getJobListings(): Observable<any[]> {
    const headers = this.getHeaders();
    return this.http.get<any[]>(`${this.apiUrl}/GetAdvertisements`, {
      headers,
    });
  }

  applyForJob(jobId: string): Observable<any> {
    const headers = this.getHeaders();
    return this.http.post<any>(
      `${this.apiUrl}/jobs/${jobId}/apply`,
      {},
      { headers }
    );
  }

  postJob(job: any): Observable<any> {
    const headers = this.getHeaders();
    return this.http.post<any>(`${this.apiUrl}/CreateAdvertisement`, job, {
      headers,
    });
  }

  getJobListingsByProfessionalBranches(branchIds: number[]): Observable<any[]> {
    const headers = this.getHeaders();
    return this.http.post<any[]>(
      `${this.apiUrl}/GetAdvertisementsByProfessionalBranches`,
      branchIds,
      { headers }
    );
  }

  getJobListingsOfUserByStatus(status: number): Observable<any[]> {
    const headers = this.getHeaders();
    return this.http.get<any[]>(
      `${this.apiUrl}/GetAdvertisementsOfUserByStatus/${status}`,
      { headers }
    );
  }

  updateJob(job: any): Observable<boolean> {
    const headers = this.getHeaders();
    return this.http.post<boolean>(`${this.apiUrl}/UpdateAdvertisement`, job, {
      headers,
    });
  }

  deleteJob(jobId: number): Observable<boolean> {
    const headers = this.getHeaders();
    return this.http.post<boolean>(
      `${this.apiUrl}/DeleteAdvertisement/${jobId}`,
      {},
      { headers }
    );
  }
}
