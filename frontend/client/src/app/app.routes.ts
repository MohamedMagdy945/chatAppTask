import { Routes } from '@angular/router';
import { Home } from './Core/home/home';
import { Message } from './Components/message/message';
import { Login } from './Components/login/login';

export const routes: Routes = [
  { path: '', component: Home },
  { path: 'message', component: Message },
  { path: 'login', component: Login },
];
