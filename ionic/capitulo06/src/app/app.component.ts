import { Component } from '@angular/core';
import { CapacitorSQLite, SQLiteDBConnection } from '@capacitor-community/sqlite';
import { Platform } from '@ionic/angular';
import { Storage } from '@ionic/storage-angular';
import { DatabaseService } from './services/database.service';
import { createOrdensDeServicoTable, databaseName } from './services/database.statements';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {
  private initPlugin: boolean;
  currentPageTitle = 'Tipos de serviços';

  pages = [
    {
      title: 'Tipos de serviços',
      url: '/tiposdeservicos',
      icon: '/assets/imgs/icon_tiposservicos.png'
    },
    {
      title: 'Peças',
      url: '/pecas',
      icon: '/assets/imgs/tab_pecas.png'
    },
    {
      title: 'Atendimentos',
      url: '/ordensdeservico-listagem',
      icon: '/assets/imgs/icon_atendimentos.png'
    }
  ];

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
    // console.log(`this.initPlugin = ${this.initPlugin}`);

    this.platform.ready().then(async () => {
      this.databaseService.initializePlugin().then(async (ret) => {
        try {
          // if (this.databaseService.isDatabase(databaseName)) {
          //   console.log('Open Connection');
          //   const db = await this.databaseService.retrieveConnection(databaseName);
          //   // const db = await this.databaseService.openConnection(databaseName);
          //   console.log('Abriu Connection');
          // } else {
          // console.log('Chama createConnection');
          const db = await this.databaseService.createConnection(
            databaseName, false, "no-encryption", 1);
          // console.log(`db connection created ${JSON.stringify(db)}`);
          // }

          // const isDbOpen = (await db.isDBOpen()).result;
          // console.log('isDBOpen ' + isDbOpen);
          // if (isDbOpen) {
          //   await db.close();
          // }
          this.initPlugin = true;
        } catch (err) {
          console.log(`Error: ${err}`);
          this.initPlugin = false;
        }


        console.log('Status da inicialização do plugin: ' + this.initPlugin);
      });
    });
  }
}
