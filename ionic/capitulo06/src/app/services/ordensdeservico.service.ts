import { Injectable } from '@angular/core';
import { OrdemDeServico } from '../models/ordemdeservico.model';
import { DatabaseService } from './database.service';

@Injectable({
    providedIn: 'root'
})

export class OrdensDeServicoService {
    private initPlugin: boolean;

    constructor(
        private databaseService: DatabaseService
    ) {

    }

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
        const db = await this.databaseService.retrieveConnection('oficina')

        db.open();
        console.log('Abriu conexão');
        let returnQuery = await db.query("SELECT * FROM ordensdeservico;");
        db.close();
        console.log('Fechou conexão');

        // console.log(`returnQuery: ${returnQuery}`);

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
}
