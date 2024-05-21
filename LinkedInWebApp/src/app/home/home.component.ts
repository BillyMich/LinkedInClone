// src/app/home/home.component.ts
import { Component, OnInit } from '@angular/core';
import { ArticleService } from '../services/article.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  articles: any[] = [];

  constructor(private articleService: ArticleService) {}

  ngOnInit() {
    this.articleService.getArticles().subscribe((data: any[]) => {
      this.articles = data;
    });
  }

  likeArticle(articleId: string) {
    this.articleService.likeArticle(articleId).subscribe((response) => {
      console.log('Article liked', response);
      // Update the article in the articles array
    });
  }

  commentArticle(articleId: string, comment: string) {
    this.articleService.commentArticle(articleId, comment).subscribe((response) => {
      console.log('Comment added', response);
      // Update the article in the articles array
    });
  }
}
