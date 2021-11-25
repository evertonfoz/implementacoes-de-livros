import { Component, OnInit } from '@angular/core';
import { OrdemDeServico } from 'src/app/models/ordemdeservico.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Guid } from 'guid-typescript';
import { Cliente } from 'src/app/models/cliente.model';
import { ClientesService } from 'src/app/services/clientes.service';
import { ActivatedRoute, Router } from '@angular/router';
import { OrdensDeServicoService } from 'src/app/services/ordensdeservico.service';
import { ToastService } from 'src/app/services/toast.service';
import { AlertService } from 'src/app/services/alert.service';

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
    private route: ActivatedRoute,
    private ordensDeServicoService: OrdensDeServicoService,
    private toastService: ToastService,
    private alertService: AlertService,
    private router: Router,
  ) { }

  async ngOnInit() {
  }

  async ionViewWillEnter() {
    // const id = this.route.snapshot.paramMap.get('id');

    // const clientes: Cliente[] = await this.clientesService.getAll();
    // console.log('CLIENTE: ' + clientes[0].clienteid);

    // this.clientes = clientes;

    // const isIdEmptyGUID = Guid.parse(id).isEmpty();
    // const isIdValidGUID = Guid.isGuid(id);

    // if (id && !isIdEmptyGUID && isIdValidGUID) {
    //   this.ordemDeServico = await this.ordensDeServicoService.getById(id);
    // } else {
    //   this.ordemDeServico = {
    //     ordemdeservicoid: Guid.createEmpty().toString(),
    //     clienteid: Guid.createEmpty().toString(), veiculo: '', dataehoraentrada: new Date()
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
    this.osForm.setValue(this.ordemDeServico);
    this.modoDeEdicao = false;
  }

  // Método a ser invocado quando o botão de gravar for selecionado
  async submit() {
    // Validação dos dados informados no formulário. Já trabalhamos com isso.
    if (this.osForm.invalid || this.osForm.pending) {
      await this.alertService.presentAlert('Falha', 'Gravação não foi executada',
        'Verifique os dados informados para o atendimento', ['Ok']);
      return;
    }

    // Aqui extraímos a data e hora da informadas no formulário e convertemos para um Date    
    const dataString = new Date(this.osForm.controls.dataentrada.value).toDateString();
    const horaString = new Date(this.osForm.controls.horaentrada.value).toTimeString();
    const dataEHora = new Date(dataString + ' ' + horaString);

    // Invocamos o serviço, enviando um objeto com os dados recebidos da visão    
    // this.ordemDeServico = await this.ordensDeServicoService.update(
    //   {
    //     ordemdeservicoid: this.osForm.controls.ordemdeservicoid.value,
    //     clienteid: this.osForm.controls.clienteid.value,
    //     veiculo: this.osForm.controls.veiculo.value,
    //     dataehoraentrada: dataEHora,
    //   }
    // );

    // Informamos o usuário do sucesso da operação e o redirecionamos para a listagem    
    this.toastService.presentToast('Gravação bem sucedida', 3000, 'top');
    this.router.navigateByUrl('ordensdeservico-listagem');
  }
}
