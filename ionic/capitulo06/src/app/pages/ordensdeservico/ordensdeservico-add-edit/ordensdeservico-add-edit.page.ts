import { Component, OnInit } from '@angular/core';
import { OrdemDeServico } from 'src/app/models/ordemdeservico.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Guid } from 'guid-typescript';
import { Cliente } from 'src/app/models/cliente.model';
import { ClientesService } from 'src/app/services/clientes.service';
import { DatePicker } from '@ionic-native/date-picker/ngx';
import { Platform } from '@ionic/angular';
import { ActivatedRoute, Router } from '@angular/router';
import { OrdensDeServicoService } from 'src/app/services/ordensdeservico.service';
import { ToastService } from 'src/app/services/toast.service';
import { AlertService } from 'src/app/services/alert.service';
import { DatePipe } from '@angular/common';


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
    private toastService: ToastService,
    private alertService: AlertService,
    private router: Router,
    private datePipe: DatePipe,

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
        clienteid: Guid.createEmpty().toString(),
        veiculo: '',
        dataehoraentrada: new Date()
      };
      this.modoDeEdicao = true;
    }

    this.osForm = this.formBuilder.group({
      ordemdeservicoid: [this.ordemDeServico.ordemdeservicoid],
      clienteid: [this.ordemDeServico.clienteid, Validators.required],
      veiculo: [this.ordemDeServico.veiculo, Validators.required],
      dataentrada: [{ value: this.ordemDeServico.dataehoraentrada.toLocaleDateString(), disabled: !this.modoDeEdicao }, Validators.required],
      horaentrada: [{ value: this.ordemDeServico.dataehoraentrada.toLocaleTimeString(), disabled: !this.modoDeEdicao }, Validators.required],
      dataehoraentrada: [this.ordemDeServico.dataehoraentrada]
    });

    this.ordemDeServico = this.osForm.value;

  }

  // confirmarDataEntrada() {
  //   return new Date(this.osForm.get('dataentrada').value).toLocaleDateString();
  // }

  selecionarDataEntrada() {
    if (!this.modoDeEdicao) {
      return;
    }

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
            data => {
              this.osForm.controls.dataentrada.setValue(data.toLocaleDateString());
              this.osForm.controls.dataehoraentrada.setValue(data.toISOString());
              this.osForm.controls.horaentrada.setValue('');
            }
          );
      } else {
        // instruções para execução no navegador
      }
    });
  }

  selecionarHoraEntrada() {
    if (!this.modoDeEdicao) {
      return;
    }
    this.platform.ready().then(() => {
      if (this.platform.is('capacitor')) {
        this.datePicker.show({
          date: new Date(this.osForm.controls.dataehoraentrada.value),
          mode: 'time',
          locale: 'pt-br',
          doneButtonLabel: 'Confirmar',
          cancelButtonLabel: 'Cancelar'
        })
          .then(
            data => {
              const dataEHoraEntrada = new Date(this.osForm.controls.dataehoraentrada.value)

              dataEHoraEntrada.setHours(data.getHours());
              dataEHoraEntrada.setMinutes(data.getMinutes());

              this.osForm.controls.horaentrada.setValue(data.toLocaleTimeString());
              this.osForm.controls.dataehoraentrada.setValue(dataEHoraEntrada.toISOString());
            }
          );
      } else {
        // instruções para execução no navegador
      }
    });
  }

  iniciarEdicao() {
    this.modoDeEdicao = true;
  }

  cancelarEdicao() {
    this.osForm.setValue(this.ordemDeServico);
    this.modoDeEdicao = false;
  }

  async submit() {
    // Validação dos dados informados no formulário. Já trabalhamos com isso.
    if (this.osForm.invalid || this.osForm.pending) {
      await this.alertService.presentAlert('Falha', 'Gravação não foi executada',
        'Verifique os dados informados para o atendimento', ['Ok']);
      return;
    }

    // Invocamos o serviço, enviando um objeto com os dados recebidos da visão    
    await this.ordensDeServicoService.update(
      {
        ordemdeservicoid: this.osForm.controls.ordemdeservicoid.value,
        clienteid: this.osForm.controls.clienteid.value,
        veiculo: this.osForm.controls.veiculo.value,
        dataehoraentrada: this.osForm.controls.dataehoraentrada.value,
      }
    );

    // Informamos o usuário do sucesso da operação e o redirecionamos para a listagem    
    this.toastService.presentToast('Gravação bem sucedida', 3000, 'top');
    this.router.navigateByUrl('ordensdeservico-listagem');
  }
}