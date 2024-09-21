import { Component, OnInit, HostListener } from '@angular/core';
import { JobService } from '../../services/job.service';
import { AuthService } from '../../services/auth-service/auth.service';
import { GlobalConstantsService } from '../../services/global-constants.service';
import { GennericGlobalConstantDto } from '../../models/gennericGlobalConstan.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {
  AdvertisementDto,
  NewAdvertisement,
} from '../../models/advertisement.model';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.css'],
})
export class JobsComponent implements OnInit {
  jobListings: AdvertisementDto[] = [];
  user: any;
  newJobForm: FormGroup;
  showJobForm: boolean = false;
  jobTypes: GennericGlobalConstantDto[] = [];
  workingLocations: GennericGlobalConstantDto[] = [];
  profesionalBranches: GennericGlobalConstantDto[] = [];

  constructor(
    private jobService: JobService,
    private authService: AuthService,
    private genericConstantService: GlobalConstantsService,
    private fb: FormBuilder
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
    const branch = this.profesionalBranches.find(
      (branch) => branch.id === branchId
    );
    return branch ? branch.name : '';
  }

  getJobTypeById(jobTypeId: number): string {
    const jobType = this.jobTypes.find((jobType) => jobType.id === jobTypeId);
    return jobType ? jobType.name : '';
  }

  getWorkingLocationById(workingLocationId: number): string {
    const workingLocation = this.workingLocations.find(
      (workingLocation) => workingLocation.id === workingLocationId
    );
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
    this.loadJobListings();
  }

  loadWorkingLocations() {
    this.genericConstantService.getWorkingLocations().subscribe({
      next: (data) => (this.workingLocations = data),
      error: (error) =>
        console.error('Error fetching working locations', error),
    });
  }

  loadProfesionalBranches() {
    this.genericConstantService.getProfessionalBranches().subscribe({
      next: (data) => (this.profesionalBranches = data),
      error: (error) =>
        console.error('Error fetching working locations', error),
    });
  }

  applyForJob(jobId: number) {
    // this.jobService.applyForJob(jobId).subscribe((response) => {
    //   console.log('Applied for job', response);
    // });
  }

  toggleJobForm() {
    this.showJobForm = !this.showJobForm;
  }

  onSubmitNewJob() {
    if (this.newJobForm.valid) {
      const newAdvertisement: NewAdvertisement = this.newJobForm.value;
      this.jobService.postJob(newAdvertisement).subscribe({
        next: (response) => {
          console.log('Advertisement added successfully', response);
          this.loadJobListings();
          this.toggleJobForm();
        },
        error: (error) => console.error('Error adding advertisement', error),
      });
    }
  }

  @HostListener('document:keydown', ['$event'])
  handleKeyDown(event: KeyboardEvent) {
    if (event.key === 'Escape' && this.showJobForm) {
      this.showJobForm = false;
    }
  }

  private loadJobListings() {
    this.jobService.getJobListings().subscribe({
      next: (data) => {
        console.log('Job listings', data, this.profesionalBranches);
        const AdvertisementRequest = data;
        this.jobListings = AdvertisementRequest.map((job) => ({
          ...job,
          professionalBranche: this.getBranchNameById(job.professionalBranche),
          jobType: this.getJobTypeById(job.jobType),
          workingLocation: this.getWorkingLocationById(job.workingLocation),
        }));
      },
      error: (error) => console.error('Error fetching job listings', error),
    });
  }

  private loadJobTypes() {
    this.genericConstantService.getJobTypes().subscribe({
      next: (data) => (this.jobTypes = data),
      error: (error) => console.error('Error fetching job types', error),
    });
  }
}
