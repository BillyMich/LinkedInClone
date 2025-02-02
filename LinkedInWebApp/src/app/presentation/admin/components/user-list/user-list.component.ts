import { Component, OnInit } from '@angular/core';
import { ChangeDetectorRef } from '@angular/core';
import { UserService } from '../../../../services/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
})
export class UserListComponent implements OnInit {
  users: any[] = [];

  constructor(
    private userService: UserService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit() {
    this.loadUsers();
  }

  loadUsers() {
    this.userService.getAllUsers().subscribe({
      next: (data: any[]) => {
        this.users = data.map((user) => ({ ...user, selected: false }));
        this.cdr.detectChanges();
      },
      error: (err) => {
        console.error('Error fetching users:', err);
        alert('Failed to load users. Please check API connection.');
      },
    });
  }

  exportSelectedUsers(format: string = 'json') {
    const selectedUserIds = this.users
      .filter((user) => user.selected)
      .map((user) => user.id);

    if (selectedUserIds.length > 0) {
      this.userService.exportUserData(selectedUserIds, format).subscribe({
        next: (blob) => {
          const dataType =
            format === 'xml' ? 'application/xml' : 'application/json';
          const blobUrl = window.URL.createObjectURL(
            new Blob([blob], { type: dataType })
          );

          const a = document.createElement('a');
          a.href = blobUrl;
          a.download = `users.${format}`;
          document.body.appendChild(a);
          a.click();
          document.body.removeChild(a);
        },
        error: (err) => {
          console.error(`Error exporting user data to ${format}:`, err);
          alert(`Failed to export data in ${format} format.`);
        },
      });
    } else {
      console.log('No users selected for export.');
    }
  }

  trackByFn(index: number, user: any): string {
    return user.id;
  }
}
