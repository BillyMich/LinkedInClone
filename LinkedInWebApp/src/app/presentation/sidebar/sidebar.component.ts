// src/app/sidebar/sidebar.component.ts
import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth-service/auth.service';
import { SettingsService } from '../../services/settings.service';
@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css'],
})
export class SidebarComponent implements OnInit {
  profilePictureUrl: string | ArrayBuffer | null = null; 
  userName: string | null = '';

  constructor(
    private authService: AuthService, 
    private settingsService: SettingsService
  ) {}

  ngOnInit() {
    const currentUser = this.authService.getCurrentUser();
  
    if (currentUser && currentUser.name) {
      this.userName = currentUser.name;
      this.loadProfilePicture();
    } else {
      console.error('User is not logged in or invalid user data');
    }
  }
  

  loadProfilePicture(): void {
    this.settingsService.getProfilePictureFromId().subscribe((blob) => {
      const reader = new FileReader();
      reader.onload = (event) => {
        this.profilePictureUrl = event.target!.result; 
      };
      reader.readAsDataURL(blob); 
    });
  }

  
  
}
