import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class JobService {
  private apiUrl = 'http://localhost:5152/api'; 

  constructor(private http: HttpClient) {}

  getJobListings(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/jobs`);
  }

  applyForJob(jobId: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/jobs/${jobId}/apply`, {});
  }

  postJob(job: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/jobs`, job);
  }
}
