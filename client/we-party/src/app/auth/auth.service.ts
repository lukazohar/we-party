import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Storage } from '@ionic/storage';
import { forkJoin, from, Observable } from 'rxjs';
import { AuthResponse } from './auth-response';
import { User } from './user.interface';
import { map, switchMap, tap } from 'rxjs/operators';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  baseUrl = environment.apiUrl;

  constructor(
    private http: HttpClient,
    private storage: Storage,
    private router: Router,
    private jwtHelper: JwtHelperService,
  ) {}

  login(user: User): Observable<AuthResponse> {
    let response: AuthResponse;
    return this.http.post<AuthResponse>(`${this.baseUrl}/token`, user).pipe(
      switchMap((res: AuthResponse) => {
        response = res;
        return forkJoin([
          from(this.storage.set('ACCESS_TOKEN', res.user.access_token)),
          from(this.storage.set('ID', res.user.id)),
        ]);
      }),
      map(() => response),
    );
  }

  async logout() {
    await this.storage.remove('ACCESS_TOKEN');
    await this.storage.remove('ID');
    await this.router.navigateByUrl('auth');
  }

  async isLoggedIn() {
    const token = await this.storage.get('ACCESS_TOKEN');
    return !this.jwtHelper.isTokenExpired(token);
  }
}
