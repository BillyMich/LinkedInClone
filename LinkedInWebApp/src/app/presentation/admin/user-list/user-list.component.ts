// src/app/admin/user-list/user-list.component.ts
import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
})
export class UserListComponent implements OnInit {
  users: any[] = [];

  constructor(private userService: UserService, private cdr: ChangeDetectorRef) {}

  ngOnInit() {
    this.userService.getAllUsers().subscribe({
      next: (data: any[]) => {
        this.users = data;
        this.cdr.detectChanges(); 
      },
      error: (err) => {
        console.error('Error fetching users:', err);
      },
    });
  }
  

  exportSelectedUsers(format: string = 'json') {
    const selectedUsers = this.users.filter((user) => user.selected);
    if (selectedUsers.length > 0) {
      selectedUsers.forEach((user) => {
        this.userService.exportUserData(user.id, format).subscribe({
          next: (data) => {
           
            console.log(`${format.toUpperCase()} Data:`, data);
          },
          error: (err) => {
            console.error(`Error exporting user data to ${format}:`, err);
          },
        });
      });
    }
  }
}
