// src/app/admin/user-list/user-list.component.ts
import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';
@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
})
export class UserListComponent implements OnInit {
  users: any[] = [];

  constructor(private userService: UserService) {}

  ngOnInit() {
    this.userService.getAllUsers().subscribe((data: any[]) => {
      this.users = data;
    });
  }
}
