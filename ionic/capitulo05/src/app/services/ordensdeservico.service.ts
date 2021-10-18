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
        const db = await this.databaseService.retrieveConnection('oficina')
        let returnQuery = await db.query("SELECT * FROM ordensdeservico;");

        console.log(`db: ${db}`);

        if (returnQuery.values.length > 0) {
            let ordensdeservico: OrdemDeServico[] = [];
            for (let i = 0; i < returnQuery.values.length; i++) {
                const ordemdeservico = returnQuery.values[i];
                console.log(`OS> ${ordemdeservico}`);
                ordensdeservico.push(ordemdeservico);
            }
            return ordensdeservico;
        }

        return [];
    }
}
