import { Component, OnInit } from '@angular/core';
import { Cliente } from 'src/app/models/cliente.model';
import { ClientesService } from 'src/app/services/clientes.service';
import { Observable } from 'rxjs';
import { AlertService } from 'src/app/services/alert.servce';

@Component({
    templateUrl: './clientes-listagem.page.html'
})
export class ClientesListagemPage implements OnInit {

    public clientes: Observable<Cliente[]>;

    constructor(
        private clientesService: ClientesService,
        private alertService: AlertService
        ) { }

    ngOnInit() {
    }

    ionViewWillEnter() {
        try {
            this.clientes = this.clientesService.getAll().valueChanges();
        } catch (error) {
            this.alertService.presentAlert('Erro de conexão', 'Usuário não está autenticado', 'Tente conectar novamente', [ 'OK'] );
        }
    }
}
