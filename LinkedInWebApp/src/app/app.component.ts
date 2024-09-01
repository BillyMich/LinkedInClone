/* app.component.ts */
import { Component } from '@angular/core';
import { LocalStorageService } from './services/local-storage/local-storage.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'], 
})
export class AppComponent {
  title = 'LinkedHub';

  constructor(private localStorageService: LocalStorageService) {}

  isLoggedIn(): boolean {
    return this.localStorageService.isLoggedIn();
  }
}
