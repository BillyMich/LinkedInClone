import { Component, OnInit, HostListener } from '@angular/core';
import { AuthService } from '../../services/auth-service/auth.service';
import { GlobalConstantsService } from '../../services/global-constants.service';
import { GennericGlobalConstantDto } from '../../models/gennericGlobalConstan.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AdvertisementDto, NewAdvertisement } from './models/advertisement.model';
import { AdvertisementService } from './services/advertisement.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-jobs',
  templateUrl: './advertisement.component.html',
  styleUrls: ['./advertisement.component.css'],
})
export class AdvertisementComponent implements OnInit {
  jobListings: AdvertisementDto[] = [];
  user: any;
  newJobForm: FormGroup;
  showJobForm: boolean = false;
  jobTypes: GennericGlobalConstantDto[] = [];
  workingLocations: GennericGlobalConstantDto[] = [];
  profesionalBranches: GennericGlobalConstantDto[] = [];

  constructor(
    private advertisementService: AdvertisementService,
    private authService: AuthService,
    private genericConstantService: GlobalConstantsService,
    private fb: FormBuilder,
    private router: Router
  ) {
    this.newJobForm = this.fb.group({
      title: ['', Validators.required],
      freeTxt: ['', Validators.required],
      professionalBranche: ['', Validators.required],
      jobType: ['', Validators.required],
      workingLocation: ['', Validators.required],
      status: ['', Validators.required],
    });
  }

  getBranchNameById(branchId: number): string {
    const branch = this.profesionalBranches.find((branch) => branch.id === branchId);
    return branch ? branch.name : '';
  }

  getJobTypeById(jobTypeId: number): string {
    const jobType = this.jobTypes.find((jobType) => jobType.id === jobTypeId);
    return jobType ? jobType.name : '';
  }

  getWorkingLocationById(workingLocationId: number): string {
    const workingLocation = this.workingLocations.find((workingLocation) => workingLocation.id === workingLocationId);
    return workingLocation ? workingLocation.name : '';
  }

  ngOnInit() {
    this.user = this.authService.getCurrentUser();
    this.InitPage();
  }

  InitPage() {
    this.loadJobTypes();
    this.loadWorkingLocations();
    this.loadProfesionalBranches();
  }

  private loadJobTypes() {
    this.genericConstantService.getJobTypes().subscribe({
      next: (data) => (this.jobTypes = data),
      error: (error) => console.error('Error fetching job types', error),
    });
  }

  private loadWorkingLocations() {
    this.genericConstantService.getWorkingLocations().subscribe({
      next: (data) => (this.workingLocations = data),
      error: (error) => console.error('Error fetching working locations', error),
    });
  }

  private loadProfesionalBranches() {
    this.genericConstantService.getProfessionalBranches().subscribe({
      next: (data) => (this.profesionalBranches = data),
      error: (error) => console.error('Error fetching branches', error),
    });
  }

  toggleJobForm() {
    this.showJobForm = !this.showJobForm;
  }

  onSubmitNewJob() {
    if (this.newJobForm.valid) {
      const newAdvertisement: NewAdvertisement = this.newJobForm.value;
      this.advertisementService.postJob(newAdvertisement).subscribe({
        next: (response) => {
          console.log('Advertisement added successfully', response);
          this.loadJobListings();  
          this.toggleJobForm();
        },
        error: (error) => console.error('Error adding advertisement', error),
      });
      window.location.href = window.location.href;
    }
  }
  navigateToJobListings():void{
    this.router.navigate(['/jobs/advertisements']);
  }
  navigateToMyAdvertisements(): void {
    this.router.navigate(['/jobs/my-advertisements']);
  }

  @HostListener('document:keydown', ['$event'])
  handleKeyDown(event: KeyboardEvent) {
    if (event.key === 'Escape' && this.showJobForm) {
      this.showJobForm = false;
    }
  }

  private loadJobListings() {
    this.advertisementService.getJobListings().subscribe({
      next: (data) => {
        console.log('Job listings', data);
        this.jobListings = data.map((job) => ({
          ...job,
          professionalBranche: this.getBranchNameById(job.professionalBranche),
          jobType: this.getJobTypeById(job.jobType),
          workingLocation: this.getWorkingLocationById(job.workingLocation),
        }));
      },
      error: (error) => console.error('Error fetching job listings', error),
    });
  }
}
