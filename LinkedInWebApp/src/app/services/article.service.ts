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

  createArticle(article: any, file: any): Observable<any> {
    const headers = this.getHeaders();

    // Create FormData object
    const formData: FormData = new FormData();
    formData.append('FreeTxt', article?.freeTxt);
    formData.append('file', file);

    return this.http.post<any>(`${this.apiUrl}/CreatePost`, formData, {
      headers,
    });
  }

  likeArticle(articleId: number): Observable<any> {
    const headers = this.getHeaders();
    return this.http.post<any>(
      `${this.apiUrl}/UpdatePost`,
      { id: articleId },
      { headers }
    );
  }

  commentArticle(articleId: number, comment: string): Observable<any> {
    const headers = this.getHeaders();
    const createPostCommentDto = {
      postId: articleId,
      freeTxt: comment,
    };
    return this.http.post<any>(
      `${this.apiUrl}/CreatePostComment`,
      createPostCommentDto,
      {
        headers,
      }
    );
  }

  deleteArticle(articleId: string): Observable<any> {
    const headers = this.getHeaders();
    return this.http.delete<any>(`${this.apiUrl}/DeletePost/${articleId}`, {
      headers,
    });
  }

  getPostMultimedia(articleId: number): Observable<Blob> {
    const headers = this.getHeaders();
    return this.http.get(`${this.apiUrl}/GetPostMultimedia/${articleId}`, {
      headers,
      responseType: 'blob', // Ensure the response is treated as a binary file
    });
  }
}
