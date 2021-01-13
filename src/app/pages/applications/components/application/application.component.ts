import { Component, Input, OnInit } from '@angular/core';
import { ModalController } from '@ionic/angular';
import { Storage } from '@ionic/storage';
import { from } from 'rxjs';
import { ToastService } from 'src/app/core/toast/toast.service';
import { Application } from '../../interfaces/application';
import { ApplicationService } from '../../services/application.service';

@Component({
  selector: 'app-application',
  templateUrl: './application.component.html',
  styleUrls: ['./application.component.scss'],
})
export class ApplicationComponent implements OnInit {
  @Input() item: Application;
  @Input() displayOnly: boolean;
  owns = false;
  userId = '';

  constructor(
    private modalController: ModalController,
    private toastService: ToastService,
    private applicationService: ApplicationService,
    private storage: Storage,
  ) {}

  ngOnInit() {
    from(this.storage.get('ID')).subscribe((id) => {
      this.userId = id;
      this.owns = this.item.party.userId === this.userId;
    });
  }

  confirm() {
    this.item.status = 'Confirmed';
    this.applicationService.update(this.item.id, this.item).subscribe(
      (updatedItem) => {
        this.modalController.dismiss({
          dismissed: true,
          item: updatedItem,
          new: false,
          deleted: false,
        });
      },
      (err) => {
        console.log(err);
        this.toastService.danger('Error', 1000);
      },
    );
  }
  delete() {
    this.applicationService.delete(this.item.id).subscribe(
      () => {
        this.modalController.dismiss({
          dismissed: true,
          item: { _id: this.item.id },
          new: false,
          deleted: true,
        });
      },
      (err) => {
        console.log(err);
        this.toastService.danger('Error', 1000);
      },
    );
  }

  back() {
    this.modalController.dismiss({
      dismissed: true,
    });
  }
}
