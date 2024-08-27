import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router'; // Make sure Router is imported

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;

  constructor(private authService: AuthService, private router: Router) {} // Inject Router

  ngOnInit() {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(8)])
    });
  }

  onLogin() {
    if (this.loginForm.valid) {
      this.authService.login(this.loginForm.value.email, this.loginForm.value.password)
        .subscribe({
          next: (response) => {
            if (response && response.user) {
              const role = response.user.role;
              if (role === 'admin') {
                this.router.navigate(['/admin']); // Router navigation
              } else {
                this.router.navigate(['/home']); // Router navigation
              }
            }
          },
          error: (error) => {
            console.error('Login failed', error);
          }
        });
    } else {
      console.log('Invalid form.');
    }
  }
}
