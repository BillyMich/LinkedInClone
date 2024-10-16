import { Component, OnInit } from '@angular/core';
import { NotificationsService } from '../../services/notifications.service';
import { ContactRequestChangeStatusDto } from '../network/models/network.model';
import { ContactRequestDto } from './models/notification.models';

@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.css'],
})
export class NotificationsComponent implements OnInit {
  connectionRequestsFromOthers: ContactRequestDto[] = [];
  connectionRequestsFromMe: ContactRequestDto[] = [];
  interestNotes: any[] = [];
  comments: any[] = [];

  constructor(private notificationsService: NotificationsService) {}

  ngOnInit() {
    this.loadNotifications();
  }

  loadNotifications() {
    this.notificationsService.getConnectionRequests().subscribe((data) => {
      this.connectionRequestsFromOthers = data.contactRequestsTo;
      this.connectionRequestsFromMe = data.contactRequestsFrom;
    });

    // μολις έχουμε υποστήριξη απο back
  }

  acceptRequest(requestId: number) {
    const changeStatusRequest = new ContactRequestChangeStatusDto(
      requestId,
      1 //accept
    );

    this.notificationsService
      .changeRequestStatus(changeStatusRequest)
      .subscribe(() => {
        this.loadNotifications();
      });
  }

  rejectRequest(requestId: number) {
    const changeStatusRequest = new ContactRequestChangeStatusDto(
      requestId,
      2 // reject
    );

    this.notificationsService
      .changeRequestStatus(changeStatusRequest)
      .subscribe(() => {
        this.loadNotifications();
      });
  }
}
