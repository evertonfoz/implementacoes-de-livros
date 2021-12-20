import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Cliente } from 'src/app/models/cliente.model';
import { LoadingController, MenuController, Platform } from '@ionic/angular';
import { AlertService } from 'src/app/services/alert.service';
import { ClientesService } from 'src/app/services/clientes.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastService } from 'src/app/services/toast.service';
import { DatePicker } from '@ionic-native/date-picker/ngx';

@Component({
  templateUrl: './clientes-add-edit.page.html'
})
export class ClientesAddEditPage implements OnInit {
  private cliente: Cliente;
  public modoDeEdicao = false;
  public clienteForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private alertService: AlertService,
    private loadingCtrl: LoadingController,
    private clientesService: ClientesService,
    private router: Router,
    private toastService: ToastService,
    private platform: Platform,
    private datePicker: DatePicker,
    private route: ActivatedRoute
  ) { }

  async ngOnInit() {
  }

  async ionViewWillEnter() {
    const id = this.route.snapshot.paramMap.get('id');

    if (id !== '-1') {
      this.cliente = await this.clientesService.getById(id);
    } else {
      this.cliente = { clienteid: '', nome: '', email: '', telefone: '', renda: 0.00, nascimento: new Date() };
      this.modoDeEdicao = true;
    }

    this.clienteForm = this.formBuilder.group({
      clienteid: [this.cliente.clienteid],
      nome: [this.cliente.nome, Validators.required],
      email: [this.cliente.email, Validators.required],
      telefone: [this.cliente.telefone, Validators.required],
      renda: [this.cliente.renda, Validators.required],
      nascimento: [this.cliente.nascimento, Validators.required],
      nascimentoForm: [{ value: this.cliente.nascimento.toLocaleDateString(), disabled: !this.modoDeEdicao }, Validators.required],
    });
  }

  async submit() {
    if (this.clienteForm.invalid || this.clienteForm.pending) {
      await this.alertService.presentAlert('Falha', 'Gravação não foi executada',
        'Verifique os dados informados para o atendimento', ['Ok']);
      return;
    }

    // Estamos utilizando pela primeira vez este controle
    const loading = await this.loadingCtrl.create();
    await loading.present();

    if (this.cliente.clienteid === '') {
      await this.clientesService.create(this.clienteForm.value);
    } else {
      await this.clientesService.update(this.clienteForm.value);
    }

    loading.dismiss().then(() => {
      this.toastService.presentToast('Gravação bem sucedida', 3000, 'top');
      this.router.navigateByUrl('/clientes-listagem');
    });
  }

  selecionarData() {
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
              this.clienteForm.controls.nascimentoForm.setValue(data.toLocaleDateString());
              this.clienteForm.controls.nascimento.setValue(data);
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
    this.clienteForm.setValue(this.cliente);
    this.modoDeEdicao = false;
  }
}
