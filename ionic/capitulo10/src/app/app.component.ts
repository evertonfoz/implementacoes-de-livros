import { Component } from '@angular/core';
import { Platform } from '@ionic/angular';
import { SplashScreen } from '@capacitor/splash-screen';
import { StatusBar, Style } from '@capacitor/status-bar';

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
    }
  ];

  constructor(
    private platform: Platform,
  ) {
    this.initializeApp();
  }

  initializeApp() {
    this.platform.ready().then(async () => {
      await StatusBar.setStyle({ style: Style.Light });
      await SplashScreen.hide();
    });
  }
}
