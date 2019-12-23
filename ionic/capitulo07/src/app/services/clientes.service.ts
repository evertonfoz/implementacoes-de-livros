import { Injectable } from '@angular/core';
import { Cliente } from '../models/cliente.model';
import { AngularFirestore, AngularFirestoreCollection } from '@angular/fire/firestore';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class ClientesService {
  constructor(
    private firestore: AngularFirestore
  ) { }

  async update(cliente: Cliente): Promise<void> {
    try {
      cliente.nascimento = new Date(cliente.nascimento);
      await this.firestore.doc(`clientes/${cliente.clienteid}`).set(cliente);
    } catch (e) {
      console.error(e);
    }
  }

  public getAll(): AngularFirestoreCollection<Cliente> {
    return this.firestore.collection('clientes', ref => ref.orderBy('nome', 'asc'));
  }

  async getById(clienteID: string): Promise<Cliente> {
    try {
      const cliente = await this.firestore.collection('clientes').doc(clienteID).ref.get();
      if (cliente.exists) {
          const dadosCliente = cliente.data();
          const nascimento = dadosCliente.nascimento.toDate();
          return  {
              clienteid: dadosCliente.clienteid, nome: dadosCliente.nome, email: dadosCliente.email,
              telefone: dadosCliente.telefone, renda: dadosCliente.renda,
              nascimento: new Date(nascimento)
          };
      }
    } catch (e) {
      console.log(e);
    }
  }

  async removeById(clienteId: string): Promise<void> {
    return this.firestore.doc(`clientes/${clienteId}`).delete();
  }

  public getByNome(nome: string): Observable<Cliente[]> {
    const clientes: Observable<Cliente[]> = this.getAll().valueChanges();

    if (!nome) {
        return clientes;
    }

    return clientes.pipe(
        map(result =>
            result.filter(
                cliente => cliente.nome.toLowerCase().startsWith(nome.toLowerCase()))
        )
    );
  }
}
