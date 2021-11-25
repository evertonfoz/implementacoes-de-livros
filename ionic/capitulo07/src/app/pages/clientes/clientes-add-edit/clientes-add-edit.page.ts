import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Cliente } from 'src/app/models/cliente.model';
import { LoadingController, MenuController } from '@ionic/angular';
import { AlertService } from 'src/app/services/alert.service';
import { ClientesService } from 'src/app/services/clientes.service';
import { ToastService } from 'src/app/services/toast.service';
import { ActivatedRoute, Router } from '@angular/router';
import { getApp } from 'firebase/app';
import { getFirestore } from '@firebase/firestore';
import { collection, onSnapshot, query } from 'firebase/firestore';
import { Firestore } from '@angular/fire/firestore';
import { getDatabase, onValue, ref } from 'firebase/database';

@Component({
  templateUrl: './clientes-add-edit.page.html'
})
export class ClientesAddEditPage implements OnInit {
  private cliente: Cliente;
  public modoDeEdicao = false;
  public clientesForm: FormGroup;

  public search: string;



  constructor(
    private formBuilder: FormBuilder,
    private loadingCtrl: LoadingController,
    private alertService: AlertService,
    private clientesService: ClientesService,
    private toastService: ToastService,
    private router: Router, private route: ActivatedRoute,
  ) {
  }

  formatTimestamp(ts) {
    let [D, M, Y, h, m, s, ap] = ts.toLowerCase().split(/\W/);
    h = String(h % 12 + (ap == 'am' ? 0 : 12)).padStart(2, '0');
    return `${Y}-${M}-${D}T${h}:${m}:${s}Z`;
  }

  async ionViewWillEnter() {
    const id = this.route.snapshot.paramMap.get('id');

    if (id !== '-1') {
      this.cliente = await this.clientesService.getById(id);
    } else {
      this.cliente = { clienteid: '', nome: '', email: '', telefone: '', renda: 0.00, nascimento: new Date() };
      this.modoDeEdicao = true;
    }

    this.clientesForm = this.formBuilder.group({
      clienteid: [this.cliente.clienteid],
      nome: [this.cliente.nome, Validators.required],
      email: [this.cliente.email, Validators.required],
      telefone: [this.cliente.telefone, Validators.required],
      renda: [this.cliente.renda, Validators.required],
      nascimento: [this.cliente.nascimento.toISOString(), Validators.required]
    });
  }

  ngOnInit() {

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
      await this.clientesService.create(this.clientesForm.value);
    } else {
      await this.clientesService.update(this.clientesForm.value);
    }

    loading.dismiss().then(() => {
      this.toastService.presentToast('Gravação bem sucedida', 3000, 'top');
      this.router.navigateByUrl('/clientes-listagem');
    });
  }



  iniciarEdicao() {
    this.modoDeEdicao = true;
  }

  cancelarEdicao() {
    this.clientesForm.setValue(this.cliente);
    this.modoDeEdicao = false;
  }
}