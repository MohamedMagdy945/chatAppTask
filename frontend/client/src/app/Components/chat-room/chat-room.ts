import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { IUser } from '../../Models/user';

@Component({
  selector: 'app-chat-room',
  imports: [],
  templateUrl: './chat-room.html',
  styleUrl: './chat-room.scss',
})
export class ChatRoom {
  @Input() recevieduser!: IUser;
}
