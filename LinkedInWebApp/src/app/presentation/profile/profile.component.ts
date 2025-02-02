import { Component, OnInit, HostListener } from '@angular/core';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { AuthService } from '../../services/auth-service/auth.service';
import { UserService } from '../../services/user.service';
import { SettingsService } from '../../services/settings.service';
import { GlobalConstantsService } from '../../services/global-constants.service';
import { CreateUserExperience } from '../../models/experience.model';
import { CreateUserEducationDto } from '../../models/education.model';
import { formatDate } from '@angular/common';

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
    private globalConstantsService: GlobalConstantsService,
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

  addExperience(exp?: CreateUserExperience) {
    const experienceGroup = new FormGroup({
      title: new FormControl(exp ? exp.title : '', Validators.required),
      freeTxt: new FormControl(exp ? exp.freeTxt : '', Validators.required),
      isPublic: new FormControl(exp ? exp.isPublic : true, Validators.required),
      startedAt: new FormControl(
        exp && exp.startedAt ? exp.startedAt : '',
        Validators.required
      ),
      endedAt: new FormControl(
        exp && exp.endedAt ? exp.endedAt : ''
      ),
    });
    this.experience.push(experienceGroup);
  }
  

  private formatDateFromComponents(dateObj: any): string {
    const { year, month, day } = dateObj;
    const monthString = month < 10 ? `0${month}` : month.toString();
    const dayString = day < 10 ? `0${day}` : day.toString();
    return `${year}-${monthString}-${dayString}`;
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
      startDate: new FormControl(
        edu && edu.startDate ? edu.startDate : '',
        Validators.required
      ),
      endDate: new FormControl(
        edu && edu.endDate ? edu.endDate : ''
      ),
      isPublic: new FormControl(edu ? edu.isPublic : true, Validators.required),
      educationTypeId: new FormControl(
        edu ? edu.educationTypeId : null,
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
      title: new FormControl('', Validators.required),
      freeTxt: new FormControl('', Validators.required),
      isPublic: new FormControl(true, Validators.required),
      startedAt: new FormControl('', Validators.required),
      endedAt: new FormControl(''),
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
      educationTypeId: new FormControl(null, Validators.required),
    });
    this.showEducationModal = true;
  }

  closeModal() {
    this.showExperienceModal = false;
    this.showEducationModal = false;
  }

  onSubmitExperience(): void {
    const formValues = this.experienceForm.value;
    const experienceData: CreateUserExperience = {
      title: formValues.title,
      freeTxt: formValues.freeTxt,
      isPublic: formValues.isPublic,
      startedAt: this.formatDateOnly(new Date(formValues.startedAt)),
      endedAt: formValues.endedAt
        ? this.formatDateOnly(new Date(formValues.endedAt))
        : undefined,
    };
  
    this.userService.updateUserExperience(experienceData).subscribe({
      next: (response) => {
        console.log('Experience created successfully', response);
        this.loadExistingDetails(); 
        this.closeModal(); 
      },
      error: (error) => {
        console.error('Error creating experience', error);
      },
    });
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

  formatDuration(startDateStr: string, endDateStr?: string): string {
    const startDate = new Date(startDateStr);
    const endDate = endDateStr ? new Date(endDateStr) : new Date();
  
    const startMonthYear = formatDate(startDate, 'LLLL yyyy', 'el');
    const endMonthYear = endDateStr
      ? formatDate(endDate, 'LLLL yyyy', 'el')
      : 'Σήμερα';
  
    return `${startMonthYear} - ${endMonthYear}`;
  }
  
}
