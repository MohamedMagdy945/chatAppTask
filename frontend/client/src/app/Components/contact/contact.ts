import { Component, OnInit } from '@angular/core';
import { MemberService } from '../../Services/member-service';
import { IUser } from '../../Models/user';
import { environment } from '../../../environments/environment.development';
import { ChatRoom } from '../chat-room/chat-room';

@Component({
  selector: 'app-contact',
  imports: [ChatRoom],
  templateUrl: './contact.html',
  styleUrl: './contact.scss',
})
export class Contact implements OnInit {
  receivedUser!: IUser;
  users: IUser[] | null = null;
  baseURL = environment.baseUrl;
  isOpen = false;
  constructor(private memberService: MemberService) {}
  ngOnInit(): void {
    this.memberService.getALLUser().subscribe({
      next: (res) => {
        this.users = res;
        console.log(res);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
  chat(user: IUser) {
    if (!this.isOpen) {
      this.isOpen = true;
    }
    this.receivedUser = user;
  }
}
