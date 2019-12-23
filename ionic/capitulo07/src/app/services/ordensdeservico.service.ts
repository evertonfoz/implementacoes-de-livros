import { Injectable } from '@angular/core';
import { OrdemDeServico } from '../models/ordemdeservico.model';
import { AngularFirestore, AngularFirestoreCollection } from '@angular/fire/firestore';

@Injectable({
    providedIn: 'root'
})
export class OrdensDeServicoService {
  constructor(
    private firestore: AngularFirestore
  ) { }

  public getAll(): AngularFirestoreCollection<OrdemDeServico> {
    return this.firestore.collection('ordensdeservico', ref => ref.orderBy('dataehoraentrada', 'desc'));
  }

  async update(ordemDeServico: OrdemDeServico): Promise<void> {
    try {
      const osParaGravar: OrdemDeServico = {
        ordemdeservicoid: ordemDeServico.ordemdeservicoid,
        clienteid: ordemDeServico.clienteid,
        veiculo: ordemDeServico.veiculo,
        dataehoraentrada: new Date(ordemDeServico.dataehoraentrada)
      };
      await this.firestore.doc(`ordensdeservico/${ordemDeServico.ordemdeservicoid}`).set(ordemDeServico);
    } catch (e) {
      console.error(e);
    }
  }

  async getById(ordemDeServicoId: string): Promise<OrdemDeServico> {
    try {
      const ordemDeServico = await this.firestore.collection('ordensdeservico').doc(ordemDeServicoId).ref.get();
      if (ordemDeServico.exists) {
          const dadosOS = await ordemDeServico.data();
          const dataehoradentrada = dadosOS.dataehoraentrada;
//          const dataehoradentrada = dadosOS.dataehoraentrada.toDate();

          return  {
            ordemdeservicoid: dadosOS.ordemdeservicoid, clienteid: dadosOS.clienteid,
            veiculo: dadosOS.veiculo, dataehoraentrada: new Date(dataehoradentrada)
          };
      }
    } catch (e) {
      console.log(e);
    }
  }

  async removeById(ordemDeServicoId: string): Promise<void> {
    return this.firestore.doc(`ordensdeservico/${ordemDeServicoId}`).delete();
  }
}
