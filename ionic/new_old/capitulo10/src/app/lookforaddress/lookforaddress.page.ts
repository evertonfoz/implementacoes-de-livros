import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { CapacitorGoogleMaps } from '@capacitor-community/capacitor-googlemaps-native';
// import { NativeGeocoder } from '@ionic-native/native-geocoder';
import { NativeGeocoder, NativeGeocoderResult, NativeGeocoderOptions } from '@awesome-cordova-plugins/native-geocoder/ngx';
import { IonInput, LoadingController, Platform, ToastController } from '@ionic/angular';

@Component({
  selector: 'app-lookforaddress',
  templateUrl: './lookforaddress.page.html',
  styleUrls: ['./lookforaddress.page.scss'],
})
export class LookforaddressPage {

  constructor(
    public loadingCtrl: LoadingController,
    public toastCtrl: ToastController,
    private nativeGeocoder: NativeGeocoder,
  ) { }

  loading: any;
  @ViewChild('endereco') endereco: IonInput;
  @ViewChild('map') mapView: ElementRef;


  async localizarEndereco() {
    this.loading = await this.loadingCtrl.create({
      message: 'Por favor, aguarde...'
    });
    await this.loading.present();

    let options: NativeGeocoderOptions = {
      useLocale: true,
      maxResults: 5
    };


    // this.nativeGeocoder.reverseGeocode(52.5072095, 13.1452818, options)
    //   .then((result: NativeGeocoderResult[]) => console.log(JSON.stringify(result[0])))
    //   .catch((error: any) => console.log(error));

    this.nativeGeocoder.forwardGeocode(this.endereco.value.toString(), options)
      .then((result: NativeGeocoderResult[]) => {
        this.loading.dismiss();
        this.createMap(Number(result[0].latitude), Number(result[0].longitude));
      })
      .catch(async (error: any) => {
        this.showToast('Não encontrado ' + error);
        await this.loading.dismiss();
      });

    // const results = await NativeGeocoder.forwardGeocode(
    //   "1134 buchanan st, nw",
    //   {
    //     maxResults: 5,
    //     useLocale: true
    //   }
    // );
    // console.log(results);
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

  async showToast(message: string) {
    const toast = await this.toastCtrl.create({
      message,
      duration: 4000,
      position: 'middle'
    });

    toast.present();
  }
  // ionViewDidEnter() {
  //   this.createMap();
  // }

  async createMap(latitude: number, longitude: number) {
    const boundingRect = this.mapView.nativeElement.getBoundingClientRect() as DOMRect;

    CapacitorGoogleMaps.create({
      width: Math.round(boundingRect.width),
      height: Math.round(boundingRect.height),
      x: Math.round(boundingRect.x),
      y: Math.round(boundingRect.y),
      latitude: latitude,// coordinates.coords.latitude,
      longitude: longitude,//coordinates.coords.longitude,
      zoom: 16
    });

    CapacitorGoogleMaps.addListener('onMapReady', async () => {
      CapacitorGoogleMaps.setMapType({
        type: "normal" // hybrid, satellite, terrain
      });

      CapacitorGoogleMaps.addMarker({
        latitude: latitude,
        longitude: longitude,
        title: 'Aqui está',
        snippet: 'Está certa a localização?'
      });

      CapacitorGoogleMaps.setCamera({
        latitude: latitude,
        longitude: longitude,
        zoom: 16,
        bearing: 0
      });
    });

  }

  ionViewDidLeave() {
    CapacitorGoogleMaps.close();
  }
}
