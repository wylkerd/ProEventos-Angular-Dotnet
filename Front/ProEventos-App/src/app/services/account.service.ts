import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, ReplaySubject } from 'rxjs';
// import { environment } from '@environments/environment';
import { map, take } from 'rxjs/operators';
import { UserUpdate } from '../models/identity/UserUpdate';
import { User } from "../models/identity/User";
import { environments } from "@environments/environments";

@Injectable({
  providedIn: 'root'
})
export class AccountService implements OnInit {
  private currentUserSource = new ReplaySubject<User>(1);
  public currentUser$ = this.currentUserSource.asObservable();

  public _fakeUser: User = {
    userName: 'Wylkerd',
    email: 'wylkerd@email.com',
    password: 'senha123',
    primeiroNome: 'Wylkerd',
    ultimoNome: 'Silva',
    token: 'token-gerado'
  };

  ngOnInit(): void {
    this.setCurrentUser(this._fakeUser)
  }

  baseUrl = environments.baseUrl + 'api/account/'

  constructor(private http: HttpClient) { }

  public login(model: any): Observable<void> {
    return this.http.post<User>(this.baseUrl + 'login', model).pipe(
      take(1),
      map((response: User) => {
        const user = response;
        if (user) {
          this.setCurrentUser(user)
        }
      })
    );
  }

  getUser(): Observable<UserUpdate> {
    return this.http.get<UserUpdate>(this.baseUrl + 'getUser').pipe(take(1));
  }

  updateUser(model: UserUpdate): Observable<void> {
    return this.http.put<UserUpdate>(this.baseUrl + 'updateUser', model).pipe(
      take(1),
      map((user: UserUpdate) => {
          this.setCurrentUser(user);
        }
      )
    )
  }

  public register(model: any): Observable<void> {
    return this.http.post<User>(this.baseUrl + 'register', model).pipe(
      take(1),
      map((response: User) => {
        const user = response;
        if (user) {
          this.setCurrentUser(user)
        }
      })
    );
  }

  logout(): void {
    localStorage.removeItem('user');
    // this.currentUserSource.next(null);
    this.currentUserSource.complete();
  }

  public setCurrentUser(user: User): void {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  postUpload(file: File): Observable<UserUpdate> {
    const fileToUpload = file as File;
    const formData = new FormData();
    formData.append('file', fileToUpload);

    return this.http
      .post<UserUpdate>(`${this.baseUrl}upload-image`, formData)
      .pipe(take(1));
  }
}
