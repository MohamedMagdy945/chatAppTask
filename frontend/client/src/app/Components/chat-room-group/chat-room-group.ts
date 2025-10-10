import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { IGroup } from '../../Models/group';
import { environment } from '../../../environments/environment.development';
import { IMessage } from '../../Models/message';
import { AccountService } from '../../Services/account-service';
import { GroupService } from '../../Services/group-service';
import { MessageService } from '../../Services/message-service';
import { IUser } from '../../Models/user';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-chat-room-group',
  imports: [FormsModule],
  templateUrl: './chat-room-group.html',
  styleUrl: './chat-room-group.scss',
})
export class ChatRoomGroup implements OnInit, OnChanges {
  messageList: IMessage[] = [];

  constructor(private accountSercvice: AccountService, private messageService: MessageService) {}

  currentUser!: IUser;
  fileUrl!: File;

  @Input() group!: IGroup;
  baseURL = environment.baseUrl;

  message: IMessage = {
    id: 0,
    senderId: 0,
    groupId: 0,
    content: null,
    fileUrl: null,
    type: 0,
    sentAt: new Date(),
  };
  ngOnInit(): void {
    this.accountSercvice.currentUser$.subscribe({
      next: (res) => {
        this.currentUser = res;
        this.message.senderId = res.id;
        this.message.groupId = this.group.id;
        this.GetMessageForGroup();
      },
    });
  }

  private GetMessageForGroup() {
    if (this.group) {
      this.messageService.getAllMessageforGroup(this.group.id).subscribe({
        next: (res) => {
          this.messageList = res;
        },
        error: (err) => {
          console.log(err);
        },
      });
    } else {
      this.messageList = [];
    }
  }

  ngOnChanges(): void {
    this.GetMessageForGroup();
  }

  sendMessage() {
    if (this.message.content != '') {
      this.messageService.sendMessage(this.message).subscribe({
        next: (res: any) => {
          this.messageList.push(this.message);
        },
        error: (err) => {
          console.log(err);
        },
      });
    }
  }
}
