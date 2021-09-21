import { Component } from '@angular/core';
import { SplashScreen } from '@capacitor/splash-screen';
import { StatusBar, StatusBarInfo, Style } from '@capacitor/status-bar';
import { LoadingController, Platform } from '@ionic/angular';
import { Storage } from '@ionic/storage-angular';
import { DatabaseService } from './services/database.service';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {
  constructor(
    private storage: Storage,
    private platform: Platform,
    private loadingCtrl: LoadingController,
    private databaseService: DatabaseService,
  ) {
    this.initializeApp();
  }

  async ngOnInit() {
    await this.storage.create();
  }

  async initializeApp() {
    this.platform.ready().then(async () => {
      const loading = await this.loadingCtrl.create();
      await loading.present();
      this.databaseService.init();
      this.databaseService.dbReady.subscribe(isReady => {
        if (isReady) {
          loading.dismiss();
          StatusBar.setStyle({ style: Style.Light });
          SplashScreen.hide();
        }
      });
    });
  }
}
