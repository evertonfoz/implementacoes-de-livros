import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { OrdemDeServico } from '../models/ordemdeservico.model';
import { DatabaseService } from './database.service';
import { databaseName } from './database.statements';

@Injectable({
    providedIn: 'root'
})

export class OrdensDeServicoService {
    // private initPlugin: boolean;

    constructor(
        private databaseService: DatabaseService
    ) { }

    // async initializeApp() {
    //     console.log(`this.initPlugin = ${this.initPlugin}`);

    //     this.platform.ready().then(async () => {
    //         this.databaseService.initializePlugin().then(async (ret) => {
    //             try {
    //                 console.log('Chama createConnection');
    //                 const db = await this.databaseService.createConnection("oficina11", false, "no-encryption", 1);
    //                 this.initPlugin = true;
    //             } catch (err) {
    //                 console.log(`Error: ${err}`);
    //                 this.initPlugin = false;
    //             }


    //             console.log('Status da inicialização do plugin: ' + this.initPlugin);
    //         });
    //     });
    // }

    public async getAll() {
        console.log('Teste OrdensDeServicoService: ' + (this.databaseService.isConnection(databaseName).then(function (result) { console.log('result: ' + result.result) })));
        console.log('getAll');
        const db = await this.databaseService.retrieveConnection(databaseName);

        console.log(`db connection created ${JSON.stringify(db)}`);

        db.open();
        console.log('Abriu conexão');
        let returnQuery = await db.query("SELECT * FROM ordensdeservico;");
        db.close();
        console.log('Fechou conexão');

        console.log(`returnQuery: ${returnQuery}`);

        if (returnQuery.values.length > 0) {
            let ordensdeservico: OrdemDeServico[] = [];
            for (let i = 0; i < returnQuery.values.length; i++) {
                const ordemdeservico = returnQuery.values[i];
                // console.log(`OS> ${ordemdeservico}`);
                ordensdeservico.push(ordemdeservico);
            }
            return ordensdeservico;
        }

        return [];
    }

    public async getById(id: string): Promise<any> {
        try {
            const db = await this.databaseService.retrieveConnection(databaseName);
            const sql = 'select * from ordensdeservico where ordemdeservicoid = ?';
            try {
                db.open();
                const data = await db.query(sql, [id]);
                db.close();
                console.log('data --> ' + data.values[0]);
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

    async update(ordemdeservico: OrdemDeServico): Promise<OrdemDeServico> {
        let sql: any;
        let params: any;

        if (Guid.parse(ordemdeservico.ordemdeservicoid).isEmpty()) {
            ordemdeservico.ordemdeservicoid = Guid.create().toString();
            sql = 'INSERT INTO ordensdeservico(ordemdeservicoid, clienteid, veiculo, dataehoraentrada) ' +
                'values(?, ?, ?, ?)';
            params = [ordemdeservico.ordemdeservicoid, ordemdeservico.clienteid,
            ordemdeservico.veiculo, ordemdeservico.dataehoraentrada];
        } else {
            sql = 'UPDATE ordensdeservico SET clienteid = ?, veiculo = ?, ' +
                'dataehoraentrega = ? WHERE ordemdeservicoid = ?';
            params = [ordemdeservico.clienteid,
            ordemdeservico.veiculo, ordemdeservico.dataehoraentrada, ordemdeservico.ordemdeservicoid];
        }

        try {
            const db = await this.databaseService.retrieveConnection(databaseName);
            db.open();
            await db.run(sql, params);
            db.close();
        } catch (e) {
            console.error(e);
        }

        return ordemdeservico;
    }

    async removeById(id: string): Promise<boolean | void> {
        try {
            const db = await this.databaseService.retrieveConnection(databaseName);
            db.open();
            await db.run('DELETE FROM ordensdeservico WHERE ordemdeservicoid = ?', [id]);
            db.close();
            return true;
        } catch (e) {
            console.error(e);
        }
    }
}
