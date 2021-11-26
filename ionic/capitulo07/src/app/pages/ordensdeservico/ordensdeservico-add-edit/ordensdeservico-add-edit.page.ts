import { Component, OnInit, } from '@angular/core';
import { OrdemDeServico } from 'src/app/models/ordemdeservico.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Cliente } from 'src/app/models/cliente.model';
import { ClientesService } from 'src/app/services/clientes.service';
import { ActivatedRoute, Router } from '@angular/router';
import { OrdensDeServicoService } from 'src/app/services/ordensdeservico.service';
import { ToastService } from 'src/app/services/toast.service';
import { AlertService } from 'src/app/services/alert.service';
import { SearchService } from 'src/app/services/search.service';
import { LoadingController } from '@ionic/angular';


@Component({
  templateUrl: './ordensdeservico-add-edit.page.html'
})
export class OrdensDeServicoAddEditPage implements OnInit {
  private ordemDeServico: OrdemDeServico;
  public modoDeEdicao = false;
  public osForm: FormGroup;
  public clientes: void | Cliente[] = [];
  public nomeCliente = 'Pesquise o cliente';

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private ordensDeServicoService: OrdensDeServicoService,
    private toastService: ToastService,
    private alertService: AlertService,
    private router: Router,
    private searchService: SearchService,
    private loadingCtrl: LoadingController,
    private clientesService: ClientesService,
  ) {
    console.log('construtor');
    this.registrarServicoClienteSelecionado();
  }

  private registrarServicoClienteSelecionado() {
    console.log('registrarServicoClienteSelecionado');
    this.searchService.getObservable().subscribe((data) => {
      console.log('subscribe');
      this.nomeCliente = data.nome;
      this.osForm.controls.clienteid.setValue(data.clienteid);
    });
  }

  public unsubscribeServices() {
    this.searchService.getObservable().unsubscribe();
  }

  private createUpdateFormGroup() {
    this.osForm = this.formBuilder.group({
      ordemdeservicoid: [this.ordemDeServico.ordemdeservicoid],
      clienteid: [this.ordemDeServico.clienteid, Validators.required],
      veiculo: [this.ordemDeServico.veiculo, Validators.required],
      dataentrada: [this.ordemDeServico.dataehoraentrada.toISOString(), Validators.required],
      horaentrada: [this.ordemDeServico.dataehoraentrada.toLocaleTimeString('pt-BR'), Validators.required],
      dataehoraentrada: ['']
    });
  }

  async ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');

    if (id !== '-1') {
      this.ordemDeServico = await this.ordensDeServicoService.getById(id);
      const cliente = await this.clientesService.getById(this.ordemDeServico.clienteid);
      this.nomeCliente = cliente.nome;
    } else {
      this.ordemDeServico = { ordemdeservicoid: '', clienteid: '', veiculo: '', dataehoraentrada: new Date() };
      this.modoDeEdicao = true;
    }

    this.createUpdateFormGroup();
  }

  async ionViewWillEnter() {
    console.log('ionViewWillEnter');
    // const id = this.route.snapshot.paramMap.get('id');

    // const clientes: Cliente[] = await this.clientesService.getAll();
    // console.log('CLIENTE: ' + clientes[0].clienteid);

    // this.clientes = clientes;

    // const isIdEmptyGUID = Guid.parse(id).isEmpty();
    // const isIdValidGUID = Guid.isGuid(id);

    // if (id && !isIdEmptyGUID && isIdValidGUID) {
    //   // this.ordemDeServico = await this.ordensDeServicoService.getById(id);
    // } else {
    //   this.ordemDeServico = {
    //     ordemdeservicoid: '',// Guid.createEmpty().toString(),
    //     clienteid: '',// Guid.createEmpty().toString(),
    //     veiculo: '',
    //     dataehoraentrada: new Date()
    //   };
    //   this.modoDeEdicao = true;
    // }

    // this.osForm = this.formBuilder.group({
    //   ordemdeservicoid: [this.ordemDeServico.ordemdeservicoid],
    //   clienteid: [this.ordemDeServico.clienteid, Validators.required],
    //   veiculo: [this.ordemDeServico.veiculo, Validators.required],
    //   dataentrada: [this.ordemDeServico.dataehoraentrada.toISOString(), Validators.required],
    //   horaentrada: [this.ordemDeServico.dataehoraentrada.toISOString(), Validators.required],
    //   dataehoraentrada: ['']
    // });

    // this.ordemDeServico = this.osForm.value;
  }

  // Método a ser invocado quando o botão de alterar dados for selecionado
  iniciarEdicao() {
    this.modoDeEdicao = true;
  }

  // Método a ser invocado quando o botão de cancelar alteração for selecionado
  cancelarEdicao() {
    this.createUpdateFormGroup();
    this.modoDeEdicao = false;
  }

  // Método a ser invocado quando o botão de gravar for selecionado
  async submit() {
    if (this.osForm.invalid || this.osForm.pending) {
      await this.alertService.presentAlert('Falha', 'Gravação não foi executada',
        'Verifique os dados informados para o atendimento', ['Ok']);
      return;
    }

    const loading = await this.loadingCtrl.create();
    await loading.present();

    // if (this.ordemDeServico.ordemdeservicoid === '') {
    //   this.osForm.controls.ordemdeservicoid.setValue(this.firestoreService.createID());
    // }

    const data = new Date(this.osForm.controls.dataentrada.value).toISOString();
    const hora = new Date(this.osForm.controls.horaentrada.value).toISOString();

    console.log('Data: ' + data.substring(0, 11));
    console.log('Hora: ' + hora.substring(11, 22));
    this.osForm.controls.dataehoraentrada.setValue(
      data.substring(0, 11) + hora.substring(11, 22)
    );
    // console.log('===> ' + this.osForm.controls.horaentrada.value);

    // this.osForm.controls.dataehoraentrada.setValue(
    //   new Date(this.osForm.controls.dataehoraentrada.value));

    await this.ordensDeServicoService.update(this.osForm.value);

    loading.dismiss().then(() => {
      this.toastService.presentToast('Gravação bem sucedida', 3000, 'top');
      this.router.navigateByUrl('ordensdeservico-listagem');
    });

  }


  public goToClientesSearch() {
    console.log('1');
    this.router.navigateByUrl('clientes-search');
  }
}
