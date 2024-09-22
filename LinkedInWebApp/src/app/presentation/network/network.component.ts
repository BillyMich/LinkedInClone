import { Component, OnInit, HostListener } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import { SettingsService } from '../../services/settings.service';
import { NewContactRequestDto } from '../../models/contactRequest.model';

@Component({
  selector: 'app-network',
  templateUrl: './network.component.html',
  styleUrls: ['./network.component.css'],
})
export class NetworkComponent implements OnInit {
  connectedUsers: any[] = [];
  nonConnectedUsers: any[] = [];
  searchResults: any[] = [];
  searchQuery: string = '';
  selectedProfessional: any = null;
  profilePictures: { [userId: number]: string | ArrayBuffer | null } = {};

  constructor(
    private userService: UserService,
    private router: Router,
    private settingsService: SettingsService
  ) {}

  ngOnInit() {
    this.loadConnectedUsers();
    this.loadNonConnectedUsers();
  }

  searchProfessionals() {
    if (this.searchQuery.trim()) {
      this.searchResults = this.nonConnectedUsers.filter((user) => {
        const fullName = `${user.name} ${user.surname}`.toLowerCase();
        return fullName.includes(this.searchQuery.toLowerCase());
      });
    } else {
      this.searchResults = [];
    }
  }

  viewProfile(professional: any) {
    this.selectedProfessional = professional;
  }

  startPrivateChat(professionalId: string) {
    this.router.navigate(['/discussions'], {
      queryParams: { id: professionalId },
    });
  }

  sendFriendRequest(professionalId: number) {
    this.userService
      .createContactRequest(new NewContactRequestDto(professionalId))
      .subscribe({
        next: () => {
          alert('Friend request sent successfully!');
        },
        error: (err) => {
          console.error('Error sending friend request:', err);
          alert('Failed to send friend request. Please try again.');
        },
      });
  }

  isConnected(professionalId: number): boolean {
    return this.connectedUsers.some((user) => user.id === professionalId);
  }

  deleteFriend(professionalId: number) {
    // enable when delete is possible
    /* this.userService.deleteContact(professionalId).subscribe({
      next: () => {
        alert('Friend removed successfully!');
        // Refresh connected and non-connected users
        this.loadConnectedUsers();
        this.loadNonConnectedUsers();
      },
      error: (err) => {
        console.error('Error deleting friend:', err);
        alert('Failed to remove friend. Please try again.');
      },
    });
    */
  }

  closeProfileViewer() {
    this.selectedProfessional = null;
  }

  @HostListener('document:keydown', ['$event']) onKeyDown(
    event: KeyboardEvent
  ) {
    if (event.key === 'Escape') {
      this.closeProfileViewer();
    }
  }

  private loadProfilePicture(userId: number) {
    const profilePictureUrl = this.settingsService.getProfilePictureUrl(userId);
    
    this.profilePictures[userId] = profilePictureUrl || '../../../assets/user-profile-picture.jpg';
  }
  

  private loadConnectedUsers() {
    this.userService.getConnectedUsers().subscribe({
      next: (data) => {
        this.connectedUsers = data;
        this.connectedUsers.forEach((user) => this.loadProfilePicture(user.id));
      },
      error: (err) => {
        console.error('Error loading connected users:', err);
      },
    });
  }

  private loadNonConnectedUsers() {
    this.userService.getNonConnectedUsers().subscribe({
      next: (data) => {
        this.nonConnectedUsers = data.filter(
          (user) => !this.isConnected(user.id)
        );
        this.nonConnectedUsers.forEach((user) =>
          this.loadProfilePicture(user.id)
        );
      },
      error: (err) => {
        console.error('Error loading non-connected users:', err);
      },
    });
  }
  onImageError(event: any) {
    event.target.src = '../../../assets/user-profile-picture.jpg';
  }
  navigateToProfile(professionalId: number) {
    this.router.navigate(['/view-profile', professionalId]);
  }
}
