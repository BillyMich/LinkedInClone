import { Component, OnInit, HostListener } from '@angular/core';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { AuthService } from '../../services/auth-service/auth.service';
import { UserService } from '../../services/user.service';
import { SettingsService } from '../../services/settings.service';
import { GlobalConstantsService } from '../../services/global-constants.service';

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
  jobTypes: any[] = [];
  workingLocations: any[] = [];
  profesionalBranches: any[] = [];

  constructor(
    private authService: AuthService,
    private userService: UserService,
    private settingsService: SettingsService,
    private globalConstantsService: GlobalConstantsService
  ) {}

  ngOnInit() {
    const currentUser = this.authService.getCurrentUser();
    this.loadJobTypes();
    this.loadWorkingLocations();
    this.loadProfesionalBranches();

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

  private loadJobTypes() {
    this.globalConstantsService.getJobTypes().subscribe({
      next: (data) => (this.jobTypes = data),
      error: (error) => console.error('Error fetching job types', error),
    });
  }

  private loadWorkingLocations() {
    this.globalConstantsService.getWorkingLocations().subscribe({
      next: (data) => (this.workingLocations = data),
      error: (error) =>
        console.error('Error fetching working locations', error),
    });
  }

  private loadProfesionalBranches() {
    this.globalConstantsService.getProfessionalBranches().subscribe({
      next: (data) => (this.profesionalBranches = data),
      error: (error) => console.error('Error fetching branches', error),
    });
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
    window.location.href = window.location.href;
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
    window.location.href = window.location.href;
  }

  addSkill(skill?: any) {
    const skillGroup = new FormGroup({
      name: new FormControl(skill ? skill.name : '', Validators.required),
    });
    this.skills.push(skillGroup);
    window.location.href = window.location.href;
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
        this.loadProfilePicture();
      });
      window.location.href = window.location.href;
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

  @HostListener('document:keydown', ['$event'])
  handleKeyDown(event: KeyboardEvent) {
    if (event.key === 'Escape') {
      this.closeModal();
    } else if (
      event.key === 'Enter' &&
      (this.showExperienceModal || this.showEducationModal)
    ) {
      this.onSubmit();
    }
  }

  onSubmit() {
    console.log('Form submitted:', this.profileForm.value);
  }

  onImageError(event: any) {
    event.target.src = '../../../assets/user-profile-picture.jpg';
  }
}
