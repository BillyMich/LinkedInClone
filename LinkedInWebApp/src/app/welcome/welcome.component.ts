import { Component } from '@angular/core';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent {
  user = { email: '', password: '' };

  onLogin() {
    console.log('Logging in with:', this.user.email, this.user.password);
   
  }
}
