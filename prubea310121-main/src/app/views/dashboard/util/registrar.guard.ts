import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { HttpService } from 'src/app/services/http.service';

@Injectable({
  providedIn: 'root'
})
export class RegistrarGuard implements CanActivate {
  constructor(private router: Router, private servicios: HttpService) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

      if (sessionStorage.getItem('rol') == 'personal') {
        return true;
    }else{
      this.router.navigate(['/dashboard/home']);
    }

  }
  
}
