import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { SettingsService } from '../../services/settings.service';
import { NewContactRequestDto } from '../../models/contactRequest.model';

@Component({
  selector: 'app-view-profile',
  templateUrl: './view-profile.component.html',
  styleUrls: ['./view-profile.component.css'],
})
export class ViewProfileComponent implements OnInit {
  user: any;
  profilePictureUrl: string | ArrayBuffer | null = null;

  constructor(
    private userService: UserService,
    private settingsService: SettingsService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    const userId = this.route.snapshot.paramMap.get('id');
    if (userId) {
      this.userService.getUserById(Number(userId)).subscribe({
        next: (data) => {
          this.user = data;
          this.loadProfilePicture(userId);
        },
        error: (err) => {
          console.error('Error loading user:', err);
        },
      });
    }
  }

  loadProfilePicture(userId: string) {
    this.profilePictureUrl = this.settingsService.getProfilePictureUrl(Number(userId));
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
  onImageError(event: any) {
    event.target.src = '../../../assets/user-profile-picture.jpg';
  }
}
