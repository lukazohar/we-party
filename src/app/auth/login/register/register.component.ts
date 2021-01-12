import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ModalController } from '@ionic/angular';
import { ToastService } from 'src/app/core/toast/toast.service';
import { AuthService } from '../../auth.service';
import { RegisterUser } from './register-user';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  @Input() displayOnly: boolean;

  formGroup: FormGroup;

  constructor(
    private modalController: ModalController,
    private toastService: ToastService,
    private authService: AuthService,
  ) {}

  ngOnInit() {
    this.formGroup = new FormGroup({
      userName: new FormControl(null, Validators.required),
      email: new FormControl(null, Validators.required),
      firstName: new FormControl(null, Validators.required),
      lastName: new FormControl(null, Validators.required),
      password: new FormControl(null, Validators.required),
    });
  }

  save() {
    if (this.formGroup.valid) {
      this.authService.register(this.formGroup.value).subscribe(
        (newUser) => {
          this.modalController.dismiss();
          this.toastService.success('Created', 1000);
        },
        (err) => {
          console.log(err);
          this.toastService.danger('Error');
        },
      );
    }
  }

  back() {
    this.modalController.dismiss({
      dismissed: true,
    });
  }
}
