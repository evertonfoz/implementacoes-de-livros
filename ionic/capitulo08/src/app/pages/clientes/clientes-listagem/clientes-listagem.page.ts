import { Component, OnInit, ViewChild } from '@angular/core';
import { Capacitor } from '@capacitor/core';
import { Directory, Filesystem } from '@capacitor/filesystem';
import { IonList } from '@ionic/angular';
import { Cliente } from 'src/app/models/cliente.model';
import { AlertService } from 'src/app/services/alert.service';
import { ClientesService } from 'src/app/services/clientes.service';
import { ToastService } from 'src/app/services/toast.service';
// import { AndroidPermissions } from "@ionic-native/android-permissions/ngx"

@Component({
  selector: 'app-clientes-listagem',
  templateUrl: './clientes-listagem.page.html',
  styleUrls: ['./clientes-listagem.page.scss'],
})
export class ClientesListagemPage implements OnInit {

  public clientes: Cliente[];
  @ViewChild('slidingList') slidingList: IonList;

  constructor(
    private clientesService: ClientesService,
    private alertService: AlertService,
    private toastService: ToastService,
  ) { }

  ngOnInit() {
  }

  async ionViewWillEnter() {
    this.clientes = await this.clientesService.getAll();
  }

  caminhoFotoParaListagem(foto: string) {
    if (foto != '') {
      return Capacitor.convertFileSrc(foto);
    } else {
      return 'assets/imgs/icon_clientes.png';
    }
  }

  async removerCliente(cliente: Cliente) {
    try {
      const successFunction = async () => {
        this.clientesService.removeById(cliente.clienteid);

        const caminho: string = cliente.foto.substr(0, cliente.foto.lastIndexOf('/') + 1);
        const nomeArquivo: string = cliente.foto.substr(cliente.foto.lastIndexOf('/') + 1, (cliente.foto.length - caminho.length));
        try {
          console.log(cliente.foto);
          if (cliente.foto != '') {
            await Filesystem.deleteFile({
              path: nomeArquivo, //'1638380104139.jpg',
              directory: Directory.Data,
            });
          }
          this.toastService.presentToast('Cliente removido com sucesso', 3000, 'top');
          this.slidingList.closeSlidingItems();
        } catch (e) {
          await this.alertService.presentAlert('Falha', 'Remoção do arquivo não foi executada', e, ['Ok']);
        }
        this.clientes = await this.clientesService.getAll();
      };
      await this.alertService.presentConfirm('Remover Cliente', 'Confirma remoção?', successFunction);
    } catch (e) {
      await this.alertService.presentAlert('Falha', 'Remoção não foi executada', e, ['Ok']);
    }
  }
}
