import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ApplicationsPageRoutingModule } from './applications-routing.module';

import { ApplicationsPage } from './applications.page';
import { PartyService } from '../parties/services/party.service';
import { ApplicationService } from './services/application.service';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ApplicationsPageRoutingModule,
  ],
  declarations: [ApplicationsPage],
  providers: [PartyService, ApplicationService],
})
export class ApplicationsPageModule {}
