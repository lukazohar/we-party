import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { HttpClientModule } from '@angular/common/http';
import { AuthModule } from 'src/app/auth/auth.module';
import { FriendshipsPageRoutingModule } from './friendships-routing.module';
import { FriendshipsPage } from './friendships.page';
import { CoreModule } from 'src/app/core/core.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    FriendshipsPageRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    AuthModule,
    CoreModule,
  ],
  declarations: [FriendshipsPage],
})
export class FriendshipsPageModule {}
