import { Injectable } from '@angular/core';
import { Cliente, clienteConverter } from '../models/cliente.model';
import { Firestore, collection, getDocs, query, orderBy, } from '@angular/fire/firestore';
import { AutenticacaoService } from './autenticacao.service';


@Injectable({
    providedIn: 'root'
})
export class ClientesService {
    constructor(
        private _fireStore: Firestore,
        private autenticacaoService: AutenticacaoService
    ) {
    }

    async getAll(): Promise<Cliente[]> {
        if (!this.autenticacaoService.isUserAuthenticated()) {
            throw new Error('Usuário não está autenticado');
        }
        const clientes: Cliente[] = [];
        const q = query(collection(this._fireStore, "clientes"), orderBy("nome")).withConverter(clienteConverter);
        const querySnapshot = await getDocs(q);
        querySnapshot.forEach((doc) => {
            clientes.push(doc.data());
        });
        return clientes;
    }
}