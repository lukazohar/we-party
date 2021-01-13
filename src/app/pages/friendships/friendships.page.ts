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
import { IFriendship } from './interfaces/friendship.interface';
import { Friendship } from './interfaces/friendship';
import { FriendshipService } from './services/friendship.service';
import { combineLatest, from } from 'rxjs';
import { UserService } from './services/users.service';
import { IUser } from 'src/app/auth/user.interface';
import { ToastService } from 'src/app/core/toast/toast.service';

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
  userId: string;
  loading: HTMLIonLoadingElement;
  friendships: Array<IFriendship>;
  users: Array<IUser>;
  modal: HTMLIonModalElement;

  constructor(
    private friendshipService: FriendshipService,
    private storage: Storage,
    private modalController: ModalController,
    private authService: AuthService,
    private userService: UserService,
    private loadingController: LoadingController,
    private toastService: ToastService,
  ) {}

  async ngOnInit() {
    await this.showLoading();
    combineLatest([
      this.friendshipService.getAll(),
      this.userService.getAll(),
      from(this.storage.get('ID')),
    ]).subscribe(
      ([friendships, users, userId]) => {
        this.userId = userId;
        this.updateUsers(users, friendships);

        this.hideLoading();
      },
      (err) => {
        this.loading.dismiss();
        this.toastService.danger('Error loading');
      },
    );
  }

  updateUsers(users: Array<IUser>, friendships: Array<IFriendship>) {
    users = users.filter((user) => user.id !== this.userId);
    users.forEach((user) => {
      user.friendship = friendships.find(
        (friendship) =>
          friendship.receiverId === user.id ||
          friendship.requesterId === user.id,
      );
    });
    this.users = users;
    this.friendships = friendships;
  }

  add(requesterId: string, receiverId: string) {
    console.log('TCL: FriendshipsPage -> add -> requesterId', requesterId);
    const newFriendship = new Friendship();
    newFriendship.requesterId = requesterId;
    newFriendship.receiverId = receiverId;

    this.friendshipService.create(newFriendship).subscribe(
      (createdFriendShip) => {
        this.friendships.push(createdFriendShip);
        this.updateUsers(this.users, this.friendships);
      },
      (err) => {
        console.log(err);
        this.toastService.danger('Error');
      },
    );
  }
  decline(requestId: number) {
    this.friendshipService.delete(requestId).subscribe(
      () => {
        const index = this.friendships.findIndex(
          (friendship) => friendship.id === requestId,
        );
        this.friendships.splice(index, 1);
        this.updateUsers(this.users, this.friendships);
      },
      (err) => {
        console.log(err);
        this.toastService.danger('Error');
      },
    );
  }
  confirm(requestId: number, request: IFriendship) {
    request.status = 'Confirmed';
    this.friendshipService.update(requestId, request).subscribe(
      (confirmedFriendship) => {
        const foundFriendship = this.friendships.find(
          (friendship) => friendship.id === requestId,
        );
        foundFriendship.status = 'Confirmed';
      },
      (err) => {
        console.log(err);
        this.toastService.danger('Error');
      },
    );
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
