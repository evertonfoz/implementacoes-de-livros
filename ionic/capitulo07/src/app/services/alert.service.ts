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

    async presentConfirm(header: string, message: string, successFunction)  {
      const alert = await this.alertCtrl.create({
          header,
          message,
          buttons: [
              {
                  text: 'Cancel',
                  role: 'cancel',
                  handler: () => {
                      console.log('Remoção cancelada');
                  }
              },
              {
                  text: 'Manda brasa',
                  handler: () => {
                      successFunction();
                  }
              }
          ]
      });
      await alert.present();
  }
}
