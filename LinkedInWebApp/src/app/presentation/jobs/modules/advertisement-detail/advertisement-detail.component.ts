import { Component, Input } from '@angular/core';
import { AdvertisementDto } from '../../models/advertisement.model';

@Component({
  selector: 'app-advertisement-detail',
  templateUrl: './advertisement-detail.component.html',
  styleUrls: ['./advertisement-detail.component.css'],
})
export class AdvertisementDetailComponent {
  @Input() advertisement!: AdvertisementDto;
  @Input() IsEditor: boolean = false; 
}
