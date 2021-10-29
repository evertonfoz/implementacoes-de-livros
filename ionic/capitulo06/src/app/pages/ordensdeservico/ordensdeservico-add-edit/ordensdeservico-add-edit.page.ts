import { Component, OnInit } from '@angular/core';
import { OrdemDeServico } from 'src/app/models/ordemdeservico.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Guid } from 'guid-typescript';
import { Cliente } from 'src/app/models/cliente.model';
import { ClientesService } from 'src/app/services/clientes.service';

@Component({
  templateUrl: './ordensdeservico-add-edit.page.html'
})
export class OrdensDeServicoAddEditPage implements OnInit {
  private ordemDeServico: OrdemDeServico;
  public modoDeEdicao = false;
  public osForm: FormGroup;
  public clientes: void | Cliente[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private clientesService: ClientesService
  ) { }

  async ngOnInit() {
  }

  async ionViewWillEnter() {
    const clientes = await this.clientesService.getAll();
    this.clientes = clientes;

    this.ordemDeServico = { ordemdeservicoid: Guid.createEmpty().toString(), clienteid: Guid.createEmpty().toString(), veiculo: '', dataehoraentrada: new Date() };
    this.modoDeEdicao = true;

    this.osForm = this.formBuilder.group({
      ordemdeservicoid: [this.ordemDeServico.ordemdeservicoid],
      clienteid: [this.ordemDeServico.clienteid, Validators.required],
      veiculo: [this.ordemDeServico.veiculo, Validators.required],
      dataentrada: [this.ordemDeServico.dataehoraentrada.toISOString(), Validators.required],
      horaentrada: [this.ordemDeServico.dataehoraentrada.toISOString(), Validators.required],
      dataehoraentrada: ['']
    });
  }
}
