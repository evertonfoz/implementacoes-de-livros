import { ActivatedRoute, Router } from '@angular/router';
import { TipoServicosService } from '../../../services/tipo-servicos.service';
import { OnInit, Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TipoServico } from 'src/app/models/tipo-servico.model';
import { ToastService } from 'src/app/services/toast.service';

@Component({
    templateUrl: './tipo-servicos-add-edit.page.html'
})
export class TipoServicosAddEditPage implements OnInit {
    private tipoServico: TipoServico;

    public modoDeEdicao = false;
    public tiposServicosForm: FormGroup;

    constructor(
        private route: ActivatedRoute,
        private tipoServicoService: TipoServicosService,
        private formBuilder: FormBuilder,
        private toastService: ToastService,
        private router: Router
    ) { }

    ngOnInit() {
        const id: number = Number(this.route.snapshot.paramMap.get('id'));

        if (id > 0) {
            this.tipoServico = this.tipoServicoService.getById(id);
        } else {
            this.tipoServico = { id, nome: '', valor: 0.00 };
            this.modoDeEdicao = true;
        }

        this.tiposServicosForm = this.formBuilder.group({
            id: [this.tipoServico.id],
            nome: [this.tipoServico.nome, Validators.required],
            valor: [this.tipoServico.valor, Validators.required]
        });
    }

    iniciarEdicao() {
        this.modoDeEdicao = true;
    }

    submit() {
        this.tipoServicoService.update(this.tiposServicosForm.value);
        this.toastService.presentToast('Gravação bem sucedida', 3000, 'top');
        this.modoDeEdicao = false;
        this.router.navigateByUrl('');
    }
}