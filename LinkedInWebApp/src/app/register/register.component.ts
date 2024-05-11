import { Component } from '@angular/core';
import { User } from '../models/user.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  userModel = new User("John", "Doe", "johnDoe@protonmail.com", "12345678");

  constructor() { }

  onSubmit(): void {
    console.log(this.userModel);
    // register
  }
}
