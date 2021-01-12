import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Storage } from '@ionic/storage';
import { from, Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IApplication } from '../interfaces/application.interface';

@Injectable({
  providedIn: 'root',
})
export class ApplicationService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient, private storage: Storage) {}

  getAll(): Observable<IApplication[]> {
    return from(this.storage.get('ACCESS_TOKEN')).pipe(
      switchMap((token) =>
        this.http.get<IApplication[]>(this.baseUrl + '/applications', {
          headers: {
            Authorization: 'Bearer ' + token,
          },
        }),
      ),
    );
  }
  getAllMy(): Observable<IApplication[]> {
    return from(this.storage.get('ACCESS_TOKEN')).pipe(
      switchMap((token) =>
        this.http.get<IApplication[]>(this.baseUrl + '/applications/my', {
          headers: {
            Authorization: 'Bearer ' + token,
          },
        }),
      ),
    );
  }
  getAllReceived(): Observable<IApplication[]> {
    return from(this.storage.get('ACCESS_TOKEN')).pipe(
      switchMap((token) =>
        this.http.get<IApplication[]>(this.baseUrl + '/applications/received', {
          headers: {
            Authorization: 'Bearer ' + token,
          },
        }),
      ),
    );
  }

  getById(applicationId: number): Observable<IApplication> {
    return from(this.storage.get('ACCESS_TOKEN')).pipe(
      switchMap((token) =>
        this.http.get<IApplication>(
          this.baseUrl + '/applications/' + applicationId,
          {
            headers: {
              Authorization: 'Bearer ' + token,
            },
          },
        ),
      ),
    );
  }

  create(newApplication: IApplication) {
    return from(this.storage.get('ACCESS_TOKEN')).pipe(
      switchMap((token) =>
        this.http.post<IApplication>(
          this.baseUrl + '/applications/',
          newApplication,
          {
            headers: {
              Authorization: 'Bearer ' + token,
            },
          },
        ),
      ),
    );
  }

  update(applicationId: number, updateApplication: IApplication) {
    return from(this.storage.get('ACCESS_TOKEN')).pipe(
      switchMap((token) =>
        this.http.put<IApplication>(
          this.baseUrl + '/applications/' + applicationId,
          updateApplication,
          {
            headers: {
              Authorization: 'Bearer ' + token,
            },
          },
        ),
      ),
    );
  }

  delete(applicationId: number) {
    return from(this.storage.get('ACCESS_TOKEN')).pipe(
      switchMap((token) =>
        this.http.delete(this.baseUrl + '/applications/' + applicationId, {
          headers: {
            Authorization: 'Bearer ' + token,
          },
        }),
      ),
    );
  }
}
