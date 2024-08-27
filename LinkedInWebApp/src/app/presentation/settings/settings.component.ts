// src/app/settings/settings.component.ts
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css'],
})
export class SettingsComponent implements OnInit {
  settingsForm!: FormGroup;

  ngOnInit() {
    this.initForm();
  }

  initForm() {
    this.settingsForm = new FormGroup({
      // settings field
      notification: new FormControl(true, Validators.required),
    });
  }

  onSubmit() {
    if (this.settingsForm.valid) {
      // handle settings submission
      console.log('Settings saved', this.settingsForm.value);
    } else {
      console.log('Form is not valid');
    }
  }
}
