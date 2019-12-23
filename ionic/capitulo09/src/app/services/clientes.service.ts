import { Injectable } from '@angular/core';
import { Cliente } from '../models/cliente.model';
import { AngularFirestore, AngularFirestoreCollection } from '@angular/fire/firestore';
import { AutenticacaoService } from './autenticacao.service';

@Injectable({
    providedIn: 'root'
})
export class ClientesService {
  constructor(
    private firestore: AngularFirestore,
    private autenticacaoService: AutenticacaoService
  ) { }

  public getAll(): AngularFirestoreCollection<Cliente> {
    if (!this.autenticacaoService.isUserAuthenticated()) {
      throw new Error('Usuário não está autenticado');
    }
    return this.firestore.collection('clientes', ref => ref.orderBy('nome', 'asc'));
  }
}
