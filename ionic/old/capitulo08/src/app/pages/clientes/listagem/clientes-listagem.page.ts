import { Component, OnInit, ViewChild } from '@angular/core';
import { Cliente } from 'src/app/models/cliente.model';
import { ClientesService } from 'src/app/services/clientes.service';
import { Observable } from 'rxjs';
import { IonList } from '@ionic/angular';
import { ToastService } from 'src/app/services/toast.service';
import { AlertService } from 'src/app/services/alert.service';
import { File } from '@ionic-native/File/ngx';

@Component({
    templateUrl: './clientes-listagem.page.html'
})
export class ClientesListagemPage implements OnInit {

    public clientes: Observable<Cliente[]>;
    @ViewChild('slidingList') slidingList: IonList;

    constructor(
        private clientesService: ClientesService,
        private toastService: ToastService,
        private alertService: AlertService,
        private file: File
        ) { }

    ngOnInit() {
    }

    ionViewWillEnter() {
        this.clientes = this.clientesService.getAll().valueChanges();
    }

    async removerCliente(cliente: Cliente) {
        try {
            const successFunction = async () => {
                this.clientesService.removeById(cliente.clienteid, cliente.nomeFotoEnviada);
            };
            await this.alertService.presentConfirm('Remover Cliente', 'Confirma remoção?', successFunction);
        } catch (e) {
            await this.alertService.presentAlert('Falha', 'Remoção não foi executada', e, ['Ok']);
        }
    }
}
