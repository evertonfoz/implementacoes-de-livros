import { Component, OnInit, ViewChild } from '@angular/core';
import { NativeGeocoder } from '@ionic-native/native-geocoder';
import { IonInput, LoadingController, Platform, ToastController } from '@ionic/angular';

@Component({
  selector: 'app-lookforaddress',
  templateUrl: './lookforaddress.page.html',
  styleUrls: ['./lookforaddress.page.scss'],
})
export class LookforaddressPage {

  constructor(
    private platform: Platform,
    public loadingCtrl: LoadingController,
    public toastCtrl: ToastController
  ) { }

  loading: any;
  @ViewChild('endereco') endereco: IonInput;

  async localizarEndereco() {
    this.loading = await this.loadingCtrl.create({
      message: 'Por favor, aguarde...'
    });
    await this.loading.present();

    const results = await NativeGeocoder.forwardGeocode(
      "1134 buchanan st, nw",
      {
        maxResults: 5,
        useLocale: true
      }
    );
    console.log(results);
    // Geocoder.geocode({
    //   address: this.endereco.value
    // }).then((results: GeocoderResult[]) => {
    //   this.loading.dismiss();

    //   if (results.length > 0) {
    //     const marker: Marker = this.map.addMarkerSync({
    //       position: results[0].position,
    //       title: JSON.stringify(results[0].position)
    //     });
    //     this.map.animateCamera({
    //       target: marker.getPosition(),
    //       zoom: 17
    //     });

    //     marker.showInfoWindow();
    //   } else {
    //     this.showToast('Não encontrado');
    //   }
    // });
  }
}
