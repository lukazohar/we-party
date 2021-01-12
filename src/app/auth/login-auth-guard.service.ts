import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { Storage } from '@ionic/storage';
import { forkJoin, from, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AuthService } from './auth.service';

@Injectable()
export class LoginAuthGuardService implements CanActivate {
  constructor(
    public auth: AuthService,
    public router: Router,
    private storage: Storage,
  ) {}

  canActivate(): Observable<boolean> {
    return forkJoin([from(this.auth.isLoggedIn())]).pipe(
      map(([isLoggedIn]) => {
        if (isLoggedIn) {
          this.router.navigateByUrl('parties');
          return false;
        }
        return true;
      }),
    );
  }
}
