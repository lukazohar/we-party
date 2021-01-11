import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { HttpClientModule } from '@angular/common/http';
import { AuthModule } from 'src/app/auth/auth.module';
import { ApplicationsPage } from './applications.page';
import { ApplicationComponent } from './components/application/application.component';
import { ApplicationsPageRoutingModule } from './applications-routing.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ApplicationsPageRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    AuthModule,
  ],
  declarations: [ApplicationsPage, ApplicationComponent],
})
export class ApplicationsPageModule {}
