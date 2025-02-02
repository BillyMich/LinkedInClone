import { Component, OnInit, HostListener } from '@angular/core';
import { Router } from '@angular/router';
import {
  AdvertisementDto,
  AdvertisementRequest,
} from '../../models/advertisement.model';
import { AdvertisementService } from '../../services/advertisement.service';
import { GlobalConstantsService } from '../../../../services/global-constants.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-my-advertisements',
  templateUrl: './my-advertisements.component.html',
  styleUrls: ['./my-advertisements.component.css'],
})
export class MyAdvertisementsComponent implements OnInit {
  advertisements: AdvertisementDto[] = [];
  selectedAdvertisement: AdvertisementDto | null = null;
  editForm: FormGroup;
  showEditForm: boolean = false;
  jobTypes: any[] = [];
  workingLocations: any[] = [];
  profesionalBranches: any[] = [];
  applicantsOfSelectedJob: any[] = [];

  constructor(
    private advertisementService: AdvertisementService,
    private router: Router,
    private globalConstantsService: GlobalConstantsService,
    private fb: FormBuilder
  ) {
    this.editForm = this.fb.group({
      title: ['', Validators.required],
      freeTxt: ['', Validators.required],
      professionalBranche: ['', Validators.required],
      jobType: ['', Validators.required],
      workingLocation: ['', Validators.required],
      status: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.loadJobTypes();
    this.loadWorkingLocations();
    this.loadProfesionalBranches();

    this.advertisementService
      .getMyAdvertisement()
      .subscribe((advertisements) => {
        this.advertisements = advertisements.map((ad) => ({
          ...ad,
          professionalBranche: this.getBranchNameById(ad.professionalBranche),
          jobType: this.getJobTypeById(ad.jobType),
          workingLocation: this.getWorkingLocationById(ad.workingLocation),
        }));
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
      (location) => location.id === workingLocationId
    );
    return workingLocation ? workingLocation.name : '';
  }

  onAdvertisementSelect(advertisement: AdvertisementDto): void {
    this.selectedAdvertisement = advertisement;
    this.getApplicantsOfSelectedJob(advertisement.id);
  }

  private getApplicantsOfSelectedJob(jobApplicationId: number) {
    this.advertisementService.approveApplicant(jobApplicationId).subscribe({
      next: (data) => (this.applicantsOfSelectedJob = data),
      error: (error) => console.error('Error fetching applicants', error),
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

  openEditForm(advertisement: AdvertisementDto): void {
    this.advertisementService
      .getJobById(advertisement.id)
      .subscribe((advertisement) => {
        this.selectedAdvertisement = advertisement;

        this.editForm.patchValue({
          title: advertisement.title,
          freeTxt: advertisement.freeTxt,
          professionalBranche: advertisement.professionalBranche,
          jobType: advertisement.jobType,
          workingLocation: advertisement.workingLocation,
          status: advertisement.status,
        });
        this.showEditForm = true;
      });
  }

  closeEditForm(): void {
    this.showEditForm = false;
  }
  onSubmitEditForm(): void {
    if (this.editForm.valid && this.selectedAdvertisement) {
      const updatedAdvertisement: AdvertisementRequest = {
        id: this.selectedAdvertisement.id,
        title: this.editForm.value.title,
        freeTxt: this.editForm.value.freeTxt,
        status: Number(this.editForm.value.status),
        professionalBranche: Number(this.editForm.value.professionalBranche),
        jobType: Number(this.editForm.value.jobType),
        workingLocation: Number(this.editForm.value.workingLocation),
      };

      this.advertisementService.updateJob(updatedAdvertisement).subscribe({
        next: (response) => {
          if (response) {
            this.loadAdvertisements();
            this.closeEditForm();
            window.location.href = window.location.href;
          }
        },
        error: (error) => {
          console.error('Error updating advertisement', error);
        },
      });
    }
  }
  loadAdvertisements(): void {
    this.advertisementService
      .getMyAdvertisement()
      .subscribe((advertisements) => {
        this.advertisements = advertisements;
      });
  }
  @HostListener('document:keydown.escape', ['$event'])
  handleEscapeKey(event: KeyboardEvent): void {
    if (this.showEditForm) {
      this.closeEditForm();
    }
  }
  approveApplicant(applicantId: number): void {
    this.advertisementService.approveApplicant(applicantId).subscribe({
      next: () => {
        if (this.selectedAdvertisement) {
          this.getApplicantsOfSelectedJob(this.selectedAdvertisement.id);
        }
      },
      error: (error) => console.error('Error approving applicant', error),
    });
  }
  
  rejectApplicant(applicantId: number): void {
    
  }
  
}
