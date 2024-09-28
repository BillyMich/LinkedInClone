/*advertisement-update.components.ts */
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AdvertisementDto } from '../../models/advertisement.model';
import { AdvertisementService } from '../../services/advertisement.service';

@Component({
  selector: 'app-advertisement-update',
  templateUrl: './advertisement-update.component.html',
  styleUrls: ['./advertisement-update.component.css'],
})
export class AdvertisementUpdateComponent implements OnInit {
  advertisementForm!: FormGroup;
  advertisementId: number | undefined;

  constructor(
    private fb: FormBuilder,
    private advertisementService: AdvertisementService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.advertisementId = +this.route.snapshot.paramMap.get('id')!;
    this.advertisementService
      .getJobById(this.advertisementId)
      .subscribe((advertisement: AdvertisementDto) => {
        this.advertisementForm.patchValue(advertisement);
      });

    this.advertisementForm = this.fb.group({
      title: [''],
      professionalBranche: [''],
      jobType: [''],
      workingLocation: [''],
      status: [''],
    });
  }

  onSubmit(): void {
    if (this.advertisementForm.valid) {
      this.advertisementService
        .updateJob(this.advertisementForm.value)
        .subscribe(() => {
          this.router.navigate(['/advertisements']);
        });
    }
  }
}
