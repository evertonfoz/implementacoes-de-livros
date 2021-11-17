import { Injectable } from '@angular/core';
import { Cliente } from '../models/cliente.model';
import { getDatabase, push, ref } from 'firebase/database';

@Injectable({
    providedIn: 'root'
})
export class ClientesService {
    constructor(
    ) { }

    async create(cliente: Cliente): Promise<void> {
        try {
            const databaseReference = getDatabase();
            cliente.nascimento = new Date(cliente.nascimento);
            push(ref(databaseReference, 'clientes/'), {
                nome: cliente.nome,
                email: cliente.email,
                telefone: cliente.telefone,
                renda: cliente.renda,
                nascimento: cliente.nascimento,
            });
        } catch (e) {
            console.error(e);
        }
    }

    // async get(cliente: Cliente): Promise<Cliente> {
    //     const databaseReference = ref(getDatabase());
    //     try {
    //         get(child(databaseReference, 'clientes/')).then(res => {
    //             // console.log(res.val());
    //             const databaseReference = getDatabase();
    //             const db = ref(databaseReference, 'clientes/');
    //             onValue(db, (snapshot) => {
    //                 const data = snapshot.val();
    //                 console.log('data = ', data);
    //             })

    //             var values = res.val();
    //             for (let value in values) {
    //                 var singleValue = values[value];
    //                 let cliente = {
    //                     clienteid: value,
    //                     nome: singleValue.nome,
    //                     email: singleValue.email,
    //                     telefone: singleValue.telefone,
    //                     renda: singleValue.renda,
    //                     nascimento: singleValue.nascimento,
    //                 }
    //                 console.log(singleValue);
    //             }
    //         });
    //         // await this.firestore.doc(`clientes/${cliente.clienteid}`).set(cliente);
    //     } catch (e) {
    //         console.error(e);
    //     }
    // }

    // remove(key: string) {
    //     console.log('key = ', key);
    //     const db = getDatabase();
    //     const dataToBeRemoved = ref(db, 'clientes/' + key);

    //     return remove(dataToBeRemoved);
    // }

    // update(key: string) {
    //     console.log('key = ', key);
    //     const db = getDatabase();

    //     const postData = {
    //         nome: 'cliente.nome',
    //         email: 'cliente.email',
    //         telefone: 'cliente.telefone',
    //         renda: 123,
    //         nascimento: Date.now(),
    //     }

    //     const updates = {};
    //     updates['clientes/' + key] = postData;

    //     return update(ref(db), updates);
    // }

    // public async getAll() {
    //     const db = await this.databaseService.retrieveConnection(databaseName);

    //     db.open();
    //     let returnQuery = await db.query("SELECT * FROM clientes ORDER BY nome");
    //     db.close();

    //     // console.log(`returnQuery: ${returnQuery}`);

    //     if (returnQuery.values.length > 0) {
    //         let clientes: Cliente[] = [];
    //         for (let i = 0; i < returnQuery.values.length; i++) {
    //             const cliente = returnQuery.values[i];
    //             // console.log(`OS> ${ordemdeservico}`);
    //             clientes.push(cliente);
    //         }
    //         return clientes;
    //     }

    //     return [];
    // }
}