import { Component, OnInit } from '@angular/core';
import { Storage } from '@ionic/storage';
import { ModalController } from '@ionic/angular';
import {
  trigger,
  style,
  animate,
  transition,
  stagger,
  query,
} from '@angular/animations';
import { AuthService } from 'src/app/auth/auth.service';
import { IFriendship } from './interfaces/friendship.interface';
import { Friendship } from './interfaces/friendship';
import { FriendshipService } from './services/friendship.service';

@Component({
  selector: 'app-friendships',
  templateUrl: './friendships.page.html',
  styleUrls: ['./friendships.page.scss'],
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
export class FriendshipsPage implements OnInit {
  friendships: Array<IFriendship>;
  modal: HTMLIonModalElement;

  constructor(
    private friendshipService: FriendshipService,
    private storage: Storage,
    private modalController: ModalController,
    private authService: AuthService,
  ) {}

  ngOnInit() {
    this.friendshipService.getAll().subscribe((friendships) => {
      this.friendships = friendships;
    });
  }

  add() {
    const newFriendship = new Friendship();
    this.displayModal(newFriendship, false);
  }

  show(friendship: IFriendship) {
    this.displayModal(friendship, true);
  }

  async displayModal(friendship: IFriendship, displayOnly: boolean) {
    this.presentModal(friendship, displayOnly).then(async () => {
      const { data } = await this.modal.onWillDismiss();
      if (data.new && !data.dismissed) {
        setTimeout(() => {
          this.friendships.unshift(data.item);
        }, 300);
      } else if (!data.dismissed) {
        setTimeout(() => {
          const index = this.friendships.findIndex(
            (arrFriendship) => arrFriendship.id === data.item._id,
          );
          this.friendships[index] = data.item;
        }, 300);
      } else if (data.deleted) {
        const index = this.friendships.findIndex(
          (arrFriendship) => arrFriendship.id === data.item._id,
        );
        setTimeout(() => {
          this.friendships.splice(index, 1);
        }, 300);
      }
    });
  }

  async presentModal(item: IFriendship, displayOnly: boolean) {
    /* const modal = await this.modalController.create({
      component: FriendshipComponent,
      cssClass: 'modal-class',
      componentProps: {
        item,
        displayOnly,
      },
    });
    this.modal = modal;
    return await modal.present(); */
  }

  logout() {
    this.authService.logout();
  }
}
