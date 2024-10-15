import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { AuthService } from '../../services/auth-service/auth.service';
import { UserService } from '../../services/user.service';
import { SettingsService } from '../../services/settings.service';
import { GlobalConstantsService } from '../../services/global-constants.service';
import { CreateUserExperience } from '../../models/experience.model';
import { CreateUserEducationDto } from '../../models/education.model';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent implements OnInit {
  profileForm!: FormGroup;
  experienceForm!: FormGroup;
  educationForm!: FormGroup;
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
    this.profileForm = new FormGroup({
      fullName: new FormControl('', [
        Validators.required,
        Validators.minLength(3),
      ]),
      email: new FormControl('', [Validators.required, Validators.email]),
      phone: new FormControl('', [Validators.required]),
      experience: new FormArray([]),
      education: new FormArray([]),
      skills: new FormArray([]),
    });

    const currentUser = this.authService.getCurrentUser();
    this.loadJobTypes();
    this.loadWorkingLocations();
    this.loadProfesionalBranches();

    if (currentUser && currentUser.id) {
      this.userService.getUserById(Number(currentUser.id)).subscribe({
        next: (data) => {
          this.user = data;
          this.patchFormWithData();
          this.loadExistingDetails();
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

  patchFormWithData() {
    this.profileForm.patchValue({
      fullName: this.user.fullName || '',
      email: this.user.email || '',
      phone: this.user.phone || '',
    });
  }

  loadExistingDetails() {
    this.userService.getUserExperience(this.user.id).subscribe({
      next: (experiences) => {
        this.experience.clear();
        experiences.forEach((exp: CreateUserExperience) => {
          this.addExperience(exp);
        });
      },
      error: (error) => {
        console.error('Error fetching experiences:', error);
      },
    });

    this.userService.getUserEducation(this.user.id).subscribe({
      next: (educations) => {
        console.log('Fetched educations:', educations);
        this.education.clear();
        educations.forEach((edu: CreateUserEducationDto) => {
          this.addEducation(edu);
        });
      },
      error: (error) => {
        console.error('Error fetching education:', error);
      },
    });
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

  addExperience(exp?: CreateUserExperience) {
    const experienceGroup = new FormGroup({
      Title: new FormControl(exp ? exp.Title : '', Validators.required),
      FreeTxt: new FormControl(exp ? exp.FreeTxt : '', Validators.required),
      IsPublic: new FormControl(exp ? exp.IsPublic : true, Validators.required),
      StartedAt: new FormControl(
        exp ? exp.StartedAt.split('T')[0] : '',
        Validators.required
      ),
      EndedAt: new FormControl(
        exp && exp.EndedAt ? exp.EndedAt.split('T')[0] : ''
      ),
    });
    this.experience.push(experienceGroup);
  }

  addEducation(edu?: CreateUserEducationDto) {
    const educationGroup = new FormGroup({
      degreeTitle: new FormControl(
        edu ? edu.degreeTitle : '',
        Validators.required
      ),
      description: new FormControl(
        edu ? edu.description : '',
        Validators.required
      ),
      startDate: new FormControl(edu ? edu.startDate : '', Validators.required),
      endDate: new FormControl(edu ? edu.endDate : ''),
      isPublic: new FormControl(edu ? edu.isPublic : true, Validators.required),
      educationTypeId: new FormControl(
        edu ? edu.educationTypeId : 0,
        Validators.required
      ),
    });
    this.education.push(educationGroup);
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
    }
  }

  openExperienceModal() {
    this.closeModal();
    this.experienceForm = new FormGroup({
      Title: new FormControl('', Validators.required),
      FreeTxt: new FormControl('', Validators.required),
      IsPublic: new FormControl(true, Validators.required),
      StartedAt: new FormControl('', Validators.required),
      EndedAt: new FormControl(''),
    });
    this.showExperienceModal = true;
  }

  openEducationModal() {
    this.educationForm = new FormGroup({
      degreeTitle: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
      startDate: new FormControl('', Validators.required),
      endDate: new FormControl(''),
      isPublic: new FormControl(true, Validators.required),
      educationTypeId: new FormControl(0, Validators.required),
    });
    this.showEducationModal = true;
  }

  closeModal() {
    this.showExperienceModal = false;
    this.showEducationModal = false;
  }

  onSubmitExperience() {
    if (this.experienceForm.valid) {
      const formValues = this.experienceForm.value;
      const experienceData: CreateUserExperience = {
        Title: formValues.Title,
        FreeTxt: formValues.FreeTxt,
        IsPublic: formValues.IsPublic,
        StartedAt: this.formatDateOnly(new Date(formValues.StartedAt)),
      };

      if (formValues.EndedAt) {
        experienceData.EndedAt = this.formatDateOnly(
          new Date(formValues.EndedAt)
        );
      }

      console.log('Submitting Experience Data:', experienceData);

      this.userService.updateUserExperience(experienceData).subscribe({
        next: () => {
          this.loadExistingDetails();
          this.closeModal();
        },
        error: (error) => {
          console.error('Error updating experience:', error);
        },
      });
    }
  }

  private formatDateOnly(date: Date): string {
    const year = date.getFullYear();
    const month = (date.getMonth() + 1).toString().padStart(2, '0');
    const day = date.getDate().toString().padStart(2, '0');
    return `${year}-${month}-${day}`;
  }

  onSubmitEducation() {
    const educationData: CreateUserEducationDto = this.educationForm.value;
    console.log('Submitting Education Data:', educationData);
    this.userService.updateUserEducation(educationData).subscribe({
      next: () => {
        this.loadExistingDetails();
        this.closeModal();
      },
      error: (error) => {
        console.error('Error updating education:', error);
      },
    });
  }

  onImageError(event: any) {
    event.target.src = '../../../assets/user-profile-picture.jpg';
  }
}
