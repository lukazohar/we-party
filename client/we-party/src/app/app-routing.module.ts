import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { AuthGuardService } from './auth/auth-guard.service';
import { LoginAuthGuardService } from './auth/login-auth-guard.service';

const routes: Routes = [
  {
    path: 'login',
    canActivate: [LoginAuthGuardService],
    loadChildren: () =>
      import('./auth/login/login.module').then((m) => m.LoginPageModule),
  },
  {
    path: '',
    redirectTo: 'parties',
    pathMatch: 'full',
  },
  {
    path: 'parties',
    canActivate: [AuthGuardService],
    loadChildren: () =>
      import('./pages/parties/parties.module').then((m) => m.PartiesPageModule),
  },
  {
    path: 'applications',
    canActivate: [AuthGuardService],
    loadChildren: () =>
      import('./pages/applications/applications.module').then(
        (m) => m.ApplicationsPageModule,
      ),
  },
  {
    path: 'friends',
    canActivate: [AuthGuardService],
    loadChildren: () =>
      import('./pages/friendships/friendships.module').then(
        (m) => m.FriendshipsPageModule,
      ),
  },
];
@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
