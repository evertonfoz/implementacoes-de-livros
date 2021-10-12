import { Component, OnInit, ViewChild } from '@angular/core';
import { PecasService } from '../../../services/pecas.service';
import { Peca } from '../../../models/peca.model';
import { ToastService } from '../../../services/toast.service';
import { IonList } from '@ionic/angular';
import { Guid } from 'guid-typescript';
import { SQLiteService } from 'src/app/services/sqlite.service';
import { DetailService } from 'src/app/services/detail.service';
import { Dialog } from '@capacitor/dialog';
import { SQLiteDBConnection } from '@capacitor-community/sqlite';
import { deleteDatabase } from 'src/app/utils/db-utils';
import { createSchema, twoTests, twoUsers } from 'src/app/utils/no-encryption-utils';

@Component({
  templateUrl: './pecas-listagem.page.html'
})
export class PecasListagemPage implements OnInit {
  @ViewChild('slidingList') slidingList: IonList;

  detail: boolean = false;
  sqlite: any;
  platform: string;
  handlerPermissions: any;
  initPlugin: boolean = false;

  constructor(
    private pecasService: PecasService,
    private toastService: ToastService,
    private _sqlite: SQLiteService,
    private _detailService: DetailService,) {
  }

  async ngAfterViewInit() {
    const showAlert = async (message: string) => {
      await Dialog.alert({
        title: 'Error Dialog',
        message: message,
      });
    };
    try {
      await this.runTest();
      // document.querySelector('.sql-allsuccess').classList
      //   .remove('display');
      console.log("$$$ runTest was successful");
    } catch (err) {
      // document.querySelector('.sql-allfailure').classList
      // .remove('display');
      console.log(`$$$ runTest failed ${err.message}`);
      await showAlert(err.message);
    }
  }




  async runTest(): Promise<void> {
    try {
      let result: any = await this._sqlite.echo("Hello World from Jeep");
      console.log(`from echo: ${result.value}`);
      let db: SQLiteDBConnection;
      // let db1: SQLiteDBConnection;
      if ((await this._sqlite.isConnection("oficina")).result) {
        db = await this._sqlite.retrieveConnection("oficina");
      } else {
        console.log(7);
        db = await this._sqlite
          .createConnection("oficina", false, "no-encryption", 1);
        console.log(8);
      }
      // check if the databases exist 
      // and delete it for multiple successive tests
      console.log(9);
      await deleteDatabase(db);
      console.log(10);

      // open db testNew
      await db.open();
      console.log(11);

      // create tables in db
      let ret: any = await db.execute(createSchema);
      console.log(111);
      if (ret.changes.changes < 0) {
        console.log(112);
        return Promise.reject(new Error("Execute createSchema failed"));
      }
      console.log(13);

      // create synchronization table 
      ret = await db.createSyncTable();
      console.log(14);

      // set the synchronization date
      const syncDate: string = "2020-11-25T08:30:25.000Z";
      console.log(15);
      await db.setSyncDate(syncDate);
      console.log(16);

      // delete users if any from previous run
      let delUsers = `DELETE FROM users;`;
      console.log(17);
      ret = await db.execute(delUsers, false);
      console.log(18);

      // add two users in db
      ret = await db.execute(twoUsers);
      console.log(19);
      if (ret.changes.changes !== 2) {
        console.log(20);
        return Promise.reject(new Error("Execute 2 users failed"));
      }
      console.log(21);
      // select all users in db
      ret = await db.query("SELECT * FROM users;");
      console.log(22);
      if (ret.values.length !== 2 || ret.values[0].name !== "Whiteley" ||
        ret.values[1].name !== "Jones") {
        console.log(24);
        return Promise.reject(new Error("Query 2 users failed"));
      }

      // select users where company is NULL in db
      console.log(25);
      ret = await db.query("SELECT * FROM users WHERE company IS NULL;");
      console.log(26);
      if (ret.values.length !== 2 || ret.values[0].name !== "Whiteley" ||
        ret.values[1].name !== "Jones") {
        console.log(27);
        return Promise.reject(new Error("Query 2 users where company is null failed"));
      }
      console.log(28);
      // add one user with statement and values
      let sqlcmd: string =
        "INSERT INTO users (name,email,age,size,company) VALUES (?,?,?,?,?)";
      console.log(29);
      let values: Array<any> = ["Simpson", "Simpson@example.com", 69, 1.82, null];
      console.log(30);
      ret = await db.run(sqlcmd, values);
      console.log(31);
      if (ret.changes.lastId !== 3) {
        console.log(32);
        return Promise.reject(new Error("Run 1 users with statement & values failed"));
      }
      console.log(33);
      // add one user with statement
      sqlcmd = `INSERT INTO users (name,email,age,size,company) VALUES ` +
        `("Brown","Brown@example.com",15,1.75,null)`;
      console.log(34);
      ret = await db.run(sqlcmd);
      console.log(35);
      if (ret.changes.lastId !== 4) {
        console.log(36);
        return Promise.reject(new Error("Run 1 users with statement failed"));
      }
      console.log(37);
      let delTest56 = `DELETE FROM test56;`;
      console.log(38);
      ret = await db.execute(delTest56, false);
      console.log(39);
      // add some tests issue#56
      ret = await db.execute(twoTests);
      console.log(40);
      if (ret.changes.changes !== 2) {
        console.log(41);
        return Promise.reject(new Error("Execute issue#56 failed"));
      }
      // add one test
      console.log(42);
      sqlcmd = "INSERT INTO test56 (name) VALUES (?)";
      console.log(43);
      let vals: Array<any> = ["test 3 added insert "];
      console.log(44);
      ret = await db.run(sqlcmd, vals);
      console.log(45);
      if (ret.changes.changes !== 1 || ret.changes.lastId !== 3) {
        console.log(46);
        return Promise.reject(new Error("Run 1 test issue#56 failed"));
      }
      console.log(47);
      // add a null test
      vals = [null];
      console.log(48);
      ret = await db.run(sqlcmd, vals);
      console.log(49);
      if (ret.changes.changes !== 1 || ret.changes.lastId !== 4) {
        console.log(50);
        return Promise.reject(new Error("Run 1 test null issue#56 failed"));
      }
      // add a another null test
      console.log(51);
      vals = [];
      console.log(52);
      ret = await db.run(sqlcmd, vals);
      console.log(53);
      if (ret.changes.changes !== 1 || ret.changes.lastId !== 5) {
        console.log(54);
        return Promise.reject(new Error("Run another null test issue#56 failed"));
      }
      console.log(55);
      // add test [null, 'test2']
      sqlcmd = "INSERT INTO test56 (name,name1) VALUES (?,?)";
      console.log(56);
      vals = [null, 'test2']
      console.log(57);
      ret = await db.run(sqlcmd, vals);
      console.log(58);
      if (ret.changes.changes !== 1 || ret.changes.lastId !== 6) {
        console.log(59);
        return Promise.reject(new Error("Run [null, 'test2'] test issue#56 failed"));
      }
      console.log(60);
      // get the database version
      ret = await db.getVersion();
      console.log(61);
      if (ret.version !== 1) {
        console.log(62);
        return Promise.reject(new Error("GetVersion: version failed"));
      }
      console.log(63);
      this._detailService.setExistingConnection(true);
      console.log(64);
      return Promise.resolve();
    } catch (err) {
      console.log(65);
      return Promise.reject(err);
    }
  }

  // idAsString(id: Guid): string {
  //   const convertedId = JSON.parse(JSON.stringify(id));
  //   return convertedId.value;
  // }

  ngOnInit(): void {
    // this.pecasService.getAll().then(pecas => {
    //   this.pecas = pecas;
    // });
  }

  // ionViewWillEnter() {
  //   this.pecasService.getAll().then(pecas => {
  //     this.pecas = pecas;
  //   });
  // }

  // async removerPeca(peca: Peca) {
  //   await this.pecasService.removeById(this.idAsString(peca.id));
  //   this.pecas = await this.pecasService.getAll();
  //   this.toastService.presentToast('Peça removida', 3000, 'top');
  //   await this.slidingList.closeSlidingItems();
  // }
}