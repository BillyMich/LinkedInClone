import { Component, Input, Output, EventEmitter } from '@angular/core';
import { AdvertisementDto } from '../../models/advertisement.model';

@Component({
  selector: 'app-advertisement-detail',
  templateUrl: './advertisement-detail.component.html',
  styleUrls: ['./advertisement-detail.component.css'],
})
export class AdvertisementDetailComponent {
  @Input() advertisement!: AdvertisementDto;
  @Input() IsEditor: boolean = false;
  @Input() creatorProfilePicture: string | null = null;

  @Output() advertisementSelected: EventEmitter<AdvertisementDto> = new EventEmitter();

  onAdvertisementClick() {
    this.advertisementSelected.emit(this.advertisement);
  }

  onImageError(event: any) {
    event.target.src = '../../../assets/user-profile-picture.jpg'; 
  }
}
