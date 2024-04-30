import { User } from '../models/user.model'; 
import { Login } from '../models/login';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit { 
  userModel = new User("John", "Doe", "johnDoe@protonmail.com", "12345678");
  loginForm!: FormGroup; 
  userLogin = new Login("JohnD", "pass123@@gg");
  constructor() { }

  ngOnInit() {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(8)])
    });
  }

  onLogin() {
    if (this.loginForm.valid) {
      console.log(this.loginForm.value);
      
    } else {
      console.log('Invalid form.');
    }
  }
}
