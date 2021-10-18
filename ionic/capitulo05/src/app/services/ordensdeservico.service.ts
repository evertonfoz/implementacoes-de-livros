import { Injectable } from '@angular/core';
import { OrdemDeServico } from '../models/ordemdeservico.model';
import { DatabaseService } from './database.service';

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
}