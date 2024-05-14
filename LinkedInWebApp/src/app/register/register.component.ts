import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;

  constructor(private authService: AuthService) {} 

  ngOnInit() {
    this.registerForm = new FormGroup({
      fullName: new FormControl('', [Validators.required, Validators.minLength(3)]),
      email: new FormControl('', [Validators.required, Validators.email]),
      phone: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required, Validators.minLength(8)]),
      confirmPassword: new FormControl('', [Validators.required]),
      profilePicture: new FormControl(null)
    }, { validators: this.passwordMatchValidator });    
  }

  passwordMatchValidator: ValidatorFn = (control: AbstractControl): ValidationErrors | null => {
    const password = control.get('password');
    const confirmPassword = control.get('confirmPassword');
  
    if (!password || !confirmPassword) return null; 
  
    return password.value === confirmPassword.value ? null : { 'mismatch': true };
  };

  onFileChange(event: any) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.registerForm.patchValue({
        profilePicture: file
      });
    }
  }

  onSubmit() {
    if (this.registerForm.valid) {
      this.authService.register(this.registerForm.value).subscribe({
        next: (response) => {
          console.log('Registration successful', response);
        },
        error: (error) => {
          console.error('Registration failed', error);
        }
      });
    } else {
      console.log('Form is not valid');
    }
  }
}
