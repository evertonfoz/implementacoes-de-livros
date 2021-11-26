import { Injectable } from '@angular/core';
import { collection, deleteDoc, doc, Firestore, getDoc, getDocs, orderBy, query, setDoc } from '@angular/fire/firestore';
import { OrdemDeServico, ordemDeServicoConverter } from '../models/ordemdeservico.model';

@Injectable({
    providedIn: 'root'
})

export class OrdensDeServicoService {
    // private initPlugin: boolean;

    constructor(
        private _fireStore: Firestore,
    ) { }

    async getById(clienteId: string): Promise<OrdemDeServico> {
        const q = doc(this._fireStore, "ordensdeservico", clienteId).withConverter(ordemDeServicoConverter);
        const querySnapshot = await getDoc(q);

        return querySnapshot.data();
    }

    public async getAll(): Promise<OrdemDeServico[]> {
        const ordensDeServico: OrdemDeServico[] = [];
        const q = query(collection(this._fireStore, "ordensdeservico"), orderBy("dataehoraentrada", "desc")).
            withConverter(ordemDeServicoConverter);
        const querySnapshot = await getDocs(q);
        querySnapshot.forEach((doc) => {
            ordensDeServico.push(doc.data());
        });
        return ordensDeServico;
    }

    async removeById(ordensDeServicoId: string) {
        await deleteDoc(doc(this._fireStore, "ordensdeservico", ordensDeServicoId));
    }

    async update(ordemDeServico: OrdemDeServico) {
        // console.log('---> ' + ordemDeServico.ordemdeservicoid);

        ordemDeServico.dataehoraentrada = new Date(ordemDeServico.dataehoraentrada);
        const clientesRef = collection(this._fireStore, "ordensdeservico");

        if (ordemDeServico.ordemdeservicoid.length == 0) {
            await setDoc(doc(clientesRef).
                withConverter(ordemDeServicoConverter), ordemDeServico);

        } else {
            await setDoc(doc(this._fireStore, "ordensdeservico", ordemDeServico.ordemdeservicoid).
                withConverter(ordemDeServicoConverter), ordemDeServico);
        }
    }


    // public async getById(id: string): Promise<any> {
    //     try {
    //         const db = await this.databaseService.retrieveConnection(databaseName);
    //         const sql = 'select * from ordensdeservico where ordemdeservicoid = ?';
    //         try {
    //             db.open();
    //             const data = await db.query(sql, [id]);
    //             db.close();
    //             console.log('data --> ' + data.values[0]);
    //             if (data.values.length > 0) {
    //                 const ordemdeservico: OrdemDeServico = data.values[0];
    //                 ordemdeservico.dataehoraentrada = new Date(ordemdeservico.dataehoraentrada);
    //                 return ordemdeservico;
    //             } else {
    //                 return null;
    //             }
    //         } catch (e) {
    //             return console.error(e);
    //         }
    //     } catch (e) {
    //         return console.error(e);
    //     }
    // }

    // async update(ordemdeservico: OrdemDeServico): Promise<OrdemDeServico> {
    //     let sql: any;
    //     let params: any;

    //     if (Guid.parse(ordemdeservico.ordemdeservicoid).isEmpty()) {
    //         ordemdeservico.ordemdeservicoid = Guid.create().toString();
    //         sql = 'INSERT INTO ordensdeservico(ordemdeservicoid, clienteid, veiculo, dataehoraentrada) ' +
    //             'values(?, ?, ?, ?)';
    //         params = [ordemdeservico.ordemdeservicoid, ordemdeservico.clienteid,
    //         ordemdeservico.veiculo, ordemdeservico.dataehoraentrada];
    //     } else {
    //         sql = 'UPDATE ordensdeservico SET clienteid = ?, veiculo = ?, ' +
    //             'dataehoraentrega = ? WHERE ordemdeservicoid = ?';
    //         params = [ordemdeservico.clienteid,
    //         ordemdeservico.veiculo, ordemdeservico.dataehoraentrada, ordemdeservico.ordemdeservicoid];
    //     }

    //     try {
    //         const db = await this.databaseService.retrieveConnection(databaseName);
    //         db.open();
    //         await db.run(sql, params);
    //         db.close();
    //     } catch (e) {
    //         console.error(e);
    //     }

    //     return ordemdeservico;
    // }

    // async removeById(id: string): Promise<boolean | void> {
    //     try {
    //         const db = await this.databaseService.retrieveConnection(databaseName);
    //         db.open();
    //         await db.run('DELETE FROM ordensdeservico WHERE ordemdeservicoid = ?', [id]);
    //         db.close();
    //         return true;
    //     } catch (e) {
    //         console.error(e);
    //     }
    // }
}
