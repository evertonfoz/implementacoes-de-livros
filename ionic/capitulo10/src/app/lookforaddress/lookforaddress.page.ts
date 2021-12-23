import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { CapacitorGoogleMaps } from '@capacitor-community/capacitor-googlemaps-native';
import { IonInput, LoadingController, ToastController } from '@ionic/angular';
import { NativeGeocoder, NativeGeocoderResult, NativeGeocoderOptions } from '@awesome-cordova-plugins/native-geocoder/ngx';

@Component({
  selector: 'app-lookforaddress',
  templateUrl: './lookforaddress.page.html',
  styleUrls: ['./lookforaddress.page.scss'],
})
export class LookforaddressPage implements OnInit {

  loading: any;
  @ViewChild('address') address: IonInput;
  @ViewChild('map') mapView: ElementRef;

  constructor(
    public loadingCtrl: LoadingController,
    public toastCtrl: ToastController,
    private nativeGeocoder: NativeGeocoder,
  ) { }

  ngOnInit() {
  }

  async createMap(latitude: number, longitude: number) {
    const boundingRect = this.mapView.nativeElement.getBoundingClientRect() as DOMRect;

    CapacitorGoogleMaps.create({
      width: Math.round(boundingRect.width),
      height: Math.round(boundingRect.height),
      x: Math.round(boundingRect.x),
      y: Math.round(boundingRect.y),
      latitude: latitude,
      longitude: longitude,
      zoom: 16
    });

    CapacitorGoogleMaps.addListener('onMapReady', async () => {
      CapacitorGoogleMaps.setMapType({
        type: "normal"
      });
    });
  }

  ionViewDidLeave() {
    CapacitorGoogleMaps.close();
  }

  async findAddress() {
    this.loading = await this.loadingCtrl.create({
      message: 'Por favor, aguarde...'
    });
    await this.loading.present();

    let options: NativeGeocoderOptions = {
      useLocale: true,
      maxResults: 5
    };

    this.nativeGeocoder.forwardGeocode(this.address.value.toString(), options)
      .then(async (result: NativeGeocoderResult[]) => {
        const latitude = Number(result[0].latitude);
        const longitude = Number(result[0].longitude);

        this.loading.dismiss();
        await this.createMap(latitude, longitude);

        CapacitorGoogleMaps.addMarker({
          latitude: latitude,
          longitude: Number(result[0].longitude),
          title: 'Aqui está',
          snippet: 'Está certa a localização?'
        });

        CapacitorGoogleMaps.setCamera({
          latitude: latitude,
          longitude: longitude,
          zoom: 16,
          bearing: 0
        });
      })
      .catch(async (error: any) => {
        this.showToast('Não encontrado ' + error);
        await this.loading.present();
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
