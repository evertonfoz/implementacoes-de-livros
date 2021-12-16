import { ToastController } from '@ionic/angular';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class ToastService {
    constructor(private toastCtrl: ToastController) { }

    async presentToast(message: string, duration: number, position: 'top' | 'bottom') {
        const toast = await this.toastCtrl.create({
            message,
            duration,
            position
        });
        toast.present();
    }
}