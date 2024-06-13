// src/app/bypass-login/bypass-login.component.ts
// bypass login for user (access home page) and admin until normal login is availiable
// go to localhost:4200/bypass-login
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-bypass-login',
  templateUrl: './bypass-login.component.html',
  styleUrls: ['./bypass-login.component.css']
})
export class BypassLoginComponent {

  constructor(private authService: AuthService, private router: Router) {}

  loginAsUser() {
    const user = {
      email: 'user@example.com',
      role: 'user'
    };
    localStorage.setItem('currentUser', JSON.stringify(user));
    this.router.navigate(['/home']);
  }

  loginAsAdmin() {
    const admin = {
      email: 'admin@example.com',
      role: 'admin'
    };
    localStorage.setItem('currentUser', JSON.stringify(admin));
    this.router.navigate(['/admin']);
  }
}
