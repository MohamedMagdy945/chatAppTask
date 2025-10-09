import { Routes } from '@angular/router';
import { Home } from './Core/home/home';
import { Message } from './Components/message/message';
import { Login } from './Components/login/login';
import { Register } from './Components/register/register';
import { Contact } from './Components/contact/contact';

export const routes: Routes = [
  { path: '', component: Home },
  { path: 'message', component: Message },
  { path: 'login', component: Login },
  { path: 'register', component: Register },
  { path: 'contact', component: Contact },
];
