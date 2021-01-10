import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuardService } from 'src/app/auth/auth-guard.service';
import { PartiesPage } from './parties.page';

const routes: Routes = [
  {
    path: '',
    canActivate: [AuthGuardService],
    component: PartiesPage,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PartiesPageRoutingModule {}
