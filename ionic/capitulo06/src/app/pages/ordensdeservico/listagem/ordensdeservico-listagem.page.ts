import { Component, OnInit, ViewChild } from '@angular/core';
import { OrdensDeServicoService } from 'src/app/services/ordensdeservico.service';
import { ToastService } from 'src/app/services/toast.service';
import { OrdemDeServico } from 'src/app/models/ordemdeservico.model';
import { IonList, MenuController } from '@ionic/angular';
import { AlertService } from 'src/app/services/alert.service';

@Component({
    templateUrl: './ordensdeservico-listagem.page.html'
})
export class OrdensDeServicoListagemPage implements OnInit {

    public ordensDeServico: void | OrdemDeServico[] = [];
    @ViewChild('slidingList') slidingList: IonList;

    constructor(
        private ordensdeservicoService: OrdensDeServicoService,
        private toastService: ToastService,
        private alertService: AlertService,
        private menu: MenuController
        ) { }

    ngOnInit() {

    }

    async ionViewWillEnter() {
        const oss = await this.ordensdeservicoService.getAll();
        this.ordensDeServico = oss;
        this.menu.open();
    }

    async removerAtendimento(ordemdeservico: OrdemDeServico) {
        await this.ordensdeservicoService.removeById(ordemdeservico.ordemdeservicoid)
            .then( async () => {
                this.ordensDeServico = await this.ordensdeservicoService.getAll();
                this.toastService.presentToast('Ordem de Serviço removida', 3000, 'top');
                await this.slidingList.closeSlidingItems();
            })
            .catch( async (e) =>  await this.alertService.presentAlert('Falha', 'Remoção não foi executada', e, ['Ok']));
    }
}
