import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { AuthService } from '../../services/auth-service/auth.service';
import { UserService } from '../../services/user.service';
import { SettingsService } from '../../services/settings.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent implements OnInit {
  profileForm!: FormGroup;
  user: any;
  profilePictureUrl: string | ArrayBuffer | null = null;

  showExperienceModal: boolean = false;
  showEducationModal: boolean = false;

  constructor(
    private authService: AuthService,
    private userService: UserService,
    private settingsService: SettingsService
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
      experience: new FormArray([]),
      education: new FormArray([]),
      skills: new FormArray([]),
    });

    this.loadExistingDetails();
  }

  loadExistingDetails() {
    if (this.user.experience) {
      this.user.experience.forEach((exp: any) => {
        this.addExperience(exp);
      });
    }

    if (this.user.education) {
      this.user.education.forEach((edu: any) => {
        this.addEducation(edu);
      });
    }

    if (this.user.skills) {
      this.user.skills.forEach((skill: any) => {
        this.addSkill(skill);
      });
    }
  }

  get experience(): FormArray {
    return this.profileForm.get('experience') as FormArray;
  }

  get education(): FormArray {
    return this.profileForm.get('education') as FormArray;
  }

  get skills(): FormArray {
    return this.profileForm.get('skills') as FormArray;
  }

  addExperience(exp?: any) {
    const experienceGroup = new FormGroup({
      jobTitle: new FormControl(exp ? exp.jobTitle : '', Validators.required),
      company: new FormControl(exp ? exp.company : '', Validators.required),
    });
    this.experience.push(experienceGroup);
  }

  addEducation(edu?: any) {
    const educationGroup = new FormGroup({
      degree: new FormControl(edu ? edu.degree : '', Validators.required),
      institution: new FormControl(
        edu ? edu.institution : '',
        Validators.required
      ),
    });
    this.education.push(educationGroup);
  }

  addSkill(skill?: any) {
    const skillGroup = new FormGroup({
      name: new FormControl(skill ? skill.name : '', Validators.required),
    });
    this.skills.push(skillGroup);
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

  triggerFileInput() {
    const fileInput = document.getElementById('file-input');
    if (fileInput) {
      fileInput.click();
    }
  }

  onFileChange(event: any) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.profileForm.patchValue({
        profilePicture: file,
      });
      this.settingsService.uploadPhoto(file).subscribe(() => {
        this.loadProfilePicture(); // Reload the profile picture after upload
      });
    }
  }

  openExperienceModal() {
    this.closeModal();
    this.showExperienceModal = true;
  }

  openEducationModal() {
    this.closeModal();
    this.showEducationModal = true;
  }

  closeModal() {
    this.showExperienceModal = false;
    this.showEducationModal = false;
  }

  onSubmit() {}
}
