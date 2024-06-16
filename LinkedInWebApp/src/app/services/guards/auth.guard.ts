import { Injectable } from '@angular/core';
import { Router,  ActivatedRouteSnapshot, RouterStateSnapshot,UrlTree, CanActivate} from '@angular/router';
import { Observable } from 'rxjs';
import { LocalStorageService } from '../local-storage/local-storage.service';

@Injectable({
  providedIn: 'root',
})

export class AuthGuard{
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