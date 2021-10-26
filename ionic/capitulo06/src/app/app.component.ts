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
    console.log(`this.initPlugin = ${this.initPlugin}`);

    this.platform.ready().then(async () => {
      this.databaseService.initializePlugin().then(async (ret) => {
        // console.log(`isConnection: ${(await this.databaseService.retrieveConnection('oficina'))}`);
        try {
          console.log('Chama createConnection');
          const db = await this.databaseService.createConnection("oficina", false, "no-encryption", 1);
          this.initPlugin = true;
          // console.log(`Após criação da conexão com a base de dados ${JSON.stringify(db)}`);
        } catch (err) {
          console.log(`Error: ${err}`);
          this.initPlugin = false;
        }


        console.log('Status da inicialização do plugin: ' + this.initPlugin);
      });
    });
  }
}
