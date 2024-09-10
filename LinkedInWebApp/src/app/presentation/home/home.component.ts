import { Component, OnInit } from '@angular/core';
import { ArticleService } from '../../services/article.service'; // Using ArticleService

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
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
    console.log('Submitting post:', this.newPostContent); 
    if (this.newPostContent) {
      const newPost = {
        content: this.newPostContent,
        mediaUrls: [], 
      };
      this.articleService.createArticle(newPost).subscribe(
        () => {
          this.fetchPosts(); 
          this.newPostContent = '';
        },
        (error) => {
          console.error('Error creating post:', error); 
        }
      );
    }
  }
  
  onFileChange(event: any) {
    const files = event.target.files;
    console.log('Selected files:', files); 
   
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
