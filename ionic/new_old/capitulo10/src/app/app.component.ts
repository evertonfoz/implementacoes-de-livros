import { Component } from '@angular/core';
import { CapacitorGoogleMaps } from '@capacitor-community/capacitor-googlemaps-native';
import { environment } from 'src/environments/environment';


@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html'
})
export class AppComponent {
  public paginasApp = [
    {
      titulo: 'Home',
      url: '/home',
      icon: 'home'
    },
    {
      titulo: 'Minha localização',
      url: '/mylocation',
      icon: 'pin'
    },
    {
      titulo: 'Localizar endereço',
      url: '/lookforaddress',
      icon: 'navigate'
    }
  ];

  constructor() {
    CapacitorGoogleMaps.initialize({
      key: environment.mapsKey
    });
  }
}
