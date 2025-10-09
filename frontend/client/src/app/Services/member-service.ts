import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { IUser } from '../Models/user';

@Injectable({
  providedIn: 'root',
})
export class MemberService {
  private baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}

  getALLUser(): Observable<IUser[]> {
    return this.http.get<IUser[]>(`${this.baseUrl}User/GetAllUser`);
  }
}
