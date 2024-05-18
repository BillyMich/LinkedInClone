// src/app/admin/user-profile/user-profile.component.ts
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  user: any;

  constructor(
    private route: ActivatedRoute,
    private userService: UserService
  ) {}

  ngOnInit() {
    const userId = this.route.snapshot.paramMap.get('id')!;
    this.userService.getUserById(userId).subscribe((data: any) => {
      this.user = data;
    });
  }

  exportData(format: string) {
    this.userService.exportUserData(this.user.id, format).subscribe((data) => {
      // Logic to download the file
      console.log(`User data exported in ${format} format`, data);
    });
  }
}
