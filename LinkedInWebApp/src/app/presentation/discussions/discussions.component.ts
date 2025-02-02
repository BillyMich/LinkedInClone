import { Component, OnInit, HostListener } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GetChatDto, NewMessageDto } from './models/message.model';
import { SettingsService } from '../../services/settings.service';
import { AuthService } from '../../services/auth-service/auth.service';
import { DiscussionService } from './services/discussion.service';

@Component({
  selector: 'app-discussions',
  templateUrl: './discussions.component.html',
  styleUrls: ['./discussions.component.css'],
})
export class DiscussionsComponent implements OnInit {
  conversations: any[] = [];
  selectedConversation: any = null;
  messages: any[] = [];
  newMessage: string = '';
  userChatingWithId: number = 1;
  profilePictures: { [userId: number]: string | ArrayBuffer | null } = {};
  currentUserId: number = 0;

  constructor(
    private route: ActivatedRoute,
    private discussionService: DiscussionService,
    private settingsService: SettingsService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit() {
    this.Init();
  }

  selectConversation(id: number): void {
    this.router.navigate(['/discussions'], {
      queryParams: { id: id },
    });
  }

  loadMessages() {
    const getChatDto = new GetChatDto(this.userChatingWithId);
    this.discussionService.getMessages(getChatDto).subscribe((data) => {
      this.messages = data;
    });
  }

  checkIfIsSender(senderId: number): boolean {
    return senderId == this.currentUserId;
  }

  sendMessage(): void {
    if (this.newMessage) {
      const newMessageDto = new NewMessageDto(
        this.userChatingWithId,
        this.newMessage
      );
      this.discussionService.sendMessage(newMessageDto).subscribe(() => {
        this.newMessage = '';
        this.loadMessages();
      });
    }
  }

  @HostListener('document:keydown.enter', ['$event'])
  handleEnterKey(event: KeyboardEvent) {
    this.sendMessage();
  }

  onImageError(event: any) {
    event.target.src = '../../../assets/user-profile-picture.jpg';
  }

  private loadCurrentUser() {
    const currentUser = this.authService.getCurrentUser();

    if (currentUser) {
      this.currentUserId = currentUser.id;
    } else {
      console.error('User is not logged in.');
    }
  }

  private Init() {
    this.loadCurrentUser();
    this.loadConversations();
    this.route.queryParams.subscribe((params) => {
      this.userChatingWithId = params['id'];
      if (this.userChatingWithId) {
        this.loadMessages();
      }
    });
  }

  private loadConversations() {
    this.discussionService.getConversations().subscribe({
      next: (data) => {
        this.conversations = data;
        this.conversations.forEach((conversation) =>
          this.loadProfilePicture(conversation.userChatingId)
        );
      },
      error: (err) => {
        console.error('Error loading conversations:', err);
      },
    });
  }

  private loadProfilePicture(userId: number) {
    this.profilePictures[userId] =
      this.settingsService.getProfilePictureUrl(userId);
  }
}
