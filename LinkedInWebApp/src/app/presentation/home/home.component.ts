import { Component, OnInit } from '@angular/core';
import { ArticleService } from '../../services/article.service';
import { SettingsService } from '../../services/settings.service';
import { Post, Comment } from '../../models/post.model';
import { IdDictionary } from '../../models/profilePictureDictionary.model';
import { AuthService } from '../../services/auth-service/auth.service';
import { LikePostDto } from './models/likePostDto.models';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  posts: Post[] = [];
  newPostContent: string = '';
  newComments: { [postId: number]: string } = {};
  idDictionary: IdDictionary[] = [];
  commentsToShow: { [postId: number]: number } = {};
  file: any;
  profilePictureUrl: string | ArrayBuffer | null = null;
  userName: string | null = '';

  constructor(
    private articleService: ArticleService,
    private authService: AuthService,
    private settingsService: SettingsService
  ) {}

  ngOnInit() {
    const currentUser = this.authService.getCurrentUser();

    if (currentUser && currentUser.name) {
      this.userName = currentUser.name;
      this.loadProfilePicture();
    } else {
      console.error('User is not logged in or invalid user data');
    }
    this.fetchPosts();
  }

  fetchPosts() {
    this.articleService.getArticles().subscribe((data: Post[]) => {
      this.posts = data;
      this.posts.forEach((post) => {
        this.commentsToShow[post.id] = 3;
        this.loadMultimediaForPost(post);
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
      this.articleService
        .createArticle(createPostDto, this.file)
        .subscribe(() => {
          this.fetchPosts();
          this.newPostContent = '';
        });
    }
  }

  onFileChange(event: any) {
    this.file = event.target.files[0];
  }

  onLike(postId: number) {
    const likePostDto: LikePostDto = { postId };
    this.articleService.likeArticle(likePostDto).subscribe(() => {
      this.fetchPosts();
    });
  }

  onCommentSubmit(postId: number) {
    if (this.newComments[postId]) {
      this.articleService
        .commentArticle(postId, this.newComments[postId])
        .subscribe(() => {
          this.fetchPosts();
          this.newComments[postId] = '';
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
      entry.ProfilePictureUrl = this.settingsService.getProfilePictureUrl(
        entry.userId
      );
    });
  }

  getProfilePictureUrlById(userId: number): string | null {
    const entry = this.idDictionary.find((entry) => entry.userId === userId);
    return entry ? entry.ProfilePictureUrl : null;
  }

  loadProfilePicture(): void {
    const currentUser = this.authService.getCurrentUser();
    if (currentUser && currentUser.id) {
      this.profilePictureUrl = this.settingsService.getProfilePictureUrl(
        currentUser.id
      );
    } else {
      console.error('User not found or missing user ID');
    }
  }

  loadMultimediaForPost(post: Post) {
    this.articleService.getPostMultimedia(post.id).subscribe(
      (blob) => {
        if (!blob) {
          return;
        }
        const url = window.URL.createObjectURL(blob);
        console.log('Multimedia loaded for post', post.id, url, blob);
        post.MultimediaType = blob.type;
        post.Multimedia = url;
      },
      (error) => {
        console.error('Error loading multimedia for post', error);
      }
    );
  }

  isImage(mimeType: string): boolean {
    return mimeType.startsWith('image/');
  }

  isVideo(mimeType: string): boolean {
    return mimeType.startsWith('video/');
  }
  onImageError(event: any) {
    event.target.src = '../../../assets/user-profile-picture.png';
  }
}
