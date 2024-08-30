import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth-service/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css'],
})
export class SettingsComponent implements OnInit {
  settingsForm!: FormGroup;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit() {
    this.initForm();
  }

  initForm() {
    this.settingsForm = new FormGroup({
     
      notification: new FormControl(true, Validators.required),
    });
  }

  onSubmit() {
    if (this.settingsForm.valid) {
    
      console.log('Settings saved', this.settingsForm.value);
    } else {
      console.log('Form is not valid');
    }
  }

  onSignOut() {
    this.authService.signOut(); 
    this.router.navigate(['/login']); 
  }
}
