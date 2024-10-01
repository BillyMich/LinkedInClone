/*job-listings.components.ts */
import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { AdvertisementDto } from '../../models/advertisement.model';
import { GennericGlobalConstantDto } from '../../../../models/gennericGlobalConstan.model';
import { AdvertisementService } from '../../services/advertisement.service';
import { AuthService } from '../../../../services/auth-service/auth.service';
import { GlobalConstantsService } from '../../../../services/global-constants.service';
import { UserService } from '../../../../services/user.service';
import { SettingsService } from '../../../../services/settings.service';

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
  connectedJobListings: AdvertisementDto[] = [];
  nonConnectedJobListings: AdvertisementDto[] = [];
  connectedUsers: any[] = [];
  profilePictures: { [creatorId: number]: string | null } = {};
  selectedAdvertisement: AdvertisementDto | null = null;
  showPopup: boolean = false;

  constructor(
    private advertisementService: AdvertisementService,
    private authService: AuthService,
    private genericConstantService: GlobalConstantsService,
    private router: Router,
    private settingsService: SettingsService,
    private userService: UserService
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
    this.loadConnectedUsers();
    this.InitPage();
    //this.loadCollaborativeFilteringJobs();
  }

  private loadConnectedUsers() {
    this.userService.getConnectedUsers().subscribe({
      next: (data) => {
        this.connectedUsers = data;
        this.loadJobListings();
      },
      error: (err) => {
        console.error('Error loading connected users:', err);
      },
    });
  }

  private isConnectedUser(jobUserId: number): boolean {
    return this.connectedUsers.some((user) => user.id === jobUserId);
  }

  InitPage() {
    this.loadJobTypes();
    this.loadWorkingLocations();
    this.loadProfesionalBranches();
    this.loadJobListings();
  }
  private loadJobTypes() {
    this.genericConstantService.getJobTypes().subscribe({
      next: (data) => (this.jobTypes = data),
      error: (error) => console.error('Error fetching job types', error),
    });
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

  getStatusLabel(status: number): string {
    switch (status) {
      case 1:
        return 'Draft';
      case 2:
        return 'Published';
      default:
        return 'Unknown';
    }
  }

  viewJob(jobId: number) {}

  toggleJobForm() {
    this.showJobForm = !this.showJobForm;
  }

  private loadProfilePicture(creatorId: number) {
    const profilePictureUrl =
      this.settingsService.getProfilePictureUrl(creatorId);
    this.profilePictures[creatorId] =
      profilePictureUrl || '../../../assets/user-profile-picture.jpg';
  }

  private loadJobListings() {
    this.advertisementService.getJobListings().subscribe({
      next: (data) => {
        console.log('Job listings', data);

        const connectedListings = data.filter((job) =>
          this.isConnectedUser(job.creatorId)
        );
        const nonConnectedListings = data.filter(
          (job) => !this.isConnectedUser(job.creatorId)
        );

        data.forEach((job) => {
          this.loadProfilePicture(job.creatorId);
        });

        this.connectedJobListings = connectedListings.map((job) => ({
          ...job,
          professionalBranche: this.getBranchNameById(job.professionalBranche),
          jobType: this.getJobTypeById(job.jobType),
          workingLocation: this.getWorkingLocationById(job.workingLocation),
        }));

        this.nonConnectedJobListings = nonConnectedListings.map((job) => ({
          ...job,
          professionalBranche: this.getBranchNameById(job.professionalBranche),
          jobType: this.getJobTypeById(job.jobType),
          workingLocation: this.getWorkingLocationById(job.workingLocation),
        }));

        console.log('Connected Job Listings:', this.connectedJobListings);
        console.log(
          'Non-Connected Job Listings:',
          this.nonConnectedJobListings
        );

        if (this.connectedJobListings.length > 0) {
          this.selectedAdvertisement = this.connectedJobListings[0];
        } else if (this.nonConnectedJobListings.length > 0) {
          this.selectedAdvertisement = this.nonConnectedJobListings[0];
        }
      },
      error: (error) => console.error('Error fetching job listings', error),
    });
  }

  onAdvertisementSelect(advertisement: AdvertisementDto) {
    this.selectedAdvertisement = advertisement;
  }

  applyForJob(jobId: number): void {
    this.advertisementService.applyForJob(jobId).subscribe({
      next: () => {
        this.showPopupMessage(); // Show the popup message
      },
      error: (error) => {
        console.error('Error applying for job', error);
      },
    });
  }

  // Method to show the popup message and hide it after 3 seconds
  showPopupMessage(): void {
    this.showPopup = true;
    setTimeout(() => {
      this.showPopup = false;
    }, 3000); // Hide the popup after 3 seconds
  }

  /*
  private loadCollaborativeFilteringJobs() {
    this.advertisementService.getCollaborativeFilteredJobs().subscribe({
      next: (recommendedJobs) => {
        // Append recommended jobs to the non-connected listings
        this.nonConnectedJobListings = [...this.nonConnectedJobListings, ...recommendedJobs];
      },
      error: (error) => console.error('Error fetching recommended jobs', error),
    });
  }
  */
}
