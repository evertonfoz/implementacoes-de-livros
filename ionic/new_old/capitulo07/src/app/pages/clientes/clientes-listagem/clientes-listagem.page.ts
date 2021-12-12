import { Component, OnInit, ViewChild } from '@angular/core';
import { collection, DocumentChange, Firestore, onSnapshot, Query, query, QuerySnapshot } from '@angular/fire/firestore';
import { IonList } from '@ionic/angular';
import { Observable } from 'rxjs';
import { Cliente } from 'src/app/models/cliente.model';
import { AlertService } from 'src/app/services/alert.service';
import { ClientesService } from 'src/app/services/clientes.service';
import { ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-clientes-listagem',
  templateUrl: './clientes-listagem.page.html',
  styleUrls: ['./clientes-listagem.page.scss'],
})
export class ClientesListagemPage implements OnInit {

  public clientes: Cliente[];
  @ViewChild('slidingList') slidingList: IonList;

  constructor(
    private clientesService: ClientesService,
    private alertService: AlertService,
    private toastService: ToastService,
  ) { }

  ngOnInit() {
  }

  async ionViewWillEnter() {
    this.clientes = await this.clientesService.getAll();
  }

  async removerCliente(cliente: Cliente) {
    try {
      const successFunction = async () => {
        await this.clientesService.removeById(cliente.clienteid);
        this.toastService.presentToast('Cliente removido com sucesso', 3000, 'top');
        this.slidingList.closeSlidingItems();
        this.clientes = await this.clientesService.getAll();
      };
      await this.alertService.presentConfirm('Remover Cliente', 'Confirma remoção?', successFunction);
    } catch (e) {
      await this.alertService.presentAlert('Falha', 'Remoção não foi executada', e, ['Ok']);
    }
  }
}
