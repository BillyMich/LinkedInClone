import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { AdvertisementDto } from '../../models/advertisement.model';
import { GennericGlobalConstantDto } from '../../../../models/gennericGlobalConstan.model';
import { AdvertisementService } from '../../services/advertisement.service';
import { AuthService } from '../../../../services/auth-service/auth.service';
import { GlobalConstantsService } from '../../../../services/global-constants.service';

@Component({
  selector: 'app-job-listings',
  templateUrl: './job-listings.component.html',
  styleUrls: ['./job-listings.component.css'],
})
export class JobListingsComponent {
  jobListings: AdvertisementDto[] = [];
  user: any;
  showJobForm: boolean = false;
  jobTypes: GennericGlobalConstantDto[] = [];
  workingLocations: GennericGlobalConstantDto[] = [];
  profesionalBranches: GennericGlobalConstantDto[] = [];

  constructor(
    private advertisementService: AdvertisementService,
    private authService: AuthService,
    private genericConstantService: GlobalConstantsService,
    private router: Router
  ) {}

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

  viewJob(jobId: number) {}

  toggleJobForm() {
    this.showJobForm = !this.showJobForm;
  }

  private loadJobListings() {
    this.advertisementService.getJobListings().subscribe({
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
