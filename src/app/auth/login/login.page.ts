import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastService } from 'src/app/core/toast/toast.service';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {
  formGroup: FormGroup;

  constructor(
    private router: Router,
    private toast: ToastService,
    private authService: AuthService,
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
}
