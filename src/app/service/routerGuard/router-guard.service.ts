import { LoginService } from './../login/login.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RouterGuardService implements CanActivate {

  constructor(private login: LoginService, private route: Router) { }

  // iterfaccia CanActivate
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    console.log('stato login : ' , this.login.isLogged())

    if (!this.login.isLogged()) {
      this.route.navigate(['Login']);
      return false
    }else{

      return true ;
    }

  }


}
