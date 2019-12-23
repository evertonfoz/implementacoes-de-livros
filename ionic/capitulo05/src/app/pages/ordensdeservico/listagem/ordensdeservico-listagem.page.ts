import { Component, OnInit, ViewChild } from '@angular/core';
import { OrdensDeServicoService } from 'src/app/services/ordensdeservico.service';
import { ToastService } from 'src/app/services/toast.service';
import { OrdemDeServico } from 'src/app/models/ordemdeservico.model';
import { IonList } from '@ionic/angular';

@Component({
    templateUrl: './ordensdeservico-listagem.page.html'
})
export class OrdensDeServicoListagemPage implements OnInit {

    public ordensDeServico: void | OrdemDeServico[] = [];
    @ViewChild('slidingList') slidingList: IonList;

    constructor(
        private ordensdeservicoService: OrdensDeServicoService,
        private toastService: ToastService
        ) { }

    ngOnInit() {

    }

    async ionViewWillEnter() {
        const oss = await this.ordensdeservicoService.getAll();
        this.ordensDeServico = oss;
    }
}
