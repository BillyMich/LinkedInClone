import { Component, OnInit, HostListener } from '@angular/core';
import { JobService } from '../../services/job.service';
import { AuthService } from '../../services/auth-service/auth.service';
import { GlobalConstantsService } from '../../services/global-constants.service';
import { GennericGlobalConstantDto } from '../../models/gennericGlobalConstan.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.css'],
})
export class JobsComponent implements OnInit {
  jobListings: any[] = [];
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
      description: ['', Validators.required],
      profesionalBranche: ['', Validators.required],
      jobType: ['', Validators.required],
      workingLocation: ['', Validators.required],
    });
  }

  ngOnInit() {
    this.user = this.authService.getCurrentUser();
    this.InitPage();
  }

  InitPage() {
    this.loadJobListings();
    this.loadJobTypes();
    this.loadWorkingLocations();
    this.loadProfesionalBranches();
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

  applyForJob(jobId: string) {
    this.jobService.applyForJob(jobId).subscribe((response) => {
      console.log('Applied for job', response);
    });
  }

  toggleJobForm() {
    this.showJobForm = !this.showJobForm;
  }

  postJob() {
    // if (this.newJob.title && this.newJob.description) {
    //   this.jobService.postJob(this.newJob).subscribe((response) => {
    //     console.log('Job posted', response);
    //     this.loadJobListings();
    //     this.newJob = { title: '', description: '', skillsRequired: '' };
    //     this.showJobForm = false;
    //   });
    // }
  }

  onSubmitNewJob() {
    // if (this.newJobForm.valid) {
    //   this.jobService.addJob(this.newJobForm.value).subscribe({
    //     next: (response) => {
    //       console.log('Job added successfully', response);
    //       this.loadJobListings();
    //       this.toggleJobForm();
    //     },
    //     error: (error) => console.error('Error adding job', error),
    //   });
    // }
  }

  @HostListener('document:keydown', ['$event'])
  handleKeyDown(event: KeyboardEvent) {
    if (event.key === 'Escape' && this.showJobForm) {
      this.showJobForm = false;
    }
  }

  private loadJobListings() {
    this.jobService.getJobListings().subscribe({
      next: (data) => (this.jobListings = data),
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
