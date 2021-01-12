import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ModalController } from '@ionic/angular';
import { ToastService } from 'src/app/core/toast/toast.service';
import { AuthService } from '../auth.service';
import { RegisterComponent } from './register/register.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {
  formGroup: FormGroup;
  modal: HTMLIonModalElement;

  constructor(
    private router: Router,
    private toast: ToastService,
    private authService: AuthService,
    private modalController: ModalController,
  ) {}

  ngOnInit() {
    this.formGroup = new FormGroup({
      username: new FormControl(null, Validators.required),
      password: new FormControl(null, [Validators.required]),
    });
  }

  login(formGroup: FormGroup) {
    this.authService.login(formGroup.value).subscribe(
      (res) => {
        this.router.navigateByUrl('parties');
      },
      (err) => {
        console.log(err);
        this.toast.danger('Invalid credentials');
      },
    );
  }

  register() {
    this.displayModal();
  }

  async displayModal() {
    this.presentModal().then(async () => {});
  }

  async presentModal() {
    const modal = await this.modalController.create({
      component: RegisterComponent,
      cssClass: 'modal-class',
    });
    this.modal = modal;
    return await modal.present();
  }

  logout() {
    this.authService.logout();
  }
}
