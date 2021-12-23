import { Component, OnInit, ViewChild } from '@angular/core';
import { Capacitor } from '@capacitor/core';
import { IonList } from '@ionic/angular';
import { Cliente } from 'src/app/models/cliente.model';
import { ClientesService } from 'src/app/services/clientes.service';
import { AlertService } from '../services/alert.service';

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
    private alertService: AlertService
  ) { }

  caminhoFotoParaListagem(foto: string) {
    if (foto != '') {
      return Capacitor.convertFileSrc(foto);
    } else {
      return 'assets/imgs/icon_clientes.png';
    }
  }

  ngOnInit() {
  }

  async ionViewWillEnter() {
    try {
      this.clientes = await this.clientesService.getAll();
    } catch (error) {
      this.alertService.presentAlert('Erro de conexão', 'Usuário não está autenticado', 'Tente conectar novamente', ['OK']);
    }
  }
}