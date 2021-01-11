import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuardService } from 'src/app/auth/auth-guard.service';
import { FriendshipsPage } from './friendships.page';

const routes: Routes = [
  {
    path: '',
    canActivate: [AuthGuardService],
    component: FriendshipsPage,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class FriendshipsPageRoutingModule {}
