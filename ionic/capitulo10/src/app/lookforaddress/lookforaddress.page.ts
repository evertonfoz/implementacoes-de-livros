import { Component, OnInit, ViewChild } from '@angular/core';
import { GoogleMap, GoogleMaps, Geocoder, GeocoderResult, Marker } from '@ionic-native/google-maps';
import { IonInput, Platform, LoadingController, ToastController } from '@ionic/angular';

@Component({
  selector: 'app-lookforaddress',
  templateUrl: './lookforaddress.page.html',
  styleUrls: ['./lookforaddress.page.scss'],
})
export class LookforaddressPage implements OnInit {

  map: GoogleMap;
  loading: any;
  @ViewChild('endereco') endereco: IonInput;

  constructor(
    private platform: Platform,
    public loadingCtrl: LoadingController,
    public toastCtrl: ToastController
  ) { }

  async ngOnInit() {
    await this.platform.ready();
    await this.loadMap();
  }

  async loadMap() {
    this.map = await GoogleMaps.create('mapDiv');
  }

  async localizarEndereco() {
    this.map.clear();

    this.loading = await this.loadingCtrl.create({
      message: 'Por favor, aguarde...'
    });
    await this.loading.present();

    Geocoder.geocode({
      address: this.endereco.value
    }).then((results: GeocoderResult[]) => {
      this.loading.dismiss();

      if (results.length > 0) {
        const marker: Marker = this.map.addMarkerSync({
          position: results[0].position,
          title:  JSON.stringify(results[0].position)
        });
        this.map.animateCamera({
          target: marker.getPosition(),
          zoom: 17
        });

        marker.showInfoWindow();
      } else {
        this.showToast('Não encontrado');
      }
    });
  }

  async showToast(message: string) {
    const toast = await this.toastCtrl.create({
      message,
      duration: 4000,
      position: 'middle'
    });

    toast.present();
  }
}
