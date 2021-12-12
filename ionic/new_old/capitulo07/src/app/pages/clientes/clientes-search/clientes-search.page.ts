import { Component, OnInit, ViewChild } from '@angular/core';
import { Cliente } from 'src/app/models/cliente.model';
import { ClientesService } from 'src/app/services/clientes.service';
import { Location } from '@angular/common';
import { SearchService } from 'src/app/services/search.service';

@Component({
  templateUrl: './clientes-search.page.html',
  styleUrls: ['./clientes-search.page.scss']
})
export class ClientesSearchPage implements OnInit {
  public clientes: Cliente[];

  constructor(
    private clientesService: ClientesService,
    public location: Location,
    private searchService: SearchService,
  ) { }

  ngOnInit() {
  }

  async ionViewWillEnter() {
    this.clientes = await this.clientesService.getAll();
  }

  async getClientes(searchBar) {
    this.clientes = await this.clientesService.getByNome(searchBar.srcElement.value);
  }

  clientesClick(cliente: Cliente) {
    this.searchService.publishSomeData(cliente);
    this.location.back();
  }

}
