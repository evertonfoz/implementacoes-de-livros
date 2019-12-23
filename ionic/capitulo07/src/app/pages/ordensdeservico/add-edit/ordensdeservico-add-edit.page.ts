import { Component, OnInit } from '@angular/core';
import { OrdemDeServico } from 'src/app/models/ordemdeservico.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Cliente } from 'src/app/models/cliente.model';
import { ClientesService } from 'src/app/services/clientes.service';
import { ActivatedRoute, Router } from '@angular/router';
import { OrdensDeServicoService } from 'src/app/services/ordensdeservico.service';
import { ToastService } from 'src/app/services/toast.service';
import { AlertService } from 'src/app/services/alert.service';
import { Events, LoadingController } from '@ionic/angular';
import { FirestoreService } from 'src/app/services/firestore.service';

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
        private clientesService: ClientesService,
        private route: ActivatedRoute,
        private ordensDeServicoService: OrdensDeServicoService,
        private toastService: ToastService,
        private alertService: AlertService,
        private router: Router,
        private events: Events,
        private firestoreService: FirestoreService,
        private loadingCtrl: LoadingController
    ) {
        this.registrarServicoClienteSelecionado();
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
            this.ordemDeServico = {ordemdeservicoid: '', clienteid: '', veiculo: '', dataehoraentrada: new Date() };
            this.modoDeEdicao = true;
        }

        this.createUpdateFormGroup();
    }

    async ionViewWillEnter() {
        // await this.getClienteSelecionado();
        // his.events.publish('clienteSelecionado', 'cliente');
        /* const id = this.route.snapshot.paramMap.get('id');

        const clientes = await this.clientesService.getAll();
        this.clientes = clientes;

        const isIdEmptyGUID = Guid.parse(id).isEmpty();
        const isIdValidGUID = Guid.isGuid(id);

        if (id && !isIdEmptyGUID && isIdValidGUID) {
            this.ordemDeServico = await this.ordensDeServicoService.getById(id);
        } else {
            this.ordemDeServico = {ordemdeservicoid: Guid.createEmpty().toString(),
                clienteid: Guid.createEmpty().toString(), veiculo: '', dataehoraentrada: new Date() };
            this.modoDeEdicao = true;
        }

        this.osForm = this.formBuilder.group({
            ordemdeservicoid: [this.ordemDeServico.ordemdeservicoid],
            clienteid: [this.ordemDeServico.clienteid, Validators.required],
            veiculo: [this.ordemDeServico.veiculo, Validators.required],
            dataentrada: [this.ordemDeServico.dataehoraentrada.toISOString(), Validators.required],
            horaentrada: [this.ordemDeServico.dataehoraentrada.toISOString(), Validators.required],
            dataehoraentrada: ['']
        });

        this.ordemDeServico = this.osForm.value; */
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

    if (this.ordemDeServico.ordemdeservicoid === '') {
        this.osForm.controls.ordemdeservicoid.setValue(this.firestoreService.createID());
    }

    this.osForm.controls.dataehoraentrada.setValue(
        this.osForm.controls.dataentrada.value.
            replace(/(\d{4})\-(\d{2})\-(\d{2}).*/, '$1-$2-$3') +
        'T' + this.osForm.controls.horaentrada.value
    );

    await this.ordensDeServicoService.update(this.osForm.value)
        .then(
            () => {
                loading.dismiss().then(() => {
                    this.toastService.presentToast('Gravação bem sucedida', 3000, 'top');
                    this.router.navigateByUrl('/menu/(menucontent:atendimentos)');
                });
            },
                error => {
                console.error(error);
            }
        );
    }

    public goToClientesSearch() {
        this.router.navigateByUrl('/menu/(menucontent:pesquisarclientes)');
    }

    private registrarServicoClienteSelecionado() {
        this.events.subscribe('clienteSelecionado', (data) => {
            this.nomeCliente = data.nome;
            this.osForm.controls.clienteid.setValue(data.clienteid);
        });
    }

    public unsubscribeServices() {
        this.events.unsubscribe('clienteSelecionado');
    }
}
