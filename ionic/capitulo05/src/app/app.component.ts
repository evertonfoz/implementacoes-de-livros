import { Component } from '@angular/core';
import { SQLiteDBConnection } from '@capacitor-community/sqlite';
import { Platform } from '@ionic/angular';
import { Storage } from '@ionic/storage-angular';
import { DatabaseService } from './services/database.service';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {
  private initPlugin: boolean;

  constructor(
    private storage: Storage,
    private platform: Platform,
    private sqlite: DatabaseService,
  ) {
    this.initializeApp();
  }

  async ngOnInit() {
    await this.storage.create();
  }

  async initializeApp() {
    this.platform.ready().then(async () => {
      this.sqlite.initializePlugin().then(async (ret) => {
        try {
          let db: SQLiteDBConnection;
          // let isDatabase = (await this.sqlite.isDatabase('oficina10')).result;
          console.log((await this.sqlite.isDatabase('oficina')).result);
          console.log(await this.sqlite.openConnection('oficina'));
          // if (!isDatabase) {
          //   const db = await this.sqlite.createConnection("oficina", false, "no-encryption", 1);
          //   console.log(`Após criação da conexão com a base de dados ${JSON.stringify(db)}`);
          // } else {
          //   if ((await this.sqlite.isConnection("oficina")).result) {
          //     db = await this.sqlite.retrieveConnection("oficina");
          //   } else {
          //     console.log('não rolou');
          //   }
          // }



          // await db.open();
          // console.log(`Após abertura da base de dados`)

          // this.initPlugin = ret;

          // await db.close();
          // console.log(`Após o fechamento da base de dados`)
        } catch (err) {
          console.log(`Ocorreu o erro: ${err}`);
          this.initPlugin = false;
        }


        console.log('Status da inicialização do plugin: ' + this.initPlugin);
      });
    });
  }
}
