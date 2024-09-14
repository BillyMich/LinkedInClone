import { Component, OnInit } from '@angular/core';
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

  loadConnectedUsers() {
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

  loadNonConnectedUsers() {
    this.userService.getNonConnectedUsers().subscribe({
      next: (data) => {
        this.nonConnectedUsers = data.filter(user => !this.isConnected(user.id));
        this.nonConnectedUsers.forEach((user) => this.loadProfilePicture(user.id));
      },
      error: (err) => {
        console.error('Error loading non-connected users:', err);
      },
    });
  }
  

  loadProfilePicture(userId: number) {
    this.profilePictures[userId] = this.settingsService.getProfilePictureUrl(userId);
  }

  searchProfessionals() {
    if (this.searchQuery) {
      this.userService.searchProfessionals(this.searchQuery).subscribe({
        next: (data) => {
          this.searchResults = data;
        },
        error: (err) => {
          console.error('Error searching professionals:', err);
        },
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
    this.userService.createContactRequest(new NewContactRequestDto(professionalId)).subscribe({
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
    return this.connectedUsers.some(user => user.id === professionalId);
  }

  deleteFriend(professionalId: number) { // enable when delete is possible
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
  
}
