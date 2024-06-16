import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { LocalStorageService } from '../local-storage/local-storage.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})



  export class LogedInGuard{
    constructor(private  router: Router, private localStorageService: LocalStorageService ) {}
    canActivate(
      next: ActivatedRouteSnapshot,
      state: RouterStateSnapshot
  
    ):
      | Observable<boolean | UrlTree>
      | Promise<boolean | UrlTree>
      | boolean
      | UrlTree {
      if (this.localStorageService.isLoggedIn() === false){
        this.router.navigate(['login']);
      }
      return true;
    }
  }