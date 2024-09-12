// src/app/profile/profile.component.ts
import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth-service/auth.service';
import { UserService } from '../../services/user.service';
import { SettingsService } from '../../services/settings.service'; 
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent implements OnInit {
  profileForm!: FormGroup;
  user: any;
  profilePictureUrl: string | ArrayBuffer | null = null; 

  constructor(
    private authService: AuthService,
    private userService: UserService,
    private settingsService: SettingsService, 
  ) {}

  ngOnInit() {
    const currentUser = this.authService.getCurrentUser();
  
    if (currentUser && currentUser.id) {
      this.userService.getUserById(Number(currentUser.id)).subscribe({
        next: (data) => {
          this.user = data;
          this.initForm();
        },
        error: (error) => {
          console.error('Error fetching user data:', error);
        },
      });
    } else {
      console.error('No valid user found');
    }
  
    this.loadProfilePicture();
  }
  

  initForm() {
    this.profileForm = new FormGroup({
      fullName: new FormControl(this.user.fullName, [
        Validators.required,
        Validators.minLength(3),
      ]),
      email: new FormControl(this.user.email, [
        Validators.required,
        Validators.email,
      ]),
      phone: new FormControl(this.user.phone, [Validators.required]),
      profilePicture: new FormControl(null),
    });
  }
 
  loadProfilePicture(): void {
    this.settingsService.getProfilePictureFromId().subscribe((blob) => {
      const reader = new FileReader();
      reader.onload = (event) => {
        this.profilePictureUrl = event.target!.result; 
      };
      reader.readAsDataURL(blob); 
    });
  }

  onFileChange(event: any) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.profileForm.patchValue({
        profilePicture: file,
      });
    }
  }

  onSubmit() {
    if (this.profileForm.valid) {
      this.userService
        .updateUser(this.user.id, this.profileForm.value)
        .subscribe({
          next: (response) => {
            this.user = response;
          },
          error: (error) => {
            console.error('Update failed', error);
          },
        });
    } else {
      console.log('Form is not valid');
    }
  }
}
