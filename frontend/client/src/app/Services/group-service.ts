import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IGroup } from '../Models/group';

@Injectable({
  providedIn: 'root',
})
export class GroupService {
  private baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}

  createGroup(formData: FormData) {
    return this.http.post(`${this.baseUrl}Group/createGroup`, formData);
  }
  getAllGroups(): Observable<IGroup[]> {
    return this.http.get<IGroup[]>(`${this.baseUrl}Group/GetAllGroup`);
  }

  getCommonGroup(senderId: number, receivedId: number): Observable<number> {
    return this.http.get<number>(`${this.baseUrl}Group/GetGroupId/${senderId}/${receivedId}`);
  }
}
