import { Component, OnInit } from '@angular/core';
import { Storage } from '@ionic/storage';
import { LoadingController, ModalController } from '@ionic/angular';
import {
  trigger,
  style,
  animate,
  transition,
  stagger,
  query,
} from '@angular/animations';
import { AuthService } from 'src/app/auth/auth.service';
import { IApplication } from './interfaces/application.interface';
import { ApplicationService } from './services/application.service';
import { ApplicationComponent } from './components/application/application.component';

@Component({
  selector: 'app-applications',
  templateUrl: './applications.page.html',
  styleUrls: ['./applications.page.scss'],
  animations: [
    trigger('listAnimation', [
      transition('* => *', [
        query(
          ':enter',
          [
            style({ opacity: 0 }),
            stagger('200ms', animate('600ms ease-out', style({ opacity: 1 }))),
          ],
          { optional: true },
        ),
        query(':leave', animate('200ms', style({ opacity: 0 })), {
          optional: true,
        }),
      ]),
    ]),
  ],
})
export class ApplicationsPage implements OnInit {
  loading: HTMLIonLoadingElement;
  applications: Array<IApplication>;
  modal: HTMLIonModalElement;

  constructor(
    private applicationService: ApplicationService,
    private storage: Storage,
    private modalController: ModalController,
    private authService: AuthService,
    private loadingController: LoadingController,
  ) {}

  async ngOnInit() {
    await this.showLoading();
    this.applicationService.getAll().subscribe((applications) => {
      this.hideLoading();
      this.applications = applications;
    });
  }

  show(application: IApplication) {
    this.displayModal(application, true);
  }

  async displayModal(application: IApplication, displayOnly: boolean) {
    this.presentModal(application, displayOnly).then(async () => {
      const { data } = await this.modal.onWillDismiss();
      if (data.new && !data.dismissed) {
        setTimeout(() => {
          this.applications.unshift(data.item);
        }, 300);
      } else if (!data.dismissed) {
        setTimeout(() => {
          const index = this.applications.findIndex(
            (arrApplication) => arrApplication.id === data.item._id,
          );
          this.applications[index] = data.item;
        }, 300);
      } else if (data.deleted) {
        const index = this.applications.findIndex(
          (arrApplication) => arrApplication.id === data.item._id,
        );
        setTimeout(() => {
          this.applications.splice(index, 1);
        }, 300);
      }
    });
  }

  async presentModal(item: IApplication, displayOnly: boolean) {
    const modal = await this.modalController.create({
      component: ApplicationComponent,
      cssClass: 'modal-class',
      componentProps: {
        item,
        displayOnly,
      },
    });
    this.modal = modal;
    return await modal.present();
  }

  logout() {
    this.authService.logout();
  }

  async showLoading() {
    const loading = await this.loadingController.create({
      message: 'Loading',
    });
    await loading.present();
    this.loading = loading;
  }
  hideLoading() {
    this.loading.dismiss();
  }
}
