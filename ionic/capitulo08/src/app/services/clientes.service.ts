import { ChangeDetectorRef, Injectable } from '@angular/core';
import { Cliente, clienteConverter } from '../models/cliente.model';
import { Firestore, collection, getDocs, setDoc, doc, query, QuerySnapshot, onSnapshot, Query, orderBy, getDoc, deleteDoc } from '@angular/fire/firestore';
import { getStorage, uploadBytes, ref as storageRef, StorageReference, getDownloadURL, FirebaseStorage, deleteObject } from 'firebase/storage';
import { getDatabase, refFromURL } from '@firebase/database';


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
            // const databaseReference = getDatabase(this._fireStore.app);
            cliente.nascimento = new Date(cliente.nascimento);

            const clientesRef = collection(this._fireStore, "clientes");

            await setDoc(doc(clientesRef).
                withConverter(clienteConverter), cliente);
            // await setDoc(doc(clientesRef), {
            //     nome: cliente.nome,
            //     email: cliente.email,
            //     telefone: cliente.telefone,
            //     renda: cliente.renda,
            //     nascimento: cliente.nascimento,
            //     foto: cliente.foto
            // });
        } catch (e) {
            console.error(e);
        }
    }

    async getById(clienteId: string): Promise<Cliente> {
        const q = doc(this._fireStore, "clientes", clienteId).withConverter(clienteConverter);
        const querySnapshot = await getDoc(q);

        return querySnapshot.data();
    }

    async removeById(clienteId: string) {
        await deleteDoc(doc(this._fireStore, "clientes", clienteId));
    }

    async update(cliente: Cliente) {
        cliente.nascimento = new Date(cliente.nascimento);

        await setDoc(doc(this._fireStore, "clientes", cliente.clienteid).
            withConverter(clienteConverter), cliente);
    }

    async getAll(): Promise<Cliente[]> {
        const clientes: Cliente[] = [];
        const q = query(collection(this._fireStore, "clientes"), orderBy("nome")).withConverter(clienteConverter);
        const querySnapshot = await getDocs(q);
        querySnapshot.forEach((doc) => {
            clientes.push(doc.data());
        });
        return clientes;
    }

    async getByNome(nome: string): Promise<Cliente[]> {
        const clientes: Cliente[] = await this.getAll();

        if (!nome) {
            return clientes;
        }

        return clientes.filter(
            cliente => cliente.nome.toLowerCase().startsWith(nome.toLowerCase()));
    }

    async removerImagem(nomeImagem) {
        try {
            const storage: FirebaseStorage = getStorage(this._fireStore.app, this._fireStore.app.options.storageBucket);
            const storageReference = storageRef(storage, "fotosClientes/" + nomeImagem);
            await deleteObject(storageReference);
        } catch (e) {
            console.log(e);
        }
    }
}