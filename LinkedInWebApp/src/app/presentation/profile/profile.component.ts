import { Component, OnInit, HostListener } from '@angular/core';
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
  // educationTypes: any[] = []; //αν αυτοματοποιηθούν

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
    // this.loadEducationTypes(); // αν αυτοματοποιηθούν

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
        experiences.forEach((exp: any) => {
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
        educations.forEach((edu: any) => {
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
      error: (error) => console.error('Error fetching working locations', error),
    });
  }

  private loadProfesionalBranches() {
    this.globalConstantsService.getProfessionalBranches().subscribe({
      next: (data) => (this.profesionalBranches = data),
      error: (error) => console.error('Error fetching branches', error),
    });
  }

  // αν αυτοματοιποιηθούν
  /*
  private loadEducationTypes() {
    this.globalConstantsService.getEducationTypes().subscribe({
      next: (data) => (this.educationTypes = data),
      error: (error) => console.error('Error fetching education types', error),
    });
  }
  */

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
      title: new FormControl(exp ? exp.title : '', Validators.required),
      freeTxt: new FormControl(exp ? exp.freeTxt : '', Validators.required),
      isPublic: new FormControl(exp ? exp.isPublic : true, Validators.required),
      startedAt: new FormControl(
        exp && exp.startedAt
          ? this.formatDateFromComponents(exp.startedAt)
          : '',
        Validators.required
      ),
      endedAt: new FormControl(
        exp && exp.endedAt ? this.formatDateFromComponents(exp.endedAt) : ''
      ),
    });
    this.experience.push(experienceGroup);
  }

  addEducation(edu?: any) {
    const educationGroup = new FormGroup({
      name: new FormControl(edu ? edu.name : '', Validators.required),
      description: new FormControl(edu ? edu.description : '', Validators.required),
      isPublic: new FormControl(edu ? edu.isPublic : true, Validators.required),
      educationTypeId: new FormControl(edu ? edu.educationTypeId : 1, Validators.required),
    });
    this.education.push(educationGroup);
  }

  // αν αυτοματοιποιηθούν θα το επαναφέρω
  /*
  getEducationTypeName(id: number): string {
    const type = this.educationTypes.find((et) => et.id === id);
    return type ? type.name : 'Unknown';
  }
  */

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
      title: new FormControl('', Validators.required),
      freeTxt: new FormControl('', Validators.required),
      isPublic: new FormControl(true, Validators.required),
      startedAt: new FormControl('', Validators.required), 
      endedAt: new FormControl(''), 
    });
    this.showExperienceModal = true;
  }
  
  openEducationModal() {
    this.closeModal();
    this.educationForm = new FormGroup({
      name: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
      isPublic: new FormControl(true, Validators.required),
      educationTypeId: new FormControl(1, Validators.required), 
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
        title: formValues.title,
        freeTxt: formValues.freeTxt,
        isPublic: formValues.isPublic,
        startedAt: formValues.startedAt,
        endedAt: formValues.endedAt || null,
      };
  
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
    } else {
      console.log('Experience form is invalid');
    }
  }
  
  
  onSubmitEducation() {
    if (this.educationForm.valid) {
      const formValues = this.educationForm.value;
  
      const educationData: EducationDto = {
        name: formValues.name,
        description: formValues.description,
        isPublic: formValues.isPublic,
        educationTypeId: formValues.educationTypeId,
      };
  
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
  

  private formatDateFromComponents(dateObj: any): string {
    const { year, month, day } = dateObj;
    const monthString = month < 10 ? `0${month}` : month.toString();
    const dayString = day < 10 ? `0${day}` : day.toString();
    return `${year}-${monthString}-${dayString}`;
  }
  onImageError(event: any) {
    event.target.src = '../../../assets/user-profile-picture.jpg';
  }
  

  @HostListener('document:keydown.escape', ['$event'])
  handleEscapeKey(event: KeyboardEvent) {
    this.closeModal();
  }
}
