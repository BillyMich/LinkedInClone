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
  connectionRequestsFromOtherUsers: ContactRequestDto[] = [];
  connectionRequestsFromOtherMe: ContactRequestDto[] = [];
  interestNotes: any[] = [];
  comments: any[] = [];

  constructor(private notificationsService: NotificationsService) {}

  ngOnInit() {
    this.loadNotifications();
  }

  loadNotifications() {
    this.notificationsService.getConnectionRequests().subscribe((data) => {
      this.connectionRequestsFromOtherUsers = data.contactRequestsTo;
      this.connectionRequestsFromOtherMe = data.contactRequestsFrom;
    });

    this.notificationsService.getInterestNotes().subscribe((data) => {
      this.interestNotes = data;
    });

    this.notificationsService.getComments().subscribe((data) => {
      this.comments = data;
    });
  }

  acceptRequest(requestId: number) {
    const statusId = 1;
    const changeStatusRequest = new ContactRequestChangeStatusDto(
      requestId,
      statusId
    );

    this.notificationsService
      .acceptConnectionRequest(changeStatusRequest)
      .subscribe(() => {
        this.loadNotifications();
      });
  }

  rejectRequest(requestId: number) {
    const statusId = 0;
    const changeStatusRequest = new ContactRequestChangeStatusDto(
      requestId,
      statusId
    );

    this.notificationsService
      .acceptConnectionRequest(changeStatusRequest)
      .subscribe(() => {
        this.loadNotifications();
      });
  }
}
