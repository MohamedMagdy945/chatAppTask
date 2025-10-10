import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';
import { AccountService } from '../../Services/account-service';
import { GroupService } from '../../Services/group-service';
import { IUser } from '../../Models/user';

@Component({
  selector: 'app-group-dialog',
  standalone: true,
  imports: [CommonModule, FormsModule, MatDialogModule],
  templateUrl: './group-dialog.html',
  styleUrl: './group-dialog.scss',
})
export class GroupDialogComponent implements OnInit {
  Name = '';
  UserCraetedId = 0;
  password = '';
  GroupImage: File | null = null;

  constructor(
    public dialogRef: MatDialogRef<GroupDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private accountService: AccountService,
    private groupService: GroupService
  ) {}
  ngOnInit(): void {
    this.accountService.currentUser$.subscribe({
      next: (res) => {
        this.user = res;
      },
      error: (err) => console.log(err),
    });
  }
  user!: IUser;

  onFileSelected(event: any) {
    this.GroupImage = event.target.files[0];
  }

  onCancel() {
    this.dialogRef.close();
  }

  onCreate() {
    const formData = new FormData();
    formData.append('Name', this.Name);
    formData.append('UserCreatedId', this.user.id.toString());
    if (this.GroupImage) {
      console.log('hererere');
      formData.append('GroupImage', this.GroupImage);
    }

    this.groupService.createGroup(formData).subscribe({
      next: (res) => {
        this.dialogRef.close({
          name: this.data.groupName,
          image: this.GroupImage,
        });
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
}
