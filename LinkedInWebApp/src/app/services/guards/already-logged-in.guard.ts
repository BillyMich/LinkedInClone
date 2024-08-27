import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthService } from '../auth-service/auth.service'; // Adjust the path as necessary
import { LocalStorageService } from '../local-storage/local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AlreadyLoggedInGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router,private localStorageServices : LocalStorageService) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
        const isLoggedIn = this.localStorageServices.isLoggedIn();
        if (isLoggedIn) {
      this.router.navigate(['/home']);
      return false;
    }
    return true;
  }
}