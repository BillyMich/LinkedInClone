import { Component, OnInit } from '@angular/core';
import { NotificationsService } from '../services/notifications.service';

@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.css']
})
export class NotificationsComponent implements OnInit {
  connectionRequests: any[] = [];
  interestNotes: any[] = [];
  comments: any[] = [];

  constructor(private notificationsService: NotificationsService) {}

  ngOnInit() {
    this.loadNotifications();
  }

  loadNotifications() {
    this.notificationsService.getConnectionRequests().subscribe(data => {
      this.connectionRequests = data;
    });

    this.notificationsService.getInterestNotes().subscribe(data => {
      this.interestNotes = data;
    });

    this.notificationsService.getComments().subscribe(data => {
      this.comments = data;
    });
  }

  acceptRequest(requestId: string) {
    this.notificationsService.acceptConnectionRequest(requestId).subscribe(() => {
      this.loadNotifications();  
    });
  }

  rejectRequest(requestId: string) {
    this.notificationsService.rejectConnectionRequest(requestId).subscribe(() => {
      this.loadNotifications();  
    });
  }
}
