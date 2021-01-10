import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Storage } from '@ionic/storage';
import { from, Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IParty } from '../interfaces/party.interface';

@Injectable({
  providedIn: 'root',
})
export class PartyService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient, private storage: Storage) {}

  getAll(): Observable<IParty[]> {
    return from(this.storage.get('ACCESS_TOKEN')).pipe(
      switchMap((token) =>
        this.http.get<IParty[]>(this.baseUrl + '/parties', {
          headers: {
            Authorization: 'Bearer ' + token,
          },
        }),
      ),
    );
  }

  getById(partyId: number): Observable<IParty> {
    return from(this.storage.get('ACCESS_TOKEN')).pipe(
      switchMap((token) =>
        this.http.get<IParty>(this.baseUrl + '/parties/' + partyId, {
          headers: {
            Authorization: 'Bearer ' + token,
          },
        }),
      ),
    );
  }

  create(newParty: IParty) {
    return from(this.storage.get('ACCESS_TOKEN')).pipe(
      switchMap((token) =>
        this.http.post<IParty>(this.baseUrl + '/parties/', newParty, {
          headers: {
            Authorization: 'Bearer ' + token,
          },
        }),
      ),
    );
  }

  update(partyId: number, updateParty: IParty) {
    return from(this.storage.get('ACCESS_TOKEN')).pipe(
      switchMap((token) =>
        this.http.put<IParty>(
          this.baseUrl + '/parties/' + partyId,
          updateParty,
          {
            headers: {
              Authorization: 'Bearer ' + token,
            },
          },
        ),
      ),
    );
  }

  delete(partyId: number) {
    return from(this.storage.get('ACCESS_TOKEN')).pipe(
      switchMap((token) =>
        this.http.delete(this.baseUrl + '/parties/' + partyId, {
          headers: {
            Authorization: 'Bearer ' + token,
          },
        }),
      ),
    );
  }
}
