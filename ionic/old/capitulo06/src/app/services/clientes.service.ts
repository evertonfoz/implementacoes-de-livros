import { Injectable } from '@angular/core';
import { DatabaseService } from './database.service';
import { Cliente } from '../models/cliente.model';

@Injectable({
    providedIn: 'root'
})
export class ClientesService {
  constructor(
      private databaseService: DatabaseService
  ) { }

  public async getAll() {
    try {
      const db = await this.databaseService.getDatabase();
      const sql = 'SELECT * FROM clientes ORDER BY nome';
      try {
        const data = await db.executeSql(sql, []);
        if (data.rows.length > 0) {
          // tslint:disable-next-line:prefer-const
          let clientes: Cliente[] = [];
          for (let i = 0; i < data.rows.length; i++) {
            const cliente = data.rows.item(i);
            clientes.push(cliente);
          }
          return clientes;
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
}
