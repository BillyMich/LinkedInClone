import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent {
  user = { email:'', password: '' };
  
  constructor(private authService: AuthService) {}


  onLogin() {
    console.log('Login form submitted', this.user);
      this.authService.login(this.user.email, this.user.password)
        .subscribe({
          next: (response) =>{
             console.log('Login successful', response)
          },
          error: (error) => {
            console.error('Login failed', error)
          }
        });
  }
   
}
