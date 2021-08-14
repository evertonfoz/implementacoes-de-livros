import { Component, OnInit } from '@angular/core';
import { Platform, LoadingController, ToastController } from '@ionic/angular';
import { GoogleMaps, GoogleMap, Marker, GoogleMapsAnimation, ILatLng, GoogleMapsEvent, MyLocation } from '@ionic-native/google-maps';

@Component({
  selector: 'app-mylocation',
  templateUrl: './mylocation.page.html',
  styleUrls: ['./mylocation.page.scss'],
})
export class MylocationPage implements OnInit {

  map: GoogleMap;
  loading: any;

  constructor(
    private platform: Platform,
    private loadingCtrl: LoadingController,
    private toastCtrl: ToastController
  ) { }

  async ngOnInit() {
    await this.platform.ready();
    await this.loadMap();
  }

  async loadMap() {
    this.map = await GoogleMaps.create('mapDiv', {
      camera: {
        target: {
          lat: -25.3009031,
          lng: -54.1143351
        },
        zoom: 18,
        tilt: 30
      }
    });

    const marker: Marker = await this.map.addMarkerSync({
      title: 'UTFPR',
      snippet: 'Melhor universidade de todos os tempos',
      position: {
        lat: -25.3009031,
        lng: -54.1143351
      },
      animation: GoogleMapsAnimation.BOUNCE
    });

    marker.showInfoWindow();
  }

  async mostrarLocalizacao() {
    // Liberação em relação a qualquer mapa exibido
    this.map.clear();

    // Criação e exibição da mensagem ao usuário
    this.loading = await this.loadingCtrl.create({
      message: 'Por favor, aguarde...'
    });
    await this.loading.present();

    // Obtenção da localização atual do dispositivo
    this.map.getMyLocation().then((location: MyLocation) => {
      this.loading.dismiss();

      // Efeito visual no movimento do mapa. No browser não aparece.
      this.map.animateCamera({
        target: location.latLng,
        zoom: 18,
        tilt: 30
      });

      // Adição do marcador, que já conhecemos da implementação anterior
      const marker: Marker = this.map.addMarkerSync({
        title: 'Achei você',
        snippet: 'Este é o local aproximado que você está, certo?  Pressione o marcador',
        position: location.latLng,
        animation: GoogleMapsAnimation.BOUNCE
      });

      // Exibição das informações do marcador
      marker.showInfoWindow();

      // Aqui colocamos algo novo, uma mensagem para exibir quando o usuário clicar no marcador
      marker.on(GoogleMapsEvent.MARKER_CLICK).subscribe(() => {
        // Este método ainda não temos.
        this.showToast('Essa é sua latitude/longitude ' + location.latLng.toString());
      });
    })
    .catch(err => {
      this.loading.dismiss();
      this.showToast(err.error_message);
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
