import { Component, OnInit } from '@angular/core';
import { DatabaseService } from 'src/app/services/database.service';
import { databaseName } from 'src/app/services/database.statements';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.page.html',
  styleUrls: ['./dashboard.page.scss'],
})
export class DashboardPage implements OnInit {

  constructor(
    // private _databaseService: DatabaseService
  ) { }

  ngOnInit() {
    console.log('ngOnInit');
  }

  async ngAfterViewInit() {
    console.log('ngAfterViewInit');
    // await this.runTest();
  }

  async runTest(): Promise<void> {
    try {
      console.log('runTest');
      // let result: any = await this._databaseService.echo("Hello World");

      // retrieve the connections
      // const db = await this._databaseService.retrieveConnection(databaseName)
      // console.log('Deu dashboard');
      // const db1 = await this._sqlite.retrieveConnection("testSet")

      // load setUsers in db
      // var ret: any = await db.executeSet(setUsers);
      // if (ret.changes.changes !== 3) {
      //   return Promise.reject(new Error("executeSet setUsers failed"));
      // }
      // select all users in db
      // ret = await db.query("SELECT * FROM users;");
      // if (ret.values.length !== 7 || ret.values[0].name !== "Whiteley" ||
      //   ret.values[1].name !== "Jones" ||
      //   ret.values[2].name !== "Simpson" ||
      //   ret.values[3].name !== "Brown" ||
      //   ret.values[4].name !== "Jackson" ||
      //   ret.values[5].name !== "Kennedy" ||
      //   ret.values[6].name !== "Bush"
      // ) {
      //   return Promise.reject(new Error("Query 7 Users failed"));
      // }

      // create table messages in db1
      // ret = await db1.execute(createSchemaMessages);
      // if (ret.changes.changes < 0) {
      //   return Promise.reject(new Error("execute createSchemaMessages failed"));
      // }

      // load setMessages in db1
      // ret = await db1.executeSet(setMessages);
      // if (ret.changes.changes !== 3) {
      //   return Promise.reject(new Error("executeSet setMessages failed"));
      // }
      // select all users in db
      // ret = await db1.query("SELECT * FROM messages;");
      // if (ret.values.length !== 3 || ret.values[0].title !== "message 1" ||
      //   ret.values[1].title !== "message 2" ||
      //   ret.values[2].title !== "message 3"
      // ) {
      //   return Promise.reject(new Error("Query 3 Messages failed"));
      // }

      // test retrieve all connections
      // var retDict: Map<string, any> = await
      //   this._sqlite.retrieveAllConnections();
      // if (!retDict.has("testNew") || retDict.get("testNew") != db) {
      //   return Promise.reject(new Error("retrieveAllConnections has TestNew failed"));
      // }
      // if (!retDict.has("testSet") || retDict.get("testSet") != db1) {
      //   return Promise.reject(new Error("retrieveAllConnections has TestSet failed"));
      // }

      // await this._databaseService.closeAllConnections();

      // this._detailService.setExistingConnection(false);
      return Promise.resolve();
    } catch (err) {
      return Promise.reject(err);
    }

  }

}
