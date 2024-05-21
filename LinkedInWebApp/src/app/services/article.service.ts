// src/app/services/article.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {
  private apiUrl = 'http://localhost:??/api'; // Adjust as necessary

  constructor(private http: HttpClient) {}

  getArticles(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/articles`);
  }

  likeArticle(articleId: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/articles/${articleId}/like`, {});
  }

  commentArticle(articleId: string, comment: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/articles/${articleId}/comment`, { comment });
  }
}
