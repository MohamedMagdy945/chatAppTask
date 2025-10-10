import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { IUser } from '../Models/user';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private baseUrl = environment.apiUrl;

  private currentUserSource = new BehaviorSubject<any>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) {}

  createUser(formData: FormData): Observable<IUser> {
    return this.http.post<IUser>(`${this.baseUrl}User/CreateUser`, formData).pipe(
      tap((user: IUser) => {
        localStorage.setItem('user', JSON.stringify(user));
        this.currentUserSource.next(user);
      })
    );
  }

  login(data: any): Observable<IUser> {
    return this.http.post(`${this.baseUrl}User/Login`, data).pipe(
      tap((user: any) => {
        localStorage.setItem('user', JSON.stringify(user));
        this.currentUserSource.next(user);
      })
    );
  }
  loadCurrentUser() {
    const user = localStorage.getItem('user');
    if (user) {
      this.currentUserSource.next(JSON.parse(user));
    }
  }
}
