import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {
  private apiUrl = 'http://localhost:4200/api'; 

  constructor(private http: HttpClient) {}

  getArticles(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/articles`);
  }

  createArticle(article: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/articles`, article);
  }

  likeArticle(articleId: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/articles/${articleId}/like`, {});
  }

  commentArticle(articleId: string, comment: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/articles/${articleId}/comment`, { comment });
  }
}
