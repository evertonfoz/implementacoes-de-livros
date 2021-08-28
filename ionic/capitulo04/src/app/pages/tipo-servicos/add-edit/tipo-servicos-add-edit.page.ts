import { ActivatedRoute } from '@angular/router';
import { TipoServicosService } from '../../../services/tipo-servicos.service';
import { OnInit, Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
    templateUrl: './tipo-servicos-add-edit.page.html'
})
export class TipoServicosAddEditPage implements OnInit {
    public tipoServico;
    public modoDeEdicao = false;
    public tiposServicosForm: FormGroup;

    constructor(
        private route: ActivatedRoute,
        private tipoServicoService: TipoServicosService,
        private formBuilder: FormBuilder
    ) { }

    ngOnInit(): void {
        const id: number = Number(this.route.snapshot.paramMap.get('id'));
        this.tipoServico = this.tipoServicoService.getById(id);

        this.tiposServicosForm = this.formBuilder.group({
            id,
            nome: [this.tipoServico.nome, Validators.required],
            valor: [this.tipoServico.valor, Validators.required]
        });
    }

    iniciarEdicao() {
        this.modoDeEdicao = true;
    }
}