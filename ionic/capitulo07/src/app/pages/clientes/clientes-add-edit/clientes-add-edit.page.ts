import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Cliente } from 'src/app/models/cliente.model';
import { LoadingController, MenuController } from '@ionic/angular';
import { AlertService } from 'src/app/services/alert.service';
import { ClientesService } from 'src/app/services/clientes.service';
import { ToastService } from 'src/app/services/toast.service';
import { Router } from '@angular/router';

@Component({
  templateUrl: './clientes-add-edit.page.html'
})
export class ClientesAddEditPage implements OnInit {
  private cliente: Cliente;
  public modoDeEdicao = false;
  public clientesForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private loadingCtrl: LoadingController,
    private alertService: AlertService,
    private clientesService: ClientesService,
    private toastService: ToastService,
    private router: Router,
  ) { }

  async ngOnInit() {
  }

  async ionViewWillEnter() {
    this.modoDeEdicao = true;

    this.cliente = { clienteid: '', nome: '', email: '', telefone: '', renda: 0.00, nascimento: new Date() };

    this.clientesForm = this.formBuilder.group({
      clienteid: [this.cliente.clienteid],
      nome: [this.cliente.nome, Validators.required],
      email: [this.cliente.email, Validators.required],
      telefone: [this.cliente.telefone, Validators.required],
      renda: [this.cliente.renda, Validators.required],
      nascimento: [this.cliente.nascimento.toISOString(), Validators.required]
    });
  }

  async submit() {
    if (this.clientesForm.invalid || this.clientesForm.pending) {
      await this.alertService.presentAlert('Falha', 'Gravação não foi executada',
        'Verifique os dados informados para o atendimento', ['Ok']);
      return;
    }

    // Estamos utilizando pela primeira vez este controle
    const loading = await this.loadingCtrl.create();
    await loading.present();

    if (this.cliente.clienteid === '') {
      await this.clientesService.create(this.clientesForm.value)
        .then(
          () => {
            loading.dismiss().then(() => {
              this.toastService.presentToast('Gravação bem sucedida', 3000, 'top');
              this.router.navigateByUrl('/clientes)');
            });
          },
          error => {
            console.error(error);
          }
        );
    }
  }
}