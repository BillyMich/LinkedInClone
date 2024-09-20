import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SettingsService } from '../../services/settings.service';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth-service/auth.service';
import { UpdateUserSettingsDto } from '../../models/updateUserSettingsDto.model';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css'],
})
export class SettingsComponent implements OnInit {
  settingsForm!: FormGroup;
  emailForm!: FormGroup;
  passwordForm!: FormGroup;
  profilePictureUrl: string | ArrayBuffer | null = null;

  showEmailModal: boolean = false;
  showPasswordModal: boolean = false;
  showChangeProfilePictureModal: boolean = false;
  selectedFile: File | null = null;

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

    this.emailForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
    });

    this.passwordForm = this.fb.group(
      {
        password: ['', [Validators.required, Validators.minLength(8)]],
        confirmPassword: ['', Validators.required],
      },
      { validators: this.passwordMatchValidator }
    );

    this.loadProfilePicture();
  }

  // Password match validator
  passwordMatchValidator(group: FormGroup) {
    return group.get('password')?.value === group.get('confirmPassword')?.value
      ? null
      : { mismatch: true };
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

  openEmailModal() {
    this.closeModal();
    this.showEmailModal = true;
  }

  openPasswordModal() {
    this.closeModal();
    this.showPasswordModal = true;
  }

  openChangeProfilePictureModal() {
    this.closeModal();
    this.showChangeProfilePictureModal = true;
  }

  closeModal() {
    this.showEmailModal = false;
    this.showPasswordModal = false;
    this.showChangeProfilePictureModal = false;
  }

  onChangeEmail(): void {
    if (this.emailForm.valid) {
      const updateUserSettings: UpdateUserSettingsDto = {
        email: this.emailForm.value.email,
        oldPassword: undefined,
        password: undefined,
      };

      this.settingsService.changeEmailPassword(updateUserSettings).subscribe({
        next: () => this.closeModal(),
        error: (error) => console.error('Error changing email', error),
      });
    }
  }

  onChangePassword(): void {
    if (this.passwordForm.valid) {
      const updateUserSettings: UpdateUserSettingsDto = {
        email: undefined,
        oldPassword: this.passwordForm.value.oldPassword,
        password: this.passwordForm.value.password,
      };

      this.settingsService.changeEmailPassword(updateUserSettings).subscribe({
        next: () => this.closeModal(),
        error: (error) => console.error('Error changing password', error),
      });
    }
  }

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
  }

  onSubmitProfilePicture() {
    if (this.selectedFile) {
      this.settingsService.uploadPhoto(this.selectedFile).subscribe({
        next: (response) => {
          console.log('File uploaded successfully', response);
          this.closeModal();
        },
        error: (error) => {
          console.error('Error uploading file', error);
        },
      });
      this.closeModal();
    }
  }

  onSignOut() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
