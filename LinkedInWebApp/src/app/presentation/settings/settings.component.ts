import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SettingsService } from '../../services/settings.service';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth-service/auth.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css'],
})
export class SettingsComponent implements OnInit {
  settingsForm!: FormGroup;
  emailPasswordForm!: FormGroup;
  photoForm!: FormGroup;
  profilePictureUrl: string | ArrayBuffer | null = null;

  constructor(
    private fb: FormBuilder,
    private settingsService: SettingsService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.settingsForm = this.fb.group({
      notification: [false],
    });

    this.emailPasswordForm = this.fb.group({
      email: [''],
      password: [''],
    });

    this.photoForm = this.fb.group({
      photo: [null],
    });

    this.loadProfilePicture();
  }

  loadProfilePicture(): void {
    const currentUser = this.authService.getCurrentUser(); 
    
    if (currentUser && currentUser.id) { 
      this.settingsService.getProfilePictureFromId(currentUser.id).subscribe((blob) => { 
        const reader = new FileReader();
        reader.onload = (event) => {
          this.profilePictureUrl = event.target!.result;
        };
        reader.readAsDataURL(blob);
      }, (error) => {
        console.error('Error loading profile picture:', error);
      });
    } else {
      console.error('User not found or missing user ID');
    }
  }
  

  onSubmit(): void {
    this.settingsService.updateSettings(this.settingsForm.value).subscribe();
  }

  onChangeEmailPassword(): void {
    this.settingsService
      .changeEmailPassword(this.emailPasswordForm.value)
      .subscribe();
  }

  onUploadPhoto(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      const file = input.files[0];
      this.settingsService.uploadPhoto(file).subscribe(() => {
        this.loadProfilePicture(); // Reload the profile picture after upload
      });
    }
  }

  onSignOut() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
