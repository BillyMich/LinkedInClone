import { Component, Input, OnInit } from '@angular/core';
import { AdvertisementDto } from '../../models/advertisement.model';
import { AdvertisementComponent } from '../../advertisement.component';

@Component({
  selector: 'app-advertisement-detail',
  templateUrl: './advertisement-detail.component.html',
  styleUrls: ['./advertisement-detail.component.css'],
})
export class AdvertisementDetailComponent implements OnInit {
  @Input() advertisement!: AdvertisementDto;
  @Input() IsEditor = false;

  constructor(private advertisementComponent: AdvertisementComponent) {}

  ngOnInit(): void {}

  getBranchNameById(branchId: number): string {
    return this.advertisementComponent.getBranchNameById(branchId);
  }

  getJobTypeById(jobTypeId: number): string {
    return this.advertisementComponent.getJobTypeById(jobTypeId);
  }

  getWorkingLocationById(workingLocationId: number): string {
    return this.advertisementComponent.getWorkingLocationById(
      workingLocationId
    );
  }
}
