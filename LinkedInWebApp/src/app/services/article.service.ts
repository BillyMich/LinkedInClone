import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ArticleService {
  private apiUrl = 'http://localhost:5152/api/post'; 

  constructor(private http: HttpClient) {}

  getArticles(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/GetPosts`);
  }

  createArticle(article: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/CreatePost`, article);
  }

  likeArticle(articleId: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/UpdatePost`, { id: articleId });
  }

  commentArticle(articleId: string, comment: string): Observable<any> {
    const commentDto = {
      postId: articleId,
      content: comment,
    };
    return this.http.post<any>(`${this.apiUrl}/CreatePostComment`, commentDto);
  }

  deleteArticle(articleId: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/DeletePost/${articleId}`, {});
  }
}
