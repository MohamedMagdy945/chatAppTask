import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { IUser } from '../../Models/user';
import { environment } from '../../../environments/environment.development';
import { AccountService } from '../../Services/account-service';
import { GroupService } from '../../Services/group-service';
import { FormsModule } from '@angular/forms';
import { IMessage } from '../../Models/message';
import { MessageService } from '../../Services/message-service';
@Component({
  selector: 'app-chat-room',
  imports: [FormsModule],
  templateUrl: './chat-room.html',
  styleUrl: './chat-room.scss',
})
export class ChatRoom implements OnInit, OnChanges {
  message: IMessage = {
    id: 0,
    senderId: 0,
    groupId: 0,
    content: null,
    fileUrl: null,
    type: 0,
    sentAt: new Date(),
  };

  groupId!: number;
  baseURL = environment.baseUrl;
  @Input() recevieduser!: IUser;
  messageList: IMessage[] = [];

  senderUser!: IUser;
  fileUrl!: File;

  constructor(
    private accountSercvice: AccountService,
    private groupService: GroupService,
    private messageService: MessageService
  ) {}

  ngOnInit(): void {
    this.accountSercvice.currentUser$.subscribe({
      next: (res) => {
        this.senderUser = res;
        this.message.senderId = res.id;
        this.tryGetGroup();
      },
    });
  }

  ngOnChanges(): void {
    this.tryGetGroup();
  }

  private GetMessageForGroup() {
    if (this.message.groupId) {
      this.messageService.getAllMessageforGroup(this.groupId).subscribe({
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

  private tryGetGroup() {
    if (this.senderUser && this.recevieduser) {
      this.groupService.getCommonGroup(this.senderUser.id, this.recevieduser.id).subscribe({
        next: (res) => {
          this.groupId = res;
          this.message.groupId = res;
          this.GetMessageForGroup();
        },
        error: (err) => console.error(err),
      });
    }
  }
  sendMessage() {
    if (this.message.content != '') {
      this.messageService.sendMessage(this.message, this.recevieduser.id).subscribe({
        next: (res: any) => {
          this.groupId = res.groupId;
          this.message.groupId = res.groupId;
          const newMessage: IMessage = {
            ...this.message,
            id: Date.now() + Math.random(),
          };
          this.messageList.push(newMessage);
          this.message.content = '';
        },
        error: (err) => {
          console.log(err);
        },
      });
    }
  }
}
