import { Component, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from 'src/app/models/cliente.model';
import { ClientesService } from 'src/app/services/clientes.service';
import { Location } from '@angular/common';
import { Events } from '@ionic/angular';

@Component({
    templateUrl: './clientes-search.page.html',
    styleUrls: ['./clientes-search.page.scss']
})
export class ClientesSearchPage implements OnInit {
    public clientes: Observable<Cliente[]>;

    constructor(
        private clientesService: ClientesService,
        private location: Location,
        private events: Events
     ) {
     }

    ngOnInit() {
    }

    ionViewWillEnter() {
        this.clientes = this.clientesService.getAll().valueChanges();
    }

    getClientes(searchBar) {
        this.clientes = this.clientesService.getByNome(searchBar.srcElement.value);
    }

    clientesClick(cliente: Cliente) {
        this.events.publish('clienteSelecionado', cliente);
        this.location.back();
    }
}
