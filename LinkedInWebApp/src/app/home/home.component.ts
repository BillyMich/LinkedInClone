// src/app/home/home.component.ts
import { Component, OnInit } from '@angular/core';
import { ArticleService } from '../services/article.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  posts: any[] = [];
  newPostContent: string = '';
  newComment: string = '';

  constructor(private articleService: ArticleService) {}

  ngOnInit() {
    this.fetchPosts();
  }

  fetchPosts() {
    this.articleService.getArticles().subscribe((data: any[]) => {
      this.posts = data;
    });
  }

  onPostSubmit() {
    if (this.newPostContent) {
      const newPost = {
        content: this.newPostContent,
        mediaUrls: [] // media handling
      };
      this.articleService.createArticle(newPost).subscribe(() => {
        this.fetchPosts();
        this.newPostContent = '';
      });
    }
  }

  onFileChange(event: any) {
    // file handling 
  }

  onLike(postId: string) {
    this.articleService.likeArticle(postId).subscribe(() => {
      this.fetchPosts();
    });
  }

  onCommentSubmit(postId: string) {
    if (this.newComment) {
      this.articleService.commentArticle(postId, this.newComment).subscribe(() => {
        this.fetchPosts();
        this.newComment = '';
      });
    }
  }
}
