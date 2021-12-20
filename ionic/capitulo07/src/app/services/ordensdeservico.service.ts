import { Injectable } from '@angular/core';
import { collection, deleteDoc, doc, Firestore, getDoc, getDocs, orderBy, query, setDoc } from '@angular/fire/firestore';
import { OrdemDeServico, ordemDeServicoConverter } from '../models/ordemdeservico.model';

@Injectable({
    providedIn: 'root'
})
export class OrdensDeServicoService {
    constructor(
        private _fireStore: Firestore,
    ) { }

    public async getAll(): Promise<OrdemDeServico[]> {
        const ordensDeServico: OrdemDeServico[] = [];
        const q = query(collection(this._fireStore, "ordensdeservico"), orderBy("dataehoraentrada", "desc")).withConverter(ordemDeServicoConverter);
        const querySnapshot = await getDocs(q);
        querySnapshot.forEach((doc) => {
            ordensDeServico.push(doc.data());
        });
        return ordensDeServico;
    }

    async update(ordemDeServico: OrdemDeServico) {
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

    async getById(clienteId: string): Promise<OrdemDeServico> {
        const q = doc(this._fireStore, "ordensdeservico", clienteId).withConverter(ordemDeServicoConverter);
        const querySnapshot = await getDoc(q);

        return querySnapshot.data();
    }

    async removeById(ordensDeServicoId: string) {
        await deleteDoc(doc(this._fireStore, "ordensdeservico", ordensDeServicoId));
    }
}