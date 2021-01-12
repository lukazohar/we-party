import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { HttpClientModule } from '@angular/common/http';
import { AuthModule } from 'src/app/auth/auth.module';
import { PartiesPage } from './parties.page';
import { PartyComponent } from './components/party/party.component';
import { PartiesPageRoutingModule } from './parties-routing.module';
import { CoreModule } from 'src/app/core/core.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    PartiesPageRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    AuthModule,
    CoreModule,
  ],
  declarations: [PartiesPage, PartyComponent],
})
export class PartiesPageModule {}
