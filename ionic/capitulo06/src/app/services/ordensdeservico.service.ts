import { Injectable } from '@angular/core';
import { OrdemDeServico } from '../models/ordemdeservico.model';
import { DatabaseService } from './database.service';
import { databaseName } from './database.statements';

@Injectable({
    providedIn: 'root'
})
export class OrdensDeServicoService {
    constructor(
        private databaseService: DatabaseService
    ) { }

    public async getAll() {
        const db = await this.databaseService.sqliteConnection.retrieveConnection(databaseName);

        db.open();

        let returnQuery = await db.query("SELECT * FROM ordensdeservico;");

        let ordensdeservico: OrdemDeServico[] = [];
        if (returnQuery.values.length > 0) {
            for (let i = 0; i < returnQuery.values.length; i++) {
                const ordemdeservico = returnQuery.values[i];
                console.log(`OS> ${ordemdeservico}`);
                ordensdeservico.push(ordemdeservico);
            }
        }

        return ordensdeservico;
    }

    public async getById(id: string): Promise<any> {
        try {
            const db = await this.databaseService.sqliteConnection.retrieveConnection(databaseName);
            const sql = 'select * from ordensdeservico where ordemdeservicoid = ?';
            try {
                db.open();
                const data = await db.query(sql, [id]);
                db.close();
                if (data.values.length > 0) {
                    const ordemdeservico: OrdemDeServico = data.values[0];
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
}