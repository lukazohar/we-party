import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { IonicStorageModule, Storage } from '@ionic/storage';
import { AuthGuardService } from './auth-guard.service';
import { LoginAuthGuardService } from './login-auth-guard.service';
import { AuthService } from './auth.service';
import { CoreModule } from '../core/core.module';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    CoreModule,
    IonicStorageModule,
    HttpClientModule,
    IonicStorageModule.forRoot(),
  ],
  providers: [AuthGuardService, LoginAuthGuardService],
  exports: [AuthService, LoginAuthGuardService],
})
export class AuthModule {}
