import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LocalStorageService } from './local-storage/local-storage.service';

@Injectable({
  providedIn: 'root',
})
export class ArticleService {
  private apiUrl = 'http://localhost:5152/api/post';

  constructor(
    private http: HttpClient,
    private localStorageService: LocalStorageService
  ) {}

  private getHeaders(): HttpHeaders {
    const token = this.localStorageService.getUserToken();
    return new HttpHeaders().set('Authorization', `Bearer ${token}`);
  }

  getArticles(): Observable<any[]> {
    const headers = this.getHeaders();
    return this.http.get<any[]>(`${this.apiUrl}/GetPosts`, { headers });
  }

  createArticle(article: any): Observable<any> {
    const headers = this.getHeaders();
    return this.http.post<any>(`${this.apiUrl}/CreatePost`, article, {
      headers,
    });
  }

  likeArticle(articleId: string): Observable<any> {
    const headers = this.getHeaders();
    return this.http.post<any>(
      `${this.apiUrl}/UpdatePost`,
      { id: articleId },
      { headers }
    );
  }

  commentArticle(articleId: string, comment: string): Observable<any> {
    const headers = this.getHeaders();
    const commentDto = {
      postId: articleId,
      content: comment,
    };
    return this.http.post<any>(`${this.apiUrl}/CreatePostComment`, commentDto, {
      headers,
    });
  }

  deleteArticle(articleId: string): Observable<any> {
    const headers = this.getHeaders();
    return this.http.delete<any>(`${this.apiUrl}/DeletePost/${articleId}`, {
      headers,
    });
  }
}
