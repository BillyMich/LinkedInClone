/* login.component.ts */
import { User } from '../models/user.model'; 
import { Login } from '../models/login';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit { 


  userModel = new User("John", "Doe", "johnDoe@protonmail.com", "12345678");
  loginForm!: FormGroup; 
  userLogin = new Login("JohnD", "pass123@@gg");

  constructor(private authService: AuthService) {}

  ngOnInit() {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(8)])
    });
  }

  onLogin() {
    if (this.loginForm.valid) {  /* e-mail (format), password (8 length) */
      this.authService.login(this.loginForm.value.email, this.loginForm.value.password)
        .subscribe({
          next: (response) =>{
             console.log('Login successful', response)
          },
          error: (error) => {
            console.error('Login failed', error)
          }
        });
    } else {
      console.log('Invalid form.');
    }
  }
}
