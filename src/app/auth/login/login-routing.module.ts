import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginAuthGuardService } from '../login-auth-guard.service';

import { LoginPage } from './login.page';

const routes: Routes = [
  {
    path: '',
    canActivate: [LoginAuthGuardService],
    component: LoginPage,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class LoginPageRoutingModule {}
