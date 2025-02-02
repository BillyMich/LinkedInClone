import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserService } from '../../../../services/user.service';
import { SettingsService } from '../../../../services/settings.service';  

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css'],
})
export class UserProfileComponent implements OnInit {
  user: any = {};
  editMode = false;
  profileForm!: FormGroup;
  profilePictureUrl: string | ArrayBuffer | null = null;  

  constructor(
    private route: ActivatedRoute,
    private userService: UserService,
    private settingsService: SettingsService  
  ) {}

  ngOnInit() {
    const userId = this.route.snapshot.paramMap.get('id')!;
    console.log('Fetching data for user ID:', userId);
    this.userService.getUserById(Number(userId)).subscribe({
      next: (data: any) => {
        if (data) {
          this.user = data;
          console.log('User data:', this.user);
          this.initForm();
          this.loadProfilePicture(Number(userId)); 
        } else {
          console.error('User data is null or undefined');
        }
      },
      error: (error) => {
        console.error('Error fetching user:', error);
      },
    });
  }

  initForm() {
    this.profileForm = new FormGroup({
      fullName: new FormControl(this.user.name, [
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

  private loadProfilePicture(userId: number) {
    const profilePictureUrl = this.settingsService.getProfilePictureUrl(userId);
    this.profilePictureUrl =
      profilePictureUrl || '../../../assets/user-profile-picture.jpg';
  }

  toggleEditMode() {
    this.editMode = !this.editMode;
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
          next: (response: any) => {
            this.user = response;
            this.editMode = false;
            console.log('User profile updated successfully:', this.user);
          },
          error: (error: any) => {
            console.error('Update failed', error);
          },
        });
    } else {
      console.log('Form is not valid');
    }
  }

  onImageError(event: any) {
    event.target.src = '../../../assets/user-profile-picture.jpg';
  }
}
