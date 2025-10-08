import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private baseUrl = environment.apiUrl;

  private currentUserSource = new BehaviorSubject<any>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) {}

  createUser(formData: FormData): Observable<any> {

    return this.http.post(`${this.baseUrl}User/CreateUser`, formData).pipe(
      tap((user: any) => {
        localStorage.setItem('userName', user.userName);
        this.currentUserSource.next(user.userName)
      })
    );
  }
}
