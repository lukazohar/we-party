import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Storage } from '@ionic/storage';
import { from, Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IFriendship } from '../interfaces/friendship.interface';

@Injectable({
  providedIn: 'root',
})
export class FriendshipService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient, private storage: Storage) {}

  getAll(): Observable<IFriendship[]> {
    return from(this.storage.get('ACCESS_TOKEN')).pipe(
      switchMap((token) =>
        this.http.get<IFriendship[]>(this.baseUrl + '/friendships', {
          headers: {
            Authorization: 'Bearer ' + token,
          },
        }),
      ),
    );
  }

  getById(friendshipId: number): Observable<IFriendship> {
    return from(this.storage.get('ACCESS_TOKEN')).pipe(
      switchMap((token) =>
        this.http.get<IFriendship>(
          this.baseUrl + '/friendships/' + friendshipId,
          {
            headers: {
              Authorization: 'Bearer ' + token,
            },
          },
        ),
      ),
    );
  }

  create(newFriendship: IFriendship) {
    return from(this.storage.get('ACCESS_TOKEN')).pipe(
      switchMap((token) =>
        this.http.post<IFriendship>(
          this.baseUrl + '/friendships/',
          newFriendship,
          {
            headers: {
              Authorization: 'Bearer ' + token,
            },
          },
        ),
      ),
    );
  }

  update(friendshipId: number, updateFriendship: IFriendship) {
    return from(this.storage.get('ACCESS_TOKEN')).pipe(
      switchMap((token) =>
        this.http.put<IFriendship>(
          this.baseUrl + '/friendships/' + friendshipId,
          updateFriendship,
          {
            headers: {
              Authorization: 'Bearer ' + token,
            },
          },
        ),
      ),
    );
  }

  delete(friendshipId: number) {
    return from(this.storage.get('ACCESS_TOKEN')).pipe(
      switchMap((token) =>
        this.http.delete(this.baseUrl + '/friendships/' + friendshipId, {
          headers: {
            Authorization: 'Bearer ' + token,
          },
        }),
      ),
    );
  }
}
