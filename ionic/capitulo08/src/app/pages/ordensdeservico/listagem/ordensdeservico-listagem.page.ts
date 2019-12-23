import { Component, OnInit, ViewChild } from '@angular/core';
import { OrdensDeServicoService } from 'src/app/services/ordensdeservico.service';
import { ToastService } from 'src/app/services/toast.service';
import { OrdemDeServico } from 'src/app/models/ordemdeservico.model';
import { IonList, Events } from '@ionic/angular';
import { AlertService } from 'src/app/services/alert.service';
import { Observable } from 'rxjs';

@Component({
    templateUrl: './ordensdeservico-listagem.page.html'
})
export class OrdensDeServicoListagemPage implements OnInit {

    public ordensDeServico: Observable<OrdemDeServico[]>;
    @ViewChild('slidingList') slidingList: IonList;

    constructor(
        private ordensdeservicoService: OrdensDeServicoService,
        private toastService: ToastService,
        private alertService: AlertService
        ) {}

    ngOnInit() {
    }

    async ionViewWillEnter() {
        this.ordensDeServico = this.ordensdeservicoService.getAll().valueChanges();
    }

    async removerAtendimento(ordemdeservico: OrdemDeServico) {
        await this.ordensdeservicoService.removeById(ordemdeservico.ordemdeservicoid)
            .then( async () => {
                this.ordensDeServico = await this.ordensdeservicoService.getAll().valueChanges();
                this.toastService.presentToast('Ordem de Serviço removida', 3000, 'top');
                await this.slidingList.closeSlidingItems();
            })
            .catch( async (e) =>  await this.alertService.presentAlert('Falha', 'Remoção não foi executada', e, ['Ok']));
    }
}
