// src/app/profile/profile.component.ts
import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth-service/auth.service';
import { UserService } from '../../services/user.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent implements OnInit {
  profileForm!: FormGroup;
  user: any;

  constructor(
    private authService: AuthService,
    private userService: UserService,
  ) {}

  ngOnInit() {
    const currentUser = this.authService.getCurrentUser();
    this.userService.getUserById(currentUser.id).subscribe((data) => {
      this.user = data;
      this.initForm();
    });
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
