import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { CapacitorGoogleMaps } from '@capacitor-community/capacitor-googlemaps-native';
import { Geolocation } from '@capacitor/geolocation';
import { LoadingController } from '@ionic/angular';
import { NativeGeocoder } from "@ionic-native/native-geocoder";

@Component({
  selector: 'app-mylocation',
  templateUrl: './mylocation.page.html',
  styleUrls: ['./mylocation.page.scss'],
})
export class MylocationPage {

  @ViewChild('map') mapView: ElementRef;
  loading: any;

  constructor(private loadingCtrl: LoadingController,) { }

  ionViewDidEnter() {
    this.createMap();
  }

  async createMap() {
    const boundingRect = this.mapView.nativeElement.getBoundingClientRect() as DOMRect;

    // const coordinates = await Geolocation.getCurrentPosition();

    CapacitorGoogleMaps.create({
      width: Math.round(boundingRect.width),
      height: Math.round(boundingRect.height),
      x: Math.round(boundingRect.x),
      y: Math.round(boundingRect.y),
      latitude: -25.3009031,// coordinates.coords.latitude,
      longitude: - 54.1143351,//coordinates.coords.longitude,
      zoom: 16
    });

    CapacitorGoogleMaps.addListener('onMapReady', async () => {
      CapacitorGoogleMaps.setMapType({
        type: "normal" // hybrid, satellite, terrain
      });

      // this.showCurrentPosition();
    });
  }

  ionViewDidLeave() {
    CapacitorGoogleMaps.close();
  }

  async showCurrentPosition() {
    this.loading = await this.loadingCtrl.create({
      message: 'Por favor, aguarde...'
    });
    await this.loading.present();

    const coordinates = await Geolocation.getCurrentPosition();

    CapacitorGoogleMaps.addMarker({
      latitude: coordinates.coords.latitude,
      longitude: coordinates.coords.longitude,
      title: 'Achei você',
      snippet: 'Este é o local aproximado que você está, certo?'
    });

    this.loading.dismiss();
    CapacitorGoogleMaps.setCamera({
      latitude: coordinates.coords.latitude,
      longitude: coordinates.coords.longitude,
      zoom: 16,
      bearing: 0
    });
  }
}