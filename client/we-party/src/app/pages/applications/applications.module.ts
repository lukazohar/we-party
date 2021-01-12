import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { HttpClientModule } from '@angular/common/http';
import { AuthModule } from 'src/app/auth/auth.module';
import { ApplicationsPage } from './applications.page';
import { ApplicationComponent } from './components/application/application.component';
import { ApplicationsPageRoutingModule } from './applications-routing.module';
import { CoreModule } from 'src/app/core/core.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ApplicationsPageRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    AuthModule,
    CoreModule,
  ],
  declarations: [ApplicationsPage, ApplicationComponent],
})
export class ApplicationsPageModule {}
