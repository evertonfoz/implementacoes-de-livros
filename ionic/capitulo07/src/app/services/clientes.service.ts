import { ChangeDetectorRef, Injectable } from '@angular/core';
import { Cliente } from '../models/cliente.model';
import { Firestore, collection, collectionData } from '@angular/fire/firestore';
import { Observable } from 'rxjs';

import { child, get, getDatabase, push, onValue, ref, query, orderByChild, DataSnapshot } from 'firebase/database';

@Injectable({
    providedIn: 'root'
})
export class ClientesService {
    constructor(
        private _fireStore: Firestore,
    ) {
    }



    async create(cliente: Cliente): Promise<void> {
        try {
            const databaseReference = getDatabase(this._fireStore.app);
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

    async getAll(): Promise<Cliente[]> {
        let clientes: Cliente[] = [];
        const dbRef = ref(getDatabase(this._fireStore.app));

        let dataSnapshot: DataSnapshot;
        dataSnapshot = await get(child(dbRef, 'clientes/'));
        dataSnapshot.forEach((childSnapshot) => {
            let cliente = <Cliente>{
                clienteid: childSnapshot.key,
                nome: childSnapshot.val().nome,
                email: childSnapshot.val().email,
                telefone: childSnapshot.val().telefone,
                renda: childSnapshot.val().renda,
                nascimento: childSnapshot.val().nascimento,
            }
            clientes.push(cliente);
        });

        return clientes;
    }
}