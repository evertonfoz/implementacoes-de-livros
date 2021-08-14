import { Injectable } from '@angular/core';
import { AlertController } from '@ionic/angular';

@Injectable({
    providedIn: 'root'
  })
export class AlertService {
    constructor(private alertCtrl: AlertController) {}

    async presentAlert(header: string, subHeader: string, message: string, buttons: string[]) {
        const alert = await this.alertCtrl.create({
          header,
          subHeader,
          message,
          buttons
        });
        await alert.present();
    }
}
