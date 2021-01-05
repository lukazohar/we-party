import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'login',
    loadChildren: () =>
      import('./core/login/login.module').then((m) => m.LoginPageModule),
  },
  {
    path: 'parties',
    loadChildren: () =>
      import('./pages/parties/parties.module').then((m) => m.PartiesPageModule),
  },
  {
    path: 'applications',
    loadChildren: () =>
      import('./pages/applications/applications.module').then(
        (m) => m.ApplicationsPageModule,
      ),
  },
  {
    path: 'friendss',
    loadChildren: () =>
      import('./pages/friends/friends.module').then((m) => m.FriendsPageModule),
  },
];
@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
