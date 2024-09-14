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
        console.error('Error loading users:', err);
      },
    });
  }

  loadNonConnectedUsers() {
    this.userService.getNonConnectedUsers().subscribe({
      next: (data) => {
        this.nonConnectedUsers = data;
        this.nonConnectedUsers.forEach((user) =>
          this.loadProfilePicture(user.id)
        );
      },
      error: (err) => {
        console.error('Error loading users:', err);
      },
    });
  }

  loadProfilePicture(userId: number) {
    this.profilePictures[userId] =
      this.settingsService.getProfilePictureUrl(userId);
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
    const contactRequest = new NewContactRequestDto(professionalId);

    this.userService.createContactRequest(contactRequest).subscribe({
      next: () => {
        alert('Friend request sent successfully!');
      },
      error: (err) => {
        console.error('Error sending friend request:', err);
        alert('Failed to send friend request. Please try again.');
      },
    });
  }
}
