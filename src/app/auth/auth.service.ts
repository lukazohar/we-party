import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Storage } from '@ionic/storage';
import { forkJoin, from, Observable } from 'rxjs';
import { AuthResponse } from './auth-response';
import { IUser } from './user.interface';
import { map, switchMap, tap } from 'rxjs/operators';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
import { HTTP } from '@ionic-native/http/ngx';
import { IRegisterUser } from './login/register/register-user.interface';

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

  login(user: IUser): Observable<AuthResponse> {
    let response: AuthResponse;
    return this.http.post<AuthResponse>(`${this.baseUrl}/token`, user).pipe(
      switchMap((res: AuthResponse) => {
        response = res;
        return forkJoin([
          from(this.storage.set('ACCESS_TOKEN', res.user.accessToken)),
          from(this.storage.set('ID', res.user.id)),
        ]);
      }),
      map(() => response),
    );
  }

  register(user: IRegisterUser): Observable<any> {
    return this.http.post<void>(`${this.baseUrl}/register`, user);
  }

  async logout() {
    await this.storage.remove('ACCESS_TOKEN');
    await this.storage.remove('ID');

    await this.router.navigateByUrl('login');
  }

  async isLoggedIn() {
    const token = await this.storage.get('ACCESS_TOKEN');
    return !this.jwtHelper.isTokenExpired(token);
  }
}
