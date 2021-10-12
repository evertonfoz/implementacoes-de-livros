import { Component } from '@angular/core';
import { SQLiteDBConnection } from '@capacitor-community/sqlite';
import { Platform } from '@ionic/angular';
import { Storage } from '@ionic/storage-angular';
import { DetailService } from './services/detail.service';
import { SQLiteService } from './services/sqlite.service';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {
  private initPlugin: boolean;
  public isWeb: boolean = false;

  constructor(
    private storage: Storage,
    private platform: Platform,
    private sqlite: SQLiteService,
    private detail: DetailService
  ) {
    this.initializeApp();
  }

  async ngOnInit() {
    await this.storage.create();
  }

  async initializeApp() {
    this.platform.ready().then(async () => {
      this.detail.setExistingConnection(false);
      // this.detail.setExportJson(false);
      this.sqlite.initializePlugin().then(async (ret) => {
        this.initPlugin = ret;
        const p: string = this.sqlite.platform;
        console.log(`plaform ${p}`);

        try {
          console.log(`going to create a connection`)
          const db = await this.sqlite.createConnection("oficina", false, "no-encryption", 1);
          console.log(`db ${JSON.stringify(db)}`)
          await db.open();
          console.log(`after db.open`)
          let query = `
          CREATE TABLE IF NOT EXISTS ordensdeservico (
                  ordemdeservicoid TEXT primary key NOT NULL,
                      clienteid TEXT NOT NULL,
                      veiculo TEXT NOT NULL,
                      dataehoraentrada DATETIME NOT NULL,
                      dataehoratermino DATETIME,
                      dataehoraentrega DATETIME
                    );
          `
          console.log(`query ${query}`)

          const res: any = await db.execute(query);
          console.log(`res: ${JSON.stringify(res)}`)

          await db.close();
          console.log(`after db.close`)
        } catch (err) {
          console.log(`Error: ${err}`);
          this.initPlugin = false;
        }


        console.log(">>>> in App  this.initPlugin " + this.initPlugin)
      });
    });
  }
}
