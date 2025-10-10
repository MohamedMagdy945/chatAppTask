import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../Services/account-service';
import { MessageService } from '../../Services/message-service';
import { IMessage } from '../../Models/message';
import { IUser } from '../../Models/user';

@Component({
  selector: 'app-message',
  imports: [],
  templateUrl: './message.html',
  styleUrl: './message.scss',
})
export class Message implements OnInit {
  User!: IUser;

  messages!: IMessage[];

  constructor(private accountService: AccountService, private messageService: MessageService) {}

  ngOnInit(): void {
    this.accountService.currentUser$.subscribe({
      next: (res) => {
        this.User = res;
        if (this.User) {
          this.tryGetMessages();
        }
      },
      error(err) {
        console.log(err);
      },
    });
  }
  tryGetMessages() {
    this.messageService.GetAllMessagesForUser(this.User.id).subscribe({
      next: (res) => {
        console.log(res);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
}
