import { Component, OnInit, ViewChild } from '@angular/core';
import { IonList, MenuController } from '@ionic/angular';
import { OrdemDeServico } from 'src/app/models/ordemdeservico.model';
import { AlertService } from 'src/app/services/alert.service';
import { DatabaseService } from 'src/app/services/database.service';
import { databaseName } from 'src/app/services/database.statements';
import { OrdensDeServicoService } from 'src/app/services/ordensdeservico.service';
import { ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-ordensdeservico-listagem',
  templateUrl: './ordensdeservico-listagem.page.html',
  styleUrls: ['./ordensdeservico-listagem.page.scss'],
})
export class OrdensdeservicoListagemPage implements OnInit {

  public ordensDeServico: OrdemDeServico[] = [];
  @ViewChild('slidingList') slidingList: IonList;

  constructor(
    private ordensdeservicoService: OrdensDeServicoService,
    private databaseService: DatabaseService,
    private toastService: ToastService,
    private alertService: AlertService,
  ) {
  }

  async ngOnInit() {
  }

  async ionViewWillEnter() {
    this.ordensDeServico = await this.ordensdeservicoService.getAll();
  }

  // async removerAtendimento(ordemdeservico: OrdemDeServico) {
  //   await this.ordensdeservicoService.removeById(ordemdeservico.ordemdeservicoid)
  //     .then(async () => {
  //       this.ordensDeServico = await this.ordensdeservicoService.getAll();
  //       this.toastService.presentToast('Ordem de Serviço removida', 3000, 'top');
  //       await this.slidingList.closeSlidingItems();
  //     })
  //     .catch(async (e) => await this.alertService.presentAlert('Falha', 'Remoção não foi executada', e, ['Ok']));
  // }
}
