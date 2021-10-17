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
          console.log(`Após criação da conexão com a base de dados ${JSON.stringify(db)}`);

          await db.open();
          console.log(`Após abertura da base de dados`)

          // create tables in db
          let createSchemma: any = await db.execute(createSchema);
          if (createSchemma.changes.changes < 0) {
            return Promise.reject(new Error("Erro na criação das tabelas"));
          }
          console.log(`criação das tabelas: ${JSON.stringify(createSchemma)}`)

          this.initPlugin = ret;

          await db.close();
          console.log(`Após o fechamento da base de dados`)
        } catch (err) {
          console.log(`Error: ${err}`);
          this.initPlugin = false;
        }


        console.log('Status da inicialização do plugin: ' + this.initPlugin);
      });
    });
  }
}
