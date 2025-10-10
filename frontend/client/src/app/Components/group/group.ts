import { Component, OnInit } from '@angular/core';
import { GroupService } from '../../Services/group-service';
import { IGroup } from '../../Models/group';
import { FormsModule, NgForm } from '@angular/forms';
import { IUser } from '../../Models/user';
import { environment } from '../../../environments/environment.development';
import { AccountService } from '../../Services/account-service';
import { ChatRoom } from '../chat-room/chat-room';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { GroupDialogComponent } from '../group-dialog/group-dialog';
import { ChatRoomGroup } from '../chat-room-group/chat-room-group';

@Component({
  selector: 'app-group',
  imports: [FormsModule, ChatRoomGroup, MatDialogModule],
  templateUrl: './group.html',
  styleUrl: './group.scss',
})
export class Group implements OnInit {
  groups: IGroup[] = [];
  newGroupName: string = '';
  loading = false;

  recevieduser!: IUser;

  constructor(
    private groupService: GroupService,
    private accountSerice: AccountService,
    private dialog: MatDialog
  ) {}

  openDialog() {
    const dialogRef = this.dialog.open(GroupDialogComponent, {
      width: '400px',
      data: { groupName: '' },
    });
  }

  baseURL = environment.baseUrl;
  isOpen = false;
  currentUser!: IUser;
  group!: IGroup;
  ngOnInit(): void {
    this.accountSerice.currentUser$.subscribe({
      next: (res) => {
        this.currentUser = res;
      },
      error: (err) => {
        console.log(err);
      },
    });

    this.loadGroups();
  }

  loadGroups() {
    this.groupService.getAllGroups().subscribe({
      next: (res) => {
        this.groups = res;
        
      },
      error: (err) => console.error(err),
    });
  }

  createGroup(form: NgForm) {
    if (!this.newGroupName.trim()) return;

    const formData = new FormData();
    formData.append('name', this.newGroupName);
    this.groupService.createGroup(formData).subscribe({
      next: (res: any) => {
        this.groups.push(res);
        this.newGroupName = '';
        form.resetForm();
      },
      error: (err) => {
        console.error(err);
      },
    });
  }

  chat(group: IGroup) {
    if (!this.isOpen) {
      this.isOpen = true;
    }
    this.group = group;
  }
}
