import { Component } from '@angular/core';
import { CapacitorSQLite, SQLiteDBConnection } from '@capacitor-community/sqlite';
import { Platform } from '@ionic/angular';
import { Storage } from '@ionic/storage-angular';
import { DatabaseService } from './services/database.service';
import { createSchema } from './services/database.statements';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {
  // private initPlugin: boolean;

  constructor(
    private storage: Storage,
    private platform: Platform,
    private databaseService: DatabaseService,
  ) {
    this.initializeApp();
  }

  async ngOnInit() {
    await this.storage.create();
  }

  async initializeApp() {
    this.platform.ready().then(async () => {
      this.databaseService.initializePlugin().then(async (ret) => {
        try {
          const db = await this.databaseService.createConnection("oficina", false, "no-encryption", 1);
          // console.log(`Após criação da conexão com a base de dados ${JSON.stringify(db)}`);
        } catch (err) {
          console.log(`Error: ${err}`);
          // this.initPlugin = false;
        }


        // console.log('Status da inicialização do plugin: ' + this.initPlugin);
      });
    });
  }
}
