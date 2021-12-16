import { Component, OnInit } from '@angular/core';
import { OrdemDeServico } from 'src/app/models/ordemdeservico.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Guid } from 'guid-typescript';
import { Cliente } from 'src/app/models/cliente.model';
import { ClientesService } from 'src/app/services/clientes.service';
import { DatePicker } from '@ionic-native/date-picker/ngx';
import { Platform } from '@ionic/angular';
import { ActivatedRoute } from '@angular/router';
import { OrdensDeServicoService } from 'src/app/services/ordensdeservico.service';


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
    private clientesService: ClientesService,
    private datePicker: DatePicker,
    private platform: Platform,
    private route: ActivatedRoute,
    private ordensDeServicoService: OrdensDeServicoService,
  ) { }

  async ngOnInit() {
  }

  async ionViewWillEnter() {
    const id = this.route.snapshot.paramMap.get('id');

    const clientes = await this.clientesService.getAll();
    this.clientes = clientes;

    const isIdEmptyGUID = Guid.parse(id).isEmpty();
    const isIdValidGUID = Guid.isGuid(id);

    if (id && !isIdEmptyGUID && isIdValidGUID) {
      this.ordemDeServico = await this.ordensDeServicoService.getById(id);
    } else {
      this.ordemDeServico = {
        ordemdeservicoid: Guid.createEmpty().toString(),
        clienteid: Guid.createEmpty().toString(), veiculo: '', dataehoraentrada: new Date()
      };
      this.modoDeEdicao = true;
    }

    this.osForm = this.formBuilder.group({
      ordemdeservicoid: [this.ordemDeServico.ordemdeservicoid],
      clienteid: [this.ordemDeServico.clienteid, Validators.required],
      veiculo: [this.ordemDeServico.veiculo, Validators.required],
      dataentrada: [this.ordemDeServico.dataehoraentrada.toLocaleDateString(), Validators.required],
      horaentrada: [this.ordemDeServico.dataehoraentrada.toLocaleDateString(), Validators.required],
      dataehoraentrada: ['']
    });

    this.ordemDeServico = this.osForm.value;

    // const children = document.getElementById('divDataEntrada').children;
    // for (var i = 0; i < children.length; i++) {
    //   children[i].getAttribute() = true;
    // }
  }

  confirmarDataEntrada() {
    return new Date(this.osForm.get('dataentrada').value).toLocaleDateString();
  }

  selecionarDataEntrada() {
    this.platform.ready().then(() => {
      if (this.platform.is('capacitor')) {
        this.datePicker.show({
          date: new Date(),
          mode: 'date',
          locale: 'pt-br',
          doneButtonLabel: 'Confirmar',
          cancelButtonLabel: 'Cancelar'
        })
          .then(
            data => this.osForm.controls.dataentrada.setValue(data.toLocaleDateString())
          );
      } else {
        // instruções para execução no navegador
      }
    });
  }

  confirmarHoraEntrada() {
    return new Date(this.osForm.get('horaentrada').value).toLocaleTimeString();
  }

  selecionarHoraEntrada() {
    if (!this.modoDeEdicao) {
      return;
    }

    this.platform.ready().then(() => {
      if (this.platform.is('capacitor')) {
        this.datePicker.show({
          date: new Date(),
          mode: 'time',
          locale: 'pt-br',
          doneButtonLabel: 'Confirmar',
          cancelButtonLabel: 'Cancelar'
        })
          .then(
            data => this.osForm.controls.horaentrada.setValue(data.toLocaleTimeString())
          );
      } else {
        // instruções para execução no navegador
      }
    });
  }
}