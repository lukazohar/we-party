import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './core/navbar/navbar.component';
import { FooterComponent } from './core/footer/footer.component';
import { LoginPageModule } from './core/login/login.module';
import { PartiesPageModule } from './pages/parties/parties.module';
import { ApplicationsPageModule } from './pages/applications/applications.module';
import { FriendsPageModule } from './pages/friends/friends.module';
import { CoreModule } from './core/core.module';

@NgModule({
  declarations: [AppComponent, NavbarComponent, FooterComponent],
  entryComponents: [],
  imports: [
    BrowserModule,
    IonicModule.forRoot(),
    CoreModule,
    AppRoutingModule,
    LoginPageModule,
    PartiesPageModule,
    ApplicationsPageModule,
    FriendsPageModule,
  ],
  providers: [
    StatusBar,
    SplashScreen,
    { provide: RouteReuseStrategy, useClass: IonicRouteStrategy },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
