import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Cliente } from 'src/app/models/cliente.model';
import { MenuController, LoadingController } from '@ionic/angular';
import { AlertService } from 'src/app/services/alert.service';
import { FirestoreService } from 'src/app/services/firestore.service';
import { ClientesService } from 'src/app/services/clientes.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastService } from 'src/app/services/toast.service';

@Component({
    templateUrl: './clientes-add-edit.page.html'
})
export class ClientesAddEditPage implements OnInit {
    private cliente: Cliente;
    public modoDeEdicao = false;
    public clientesForm: FormGroup;

    constructor(
        private formBuilder: FormBuilder,
        private alertService: AlertService,
        private loadingCtrl: LoadingController,
        private firestoreService: FirestoreService,
        private clientesService: ClientesService,
        private toastService: ToastService,
        private router: Router,
        private route: ActivatedRoute,
    ) {}

    async ngOnInit() {
    }

    async ionViewWillEnter() {
        const id = this.route.snapshot.paramMap.get('id');

        if (id !== '-1') {
            this.cliente = await this.clientesService.getById(id);
        } else {
            this.cliente = {clienteid: '', nome: '', email: '', telefone: '', renda: 0.00, nascimento: new Date()};
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
            this.clientesForm.controls.clienteid.setValue(this.firestoreService.createID());
        }

        // Invocamos o serviço, enviando um objeto com os dados recebidos da visão
        await this.clientesService.update(this.clientesForm.value)
            .then(
                () => {
                    loading.dismiss().then(() => {
                        this.toastService.presentToast('Gravação bem sucedida', 3000, 'top');
                        this.router.navigateByUrl('/menu/(menucontent:clientes)');
                    });
                },
                    error => {
                    console.error(error);
                }
            );
    }

    iniciarEdicao() {
        this.modoDeEdicao = true;
    }

    cancelarEdicao() {
        this.clientesForm.setValue(this.cliente);
        this.modoDeEdicao = false;
    }
}
