import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuardService } from 'src/app/auth/auth-guard.service';
import { ApplicationsPage } from './applications.page';

const routes: Routes = [
  {
    path: '',
    canActivate: [AuthGuardService],
    component: ApplicationsPage,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ApplicationsPageRoutingModule {}
