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
import { IParty } from './interfaces/party.interface';
import { Party } from './interfaces/party';
import { PartyService } from './services/party.service';
import { PartyComponent } from './components/party/party.component';
import { delay } from 'rxjs/operators';

@Component({
  selector: 'app-parties',
  templateUrl: './parties.page.html',
  styleUrls: ['./parties.page.scss'],
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
export class PartiesPage implements OnInit {
  loading: HTMLIonLoadingElement;
  parties: Array<IParty> = [];
  modal: HTMLIonModalElement;

  constructor(
    private partyService: PartyService,
    private storage: Storage,
    private modalController: ModalController,
    private authService: AuthService,
    private loadingController: LoadingController,
  ) {}

  async ngOnInit() {
    await this.showLoading();
    this.partyService.getAll().subscribe((parties) => {
      this.hideLoading();
      this.parties = parties;
    });
  }

  add() {
    const newParty = new Party();
    this.displayModal(newParty, false);
  }

  show(party: IParty) {
    this.displayModal(party, true);
  }

  async displayModal(party: IParty, displayOnly: boolean) {
    this.presentModal(party, displayOnly).then(async () => {
      const { data } = await this.modal.onWillDismiss();
      if (data) {
        if (data.new && !data.dismissed) {
          setTimeout(() => {
            this.parties.unshift(data.item);
          }, 300);
        } else if (!data.dismissed) {
          const index = this.parties.findIndex(
            (arrParty) => arrParty.id === data.item.id,
          );
          this.parties[index] = data.item;
        } else if (data.deleted) {
          const index = this.parties.findIndex(
            (arrParty) => arrParty.id === data.item.id,
          );
          setTimeout(() => {
            this.parties.splice(index, 1);
          }, 300);
        }
      }
    });
  }

  async presentModal(item: IParty, displayOnly: boolean) {
    const modal = await this.modalController.create({
      component: PartyComponent,
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
