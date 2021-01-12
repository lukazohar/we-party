import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Storage } from '@ionic/storage';
import { from, Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { IUser } from 'src/app/auth/user.interface';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient, private storage: Storage) {}

  getAll(): Observable<IUser[]> {
    return from(this.storage.get('ACCESS_TOKEN')).pipe(
      switchMap((token) =>
        this.http.get<IUser[]>(this.baseUrl + '/users', {
          headers: {
            Authorization: 'Bearer ' + token,
          },
        }),
      ),
    );
  }

  getById(userId: number): Observable<IUser> {
    return from(this.storage.get('ACCESS_TOKEN')).pipe(
      switchMap((token) =>
        this.http.get<IUser>(this.baseUrl + '/users/' + userId, {
          headers: {
            Authorization: 'Bearer ' + token,
          },
        }),
      ),
    );
  }

  create(newUser: IUser) {
    return from(this.storage.get('ACCESS_TOKEN')).pipe(
      switchMap((token) =>
        this.http.post<IUser>(this.baseUrl + '/users/', newUser, {
          headers: {
            Authorization: 'Bearer ' + token,
          },
        }),
      ),
    );
  }

  update(userId: number, updateUser: IUser) {
    return from(this.storage.get('ACCESS_TOKEN')).pipe(
      switchMap((token) =>
        this.http.put<IUser>(this.baseUrl + '/users/' + userId, updateUser, {
          headers: {
            Authorization: 'Bearer ' + token,
          },
        }),
      ),
    );
  }

  delete(userId: number) {
    return from(this.storage.get('ACCESS_TOKEN')).pipe(
      switchMap((token) =>
        this.http.delete(this.baseUrl + '/users/' + userId, {
          headers: {
            Authorization: 'Bearer ' + token,
          },
        }),
      ),
    );
  }
}
