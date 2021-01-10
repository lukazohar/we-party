import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ModalController } from '@ionic/angular';
import { ToastService } from 'src/app/core/toast/toast.service';
import { Party } from '../../interfaces/party';
import { PartyService } from '../../services/party.service';

@Component({
  selector: 'app-party',
  templateUrl: './party.component.html',
  styleUrls: ['./party.component.scss'],
})
export class PartyComponent implements OnInit {
  @Input() item: Party;
  @Input() displayOnly: boolean;

  formGroup: FormGroup;

  constructor(
    private modalController: ModalController,
    private partyService: PartyService,
    private toastService: ToastService,
  ) {}

  ngOnInit() {
    this.formGroup = new FormGroup({
      title: new FormControl(this.item.title),
      description: new FormControl(this.item.description),
      date: new FormControl(this.item.date),
      price: new FormControl(this.item.price),
      location: new FormControl(this.item.location),
      capacity: new FormControl(this.item.capacity),
      isPublic: new FormControl(this.item.isPublic),
      status: new FormControl(this.item.status),
    });
  }

  save() {
    if (this.formGroup.valid) {
      this.item = { ...this.item, ...this.formGroup.value };

      if (this.item.id) {
        this.partyService.update(this.item.id, this.item).subscribe(
          (party) => {
            this.modalController.dismiss({
              dismissed: false,
              item: party,
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
        this.partyService.create(this.item).subscribe(
          (party) => {
            this.modalController.dismiss({
              dismissed: false,
              item: party,
              new: true,
            });
            this.toastService.success('Party Created', 3000);
          },
          (err) => {
            console.log(err);
            this.toastService.danger('Error');
          },
        );
      }
    }
  }

  delete() {
    this.partyService.delete(this.item.id).subscribe(
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
