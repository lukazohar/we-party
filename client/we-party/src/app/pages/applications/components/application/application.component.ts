import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ModalController } from '@ionic/angular';
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

  constructor(
    private modalController: ModalController,
    private toastService: ToastService,
    private applicationService: ApplicationService,
  ) {}

  ngOnInit() {
    let idk = 10;
  }

  save() {
    if (this.item.id) {
      this.applicationService.update(this.item.id, this.item).subscribe(
        (application) => {
          this.modalController.dismiss({
            dismissed: false,
            item: application,
            new: false,
          });
          this.toastService.success('Updated', 1000);
        },
        (err) => {
          console.log(err);
          this.toastService.danger('Error');
        },
      );
    } else {
      this.applicationService.create(this.item).subscribe(
        (application) => {
          this.modalController.dismiss({
            dismissed: false,
            item: application,
            new: true,
          });
          this.toastService.success('Application Created', 3000);
        },
        (err) => {
          console.log(err);
          this.toastService.danger('Error');
        },
      );
    }
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

  revert(applicationId: number) {
    // Tukaj se odjaviš od partyja
  }
}
