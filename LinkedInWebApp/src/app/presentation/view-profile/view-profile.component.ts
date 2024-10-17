// view-profile.component.ts
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { SettingsService } from '../../services/settings.service';
import { NewContactRequestDto } from '../network/models/network.model';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-view-profile',
  templateUrl: './view-profile.component.html',
  styleUrls: ['./view-profile.component.css'],
})
export class ViewProfileComponent implements OnInit {
  user: any;
  profilePictureUrl: string | ArrayBuffer | null = null;
  experience: any[] = [];
  education: any[] = [];

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
          this.loadExperienceAndEducation(Number(userId));
        },
        error: (err) => {
          console.error('Error loading user:', err);
        },
      });
    }
  }

  loadProfilePicture(userId: string) {
    this.profilePictureUrl = this.settingsService.getProfilePictureUrl(
      Number(userId)
    );
  }

  loadExperienceAndEducation(userId: number) {
    // Load public experiences
    this.userService.getUserExperience(userId).subscribe({
      next: (experiences) => {
        this.experience = experiences.filter((exp: any) => exp.isPublic);
      },
      error: (error) => {
        console.error('Error fetching experiences:', error);
      },
    });

    // Load public educations
    this.userService.getUserEducation(userId).subscribe({
      next: (educations) => {
        this.education = educations.filter((edu: any) => edu.isPublic);
      },
      error: (error) => {
        console.error('Error fetching education:', error);
      },
    });
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

  formatDuration(startDateStr: string, endDateStr?: string): string {
    const startDate = new Date(startDateStr);
    const endDate = endDateStr ? new Date(endDateStr) : new Date();

    const startMonthYear = formatDate(startDate, 'LLLL yyyy', 'el');
    const endMonthYear = endDateStr
      ? formatDate(endDate, 'LLLL yyyy', 'el')
      : 'Σήμερα';

    return `${startMonthYear} - ${endMonthYear}`;
  }
}

