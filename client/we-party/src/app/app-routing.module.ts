import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  /* {
    path: 'login',
    loadChildren: () =>
      import('./core/login/login.module').then((m) => m.LoginPageModule),
  }, */
  /* {
    path: 'parties',
    loadChildren: () => import('./pages/parties/parties.module').then( m => m.PartiesPageModule)
  }, */
  /* {
    path: 'parties',
    loadChildren: () => import('./party/party.module').then(m => m.PartyPageModule)
  }, */
  /* {
    path: 'applications',
    loadChildren: () => import('./application/application.module').then(m => m.ApplicationPageModule)
  }, */
  /* {
    path: 'friendships',
    loadChildren: () => import('./friendship/friendship.module').then(m => m.FriendshipPageModule)
  }, */
];
@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
