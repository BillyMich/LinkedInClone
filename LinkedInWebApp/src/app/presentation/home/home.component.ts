import { Component, OnInit } from '@angular/core';
import { ArticleService } from '../../services/article.service'; // Using ArticleService
import { SettingsService } from '../../services/settings.service';
import { Post, Comment } from '../../models/post.model';
import { IdDictionary } from '../../models/profilePictureDictionary.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
// Inside your HomeComponent

export class HomeComponent implements OnInit {
  posts: Post[] = [];
  newPostContent: string = '';
  newComments: { [postId: number]: string } = {}; // A dictionary to track new comments per post
  idDictionary: IdDictionary[] = [];
  commentsToShow: { [postId: number]: number } = {}; // Track comments to show for each post
  file: any;

  constructor(
    private articleService: ArticleService,
    private settingsService: SettingsService
  ) {}

  ngOnInit() {
    this.fetchPosts();
  }

  fetchPosts() {
    this.articleService.getArticles().subscribe((data: Post[]) => {
      this.posts = data.sort((a, b) => new Date(b.createdAt).getTime() - new Date(a.createdAt).getTime());
      this.posts.forEach((post) => {
        this.commentsToShow[post.id] = 3;
      });
      this.loadProfilePictureOfPostAndComments(this.posts);
    });
  }

  loadMoreComments(postId: number) {
    this.commentsToShow[postId] += 3;
  }

  onPostSubmit() {
    if (this.newPostContent) {
      const createPostDto = {
        freeTxt: this.newPostContent,
      };
      this.articleService.createArticle(createPostDto, this.file).subscribe(() => {
        this.fetchPosts();
        this.newPostContent = '';
      });
    }
  }

  onFileChange(event: any) {
    this.file = event.target.files[0];
  }

  onLike(postId: number) {
    this.articleService.likeArticle(postId).subscribe(() => {
      this.fetchPosts();
    });
  }

  onCommentSubmit(postId: number) {
    if (this.newComments[postId]) {
      this.articleService.commentArticle(postId, this.newComments[postId]).subscribe(() => {
        this.fetchPosts();
        this.newComments[postId] = ''; // Clear the comment after submission
      });
    }
  }

  loadProfilePictureOfPostAndComments(posts: Post[]): void {
    posts.forEach((post) => {
      if (!this.idDictionary.some((entry) => entry.userId === post.creatorId)) {
        this.idDictionary.push({
          userId: post.creatorId,
          ProfilePictureUrl: null,
        });
      }
      post.comments.forEach((comment) => {
        if (!this.idDictionary.some((entry) => entry.userId === comment.creatorId)) {
          this.idDictionary.push({
            userId: comment.creatorId,
            ProfilePictureUrl: null,
          });
        }
      });
    });

    this.idDictionary.forEach((entry) => {
      entry.ProfilePictureUrl = this.settingsService.getProfilePictureUrl(entry.userId);
    });
  }

  getProfilePictureUrlById(userId: number): string | null {
    const entry = this.idDictionary.find((entry) => entry.userId === userId);
    return entry ? entry.ProfilePictureUrl : null;
  }

}
