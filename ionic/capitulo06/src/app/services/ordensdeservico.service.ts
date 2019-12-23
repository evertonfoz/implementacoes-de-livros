import { Injectable } from '@angular/core';
import { DatabaseService } from './database.service';
import { OrdemDeServico } from '../models/ordemdeservico.model';
import { Guid } from 'guid-typescript';

@Injectable({
    providedIn: 'root'
})
export class OrdensDeServicoService {
  constructor(
      private databaseService: DatabaseService
  ) { }

  public async getAll() {
    try {
      const db = await this.databaseService.getDatabase();
      const sql = 'SELECT * FROM ordensdeservico';
      try {
        const data = await db.executeSql(sql, []);
        if (data.rows.length > 0) {
          // tslint:disable-next-line:prefer-const
          let ordensdeservico: OrdemDeServico[] = [];
          for (let i = 0; i < data.rows.length; i++) {
            const ordemdeservico = data.rows.item(i);
            ordensdeservico.push(ordemdeservico);
          }
          return ordensdeservico;
        } else {
          return [];
        }
      } catch (e) {
        return console.error(e);
      }
    } catch (e) {
      return console.error(e);
    }
  }

  public async getById(id: string): Promise<any> {
    try {
      const db = await this.databaseService.getDatabase();
      const sql = 'select * from ordensdeservico where ordemdeservicoid = ?';
      try {
        const data = await db.executeSql(sql, [ id ]);
        if (data.rows.length > 0) {
            const ordemdeservico: OrdemDeServico = data.rows.item(0);
            ordemdeservico.dataehoraentrada = new Date(ordemdeservico.dataehoraentrada);
            return ordemdeservico;
        } else {
          return null;
        }
      } catch (e) {
        return console.error(e);
      }
    } catch (e) {
      return console.error(e);
    }
  }

  async update(ordemdeservico: OrdemDeServico): Promise<OrdemDeServico> {
    let sql: any;
    let params: any;

    if (Guid.parse(ordemdeservico.ordemdeservicoid).isEmpty()) {
      ordemdeservico.ordemdeservicoid = Guid.create().toString();
      sql = 'INSERT INTO ordensdeservico(ordemdeservicoid, clienteid, veiculo, dataehoraentrada) ' +
        'values(?, ?, ?, ?)';
      params = [ordemdeservico.ordemdeservicoid, ordemdeservico.clienteid,
        ordemdeservico.veiculo, ordemdeservico.dataehoraentrada ];
    } else {
      sql = 'UPDATE ordensdeservico SET clienteid = ?, veiculo = ?, ' +
        'dataehoraentrega = ? WHERE ordemdeservicoid = ?';
      params = [ordemdeservico.clienteid,
        ordemdeservico.veiculo, ordemdeservico.dataehoraentrada, ordemdeservico.ordemdeservicoid ];
    }

    try {
      const db = await this.databaseService.getDatabase();
      try {
        await db.executeSql(sql, params);
        return ordemdeservico;
      } catch (e) {
        console.error(e);
      }
    } catch (e) {
      console.error(e);
    }
  }

  async removeById(id: string): Promise<boolean | void> {
    try {
      await this.databaseService.getDatabase()
        .then( async (db) => await db.executeSql('DELETE FROM ordensdeservico WHERE ordemdeservicoid = ?', [ id ])
        .then( () => true));
    } catch (e) {
      throw new Error(e);
    }
  }
}
