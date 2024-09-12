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
export class HomeComponent implements OnInit {
  posts: Post[] = [];
  newPostContent: string = '';
  newComment: string = '';
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
      this.posts = data;
      this.posts.forEach((post) => {
        this.commentsToShow[post.id] = 3; // Initialize to show 5 comments for each post
      });
      this.loadProfilePictureOfPostAndComments(this.posts);
    });
  }

  loadMoreComments(postId: number) {
    this.commentsToShow[postId] += 3; // Increase the number of comments to show by 5
  }

  onPostSubmit() {
    console.log('Submitting post:', this.newPostContent);
    if (this.newPostContent) {
      const createPostDto = {
        freeTxt: this.newPostContent,
      };
      this.articleService.createArticle(createPostDto, this.file).subscribe(
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
    this.file = event.target.files[0];
  }

  onLike(postId: number) {
    this.articleService.likeArticle(postId).subscribe(() => {
      this.fetchPosts();
    });
  }

  onCommentSubmit(postId: number) {
    if (this.newComment) {
      this.articleService
        .commentArticle(postId, this.newComment)
        .subscribe(() => {
          this.fetchPosts();
          this.newComment = '';
        });
    }
  }

  loadProfilePictureOfPostAndComments(posts: Post[]): void {
    posts.forEach((post) => {
      // Add post creator ID to dictionary if not already present
      if (!this.idDictionary.some((entry) => entry.userId === post.creatorId)) {
        this.idDictionary.push({
          userId: post.creatorId,
          ProfilePictureUrl: null,
        });
      }

      // Add comment creator IDs to dictionary if not already present
      post.comments.forEach((comment) => {
        if (
          !this.idDictionary.some((entry) => entry.userId === comment.creatorId)
        ) {
          this.idDictionary.push({
            userId: comment.creatorId,
            ProfilePictureUrl: null,
          });
        }
      });
    });

    this.idDictionary.forEach((entry) => {
      this.settingsService
        .getProfilePictureById(entry.userId)
        .subscribe((blob) => {
          const reader = new FileReader();
          reader.onload = (event) => {
            entry.ProfilePictureUrl = event.target!.result;
          };
          reader.readAsDataURL(blob);
        });
    });
  }

  getProfilePictureUrlById(userId: number): string | null {
    const entry = this.idDictionary.find((entry) => entry.userId === userId);
    return entry ? entry.ProfilePictureUrl : null;
  }
}
