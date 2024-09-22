import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';
import { AdvertisementDto } from '../../models/advertisement.model';
import { AdvertisementService } from '../../services/advertisement.service';

@Component({
  selector: 'app-my-advertisements',
  templateUrl: './my-advertisements.component.html',
  styleUrls: ['./my-advertisements.component.css'],
})
export class MyAdvertisementsComponent implements OnInit {
  advertisements: AdvertisementDto[] = [];

  constructor(
    private advertisementService: AdvertisementService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.advertisementService
      .getMyAdvertisement()
      .subscribe((advertisements: AdvertisementDto[]) => {
        this.advertisements = advertisements;
      });
  }

  editAdvertisement(id: number): void {
    this.router.navigate(['/jobs/advertisements/update', id]);
  }
}
