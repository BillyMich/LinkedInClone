// src/app/network/network.component.ts
import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-network',
  templateUrl: './network.component.html',
  styleUrls: ['./network.component.css'],
})
export class NetworkComponent implements OnInit {
  connectedProfessionals: any[] = [];
  searchResults: any[] = [];
  searchQuery: string = '';
  selectedProfessional: any = null;

  constructor(private userService: UserService, private router: Router) {}

  ngOnInit() {
    this.loadConnectedProfessionals();
  }

  loadConnectedProfessionals() {
    this.userService.getConnectedUsers().subscribe({
      next: (data) => {
        this.connectedProfessionals = data;
      },
      error: (err) => {
        console.error('Error loading connected professionals:', err);
      },
    });
  }

  searchProfessionals() {
    if (this.searchQuery) {
      this.userService.searchProfessionals(this.searchQuery).subscribe({
        next: (data) => {
          this.searchResults = data;
        },
        error: (err) => {
          console.error('Error searching professionals:', err);
        },
      });
    } else {
      this.searchResults = [];
    }
  }

  viewProfile(professional: any) {
    this.selectedProfessional = professional;
  }

  startPrivateChat(professionalId: string) {
    this.router.navigate(['/discussions'], { queryParams: { id: professionalId } });
  }
  
  sendFriendRequest(professionalId: string) {
    this.userService.createContactRequest(professionalId).subscribe({
      next: () => {
        alert('Friend request sent!');
      },
      error: (err) => {
        console.error('Error sending friend request:', err);
      },
    });
  }
}
