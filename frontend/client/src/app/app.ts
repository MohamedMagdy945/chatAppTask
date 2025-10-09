import { Component, OnInit } from '@angular/core';
import { Navbar } from './Core/navbar/navbar';
import { RouterOutlet } from '@angular/router';
import { AccountService } from './Services/account-service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Navbar],
  templateUrl: './app.html',
  styleUrl: './app.scss',
})
export class App implements OnInit {
  constructor(private accountService: AccountService) {}
  ngOnInit(): void {
    this.accountService.loadCurrentUser();
  }
}
