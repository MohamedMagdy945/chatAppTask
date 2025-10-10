import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IMessage } from '../Models/message';
import { environment } from '../../environments/environment.development';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class MessageService {
  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}
  getAllMessageforGroup(groupId: number): Observable<IMessage[]> {
    return this.http.get<IMessage[]>(`${this.baseUrl}Message/GetMessages/${groupId}`);
  }

  GetAllMessagesForUser(userId: number): Observable<IMessage[]> {
    return this.http.get<IMessage[]>(`${this.baseUrl}Message/GetAllMessagesForUser/${userId}`);
  }

  sendMessage(message: IMessage, receviedId: number = 0) {
    const formData = new FormData();
    formData.append('SenderId', message.senderId.toString());
    if (message.groupId) {
      formData.append('GroupId', message.groupId.toString());
    } else {
      if (receviedId != 0) {
        formData.append('ReceiverId', receviedId.toString());
      }
    }
    if (message.content && message.content != '') {
      formData.append('Content', message.content);
    } else {
      if (message.fileUrl) formData.append('FileUrl', message.fileUrl);
    }
    return this.http.post(`${this.baseUrl}Message/SendMessage`, formData);
  }
}
