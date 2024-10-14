import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { AuthService } from '../../services/auth-service/auth.service';
import { UserService } from '../../services/user.service';
import { SettingsService } from '../../services/settings.service';
import { GlobalConstantsService } from '../../services/global-constants.service';
import { ExperienceDto } from '../../models/experience.model';
import { EducationDto } from '../../models/education.model';

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
      fullName: new FormControl('', [Validators.required, Validators.minLength(3)]),
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
        experiences.forEach((exp: ExperienceDto) => {
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
        educations.forEach((edu: EducationDto) => {
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

  addExperience(exp?: ExperienceDto) {
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

  addEducation(edu?: EducationDto) {
    const educationGroup = new FormGroup({
      degree: new FormControl(edu ? edu.degree : '', Validators.required),
      institution: new FormControl(edu ? edu.institution : '', Validators.required),
      graduationYear: new FormControl(
        edu ? edu.graduationYear : '',
        [Validators.required, Validators.min(1900), Validators.max(new Date().getFullYear())]
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
    //this.closeModal();
    this.educationForm = new FormGroup({
      degree: new FormControl('', Validators.required),
      institution: new FormControl('', Validators.required),
      graduationYear: new FormControl('', [
        Validators.required,
        Validators.min(1900),
        Validators.max(new Date().getFullYear()),
      ]),
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
      const experienceData: ExperienceDto = {
        Title: formValues.Title,
        FreeTxt: formValues.FreeTxt,
        IsPublic: formValues.IsPublic,
        StartedAt: new Date(formValues.StartedAt).toISOString(),
      };

      if (formValues.EndedAt) {
        experienceData.EndedAt = new Date(formValues.EndedAt).toISOString();
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

  onSubmitEducation() {
    if (this.educationForm.valid) {
      const educationData: EducationDto = this.educationForm.value;
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
    } else {
      console.log('Education form is invalid');
    }
  }
  

  onImageError(event: any) {
    event.target.src = '../../../assets/user-profile-picture.jpg';
  }
  
}
