import { Injectable } from '@angular/core';
import { ToastController } from '@ionic/angular';

@Injectable({
  providedIn: 'root',
})
export class ToastService {
  constructor(private toastController: ToastController) {}

  async primary(text: string, lenght = 5000) {
    const toast = await this.toastController.create({
      message: text,
      duration: lenght,
      color: 'primary',
    });
    return toast.present();
  }

  async secondary(text: string, lenght = 5000) {
    const toast = await this.toastController.create({
      message: text,
      duration: lenght,
      color: 'secondary',
    });
    return toast.present();
  }

  async tertiary(text: string, lenght = 5000) {
    const toast = await this.toastController.create({
      message: text,
      duration: lenght,
      color: 'tertiary',
    });
    return toast.present();
  }

  async success(text: string, lenght = 5000) {
    const toast = await this.toastController.create({
      message: text,
      duration: lenght,
      color: 'success',
    });
    return toast.present();
  }

  async warning(text: string, lenght = 5000) {
    const toast = await this.toastController.create({
      message: text,
      duration: lenght,
      color: 'warning',
    });
    return toast.present();
  }

  async danger(text: string, lenght = 5000) {
    const toast = await this.toastController.create({
      message: text,
      duration: lenght,
      color: 'danger',
    });
    return toast.present();
  }

  async light(text: string, lenght = 5000) {
    const toast = await this.toastController.create({
      message: text,
      duration: lenght,
      color: 'light',
    });
    return toast.present();
  }

  async medium(text: string, lenght = 5000) {
    const toast = await this.toastController.create({
      message: text,
      duration: lenght,
      color: 'medium',
    });
    return toast.present();
  }

  async dark(text: string, lenght = 5000) {
    const toast = await this.toastController.create({
      message: text,
      duration: lenght,
      color: 'dark',
    });
    return toast.present();
  }
}
