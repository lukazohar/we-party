import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { from, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AuthService } from './auth.service';
@Injectable()
export class AuthGuardService implements CanActivate {
  constructor(public auth: AuthService, public router: Router) {}

  canActivate(): Observable<boolean> {
    return from(this.auth.isLoggedIn()).pipe(
      tap((isLoggedIn) => {
        if (!isLoggedIn) {
          this.router.navigate(['login']);
        }
      }),
    );
  }
}
