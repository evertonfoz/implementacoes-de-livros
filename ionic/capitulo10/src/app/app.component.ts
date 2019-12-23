import { Component } from '@angular/core';

import { Platform } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';
import { Environment } from '@ionic-native/google-maps';

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

  constructor(
    private platform: Platform,
    private splashScreen: SplashScreen,
    private statusBar: StatusBar
  ) {
    this.initializeApp();
  }

  initializeApp() {
    this.platform.ready().then(() => {
        Environment.setEnv({
          // Api key for your server
          // (Make sure the api key should have Website restrictions for your website domain only)
          API_KEY_FOR_BROWSER_RELEASE: 'AIzaSyBAB20kcGPy6ZnIKawiwLaRbejZ36bM8Xg',

          // Api key for local development
          // (Make sure the api key should have Website restrictions for 'http://localhost' only)
          API_KEY_FOR_BROWSER_DEBUG: 'AIzaSyBAB20kcGPy6ZnIKawiwLaRbejZ36bM8Xg'
        });
        this.statusBar.styleDefault();
        this.splashScreen.hide();
     });
  }
}
