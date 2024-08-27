/* login.component.ts */
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from '../../../services/auth-service/auth.service'; 
import { Router } from '@angular/router';
import { LocalStorageService } from '../../../services/local-storage/local-storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit { 

  loginForm!: FormGroup; 
  errorMessage: string | null = null;


  constructor(private authService: AuthService, 
    private router: Router, 
    private localStorageService :LocalStorageService) {}

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
            console.log('Login response', response);
            var userLogedIn = this.localStorageService.returnUser();
            console.log('User logged in', userLogedIn); 
            if (userLogedIn?.role === 'admin') {
                this.router.navigate(['/admin']);
              } else {
                this.router.navigate(['/home']);
              }
          },
          error: (error) => {
            this.errorMessage = error.error.Message || 'User login failed';
          }
        });
    } else {
      console.log('Invalid form.');
    }
  }
}
