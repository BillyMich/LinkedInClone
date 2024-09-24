import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdvertisementDto } from '../../models/advertisement.model';
import { AdvertisementService } from '../../services/advertisement.service';
import { GlobalConstantsService } from '../../../../services/global-constants.service';

@Component({
  selector: 'app-my-advertisements',
  templateUrl: './my-advertisements.component.html',
  styleUrls: ['./my-advertisements.component.css'],
})
export class MyAdvertisementsComponent implements OnInit {
  advertisements: AdvertisementDto[] = [];
  jobTypes: any[] = [];
  workingLocations: any[] = [];
  profesionalBranches: any[] = [];

  constructor(
    private advertisementService: AdvertisementService,
    private router: Router,
    private globalConstantsService: GlobalConstantsService
  ) {}

  ngOnInit(): void {
    this.loadJobTypes();
    this.loadWorkingLocations();
    this.loadProfesionalBranches();

    this.advertisementService.getMyAdvertisement().subscribe((advertisements) => {
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
      error: (error) => console.error('Error fetching working locations', error),
    });
  }

  private loadProfesionalBranches() {
    this.globalConstantsService.getProfessionalBranches().subscribe({
      next: (data) => (this.profesionalBranches = data),
      error: (error) => console.error('Error fetching branches', error),
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
    const workingLocation = this.workingLocations.find((location) => location.id === workingLocationId);
    return workingLocation ? workingLocation.name : '';
  }

  editAdvertisement(id: number): void {
    this.router.navigate(['/jobs/advertisements/update', id]);
  }
}
