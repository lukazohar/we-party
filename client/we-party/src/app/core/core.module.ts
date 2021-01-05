import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastService } from './toast/toast.service';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';

@NgModule({
  declarations: [],
  imports: [CommonModule],
  providers: [ToastService],
  exports: [ToastService],
})
export class CoreModule {}
