import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AccountService } from '../../Services/account-service';

@Component({
  selector: 'app-register',
  imports: [CommonModule, ReactiveFormsModule,FormsModule],
  templateUrl: './register.html',
  styleUrl: './register.scss',
})
export class Register {
  constructor(private _accountService: AccountService) {}

  email = '';
  username = '';
  password = '';
  profileImage: File | null = null;

  onFileSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.profileImage = file;
    }
  }
  onSubmit() {
    const formData = new FormData();
    formData.append('email', this.email);
    formData.append('username', this.username);
    formData.append('password', this.password);

    this._accountService.createUser(formData).subscribe({
      next: (res) => {
        console.log(res);
      },
      error: (err) => console.log(err),
    });
  }
}
