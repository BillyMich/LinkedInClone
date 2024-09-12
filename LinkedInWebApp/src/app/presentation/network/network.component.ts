import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import { SettingsService } from '../../services/settings.service'; 

@Component({
  selector: 'app-network',
  templateUrl: './network.component.html',
  styleUrls: ['./network.component.css'],
})
export class NetworkComponent implements OnInit {
  allUsers: any[] = [];
  searchResults: any[] = [];
  searchQuery: string = '';
  selectedProfessional: any = null;
  profilePictures: { [userId: number]: string | ArrayBuffer | null } = {}; 

  constructor(private userService: UserService, private router: Router, private settingsService: SettingsService) {}

  ngOnInit() {
    this.loadAllUsers();
  }

  loadAllUsers() {
    this.userService.getAllUsers().subscribe({
      next: (data) => {
        this.allUsers = data;
        this.allUsers.forEach(user => this.loadProfilePicture(user.id));
      },
      error: (err) => {
        console.error('Error loading users:', err);
      },
    });
  }
  
  loadProfilePicture(userId: number) {
    this.settingsService.getProfilePictureFromId(userId).subscribe((blob) => {
      const reader = new FileReader();
      reader.onload = (event) => {
        this.profilePictures[userId] = event.target!.result; 
      };
      reader.readAsDataURL(blob);
    });
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
    this.router.navigate(['/discussions'], { queryParams: { id: professionalId } });
  }

  sendFriendRequest(professionalId: number) {
    this.userService.createContactRequest(professionalId.toString()).subscribe({
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
