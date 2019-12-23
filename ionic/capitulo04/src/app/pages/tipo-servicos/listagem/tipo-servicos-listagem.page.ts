import { Component, OnInit, ViewChild } from '@angular/core';
import { TipoServicosService } from 'src/app/services/tipo-servicos.service';
import { IonList } from '@ionic/angular';
import { TipoServico } from 'src/app/models/tipo-servico.model';
import { ToastService } from 'src/app/services/toast.service';

@Component({
    templateUrl: './tipo-servicos-listagem.page.html'
})
export class TipoServicosListagemPage implements OnInit {
  public tiposServicos;
  @ViewChild('slidingList') slidingList: IonList;

  constructor(
    private tipoServicoService: TipoServicosService,
    private toastService: ToastService
  ) {}

  ngOnInit() {
    this.tiposServicos = this.tipoServicoService.getAll();
  }

  async removerTipoServico(tipoServico: TipoServico) {
    this.tipoServicoService.remove(tipoServico);
    this.toastService.presentToast('Tipo de serviço removido', 3000, 'top');
    await this.slidingList.closeSlidingItems();
  }
}
