import { Component, OnInit, ViewChild } from '@angular/core';
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

  async removerCliente(cliente: Cliente) {
    try {
      const successFunction = async () => {
        // this.clientesService.removeById(cliente.clienteid);

        const caminho: string = cliente.caminhoParaFoto.substr(0, cliente.caminhoParaFoto.lastIndexOf('/') + 1);
        const nomeArquivo: string = cliente.caminhoParaFoto.substr(cliente.caminhoParaFoto.lastIndexOf('/') + 1, (cliente.caminhoParaFoto.length - caminho.length));
        // const caminhoParaArquivo = this.file.dataDirectory + nomeArquivo;

        // console.log('cliente.foto ' + cliente.foto);
        // console.log('caminho ' + caminho);
        console.log('nomeArquivo ' + nomeArquivo);
        // console.log('caminhoParaArquivo ' + cliente.caminhoParaFoto);
        // console.log('Directory.Data ' + Directory.Documents + ' - ' + nomeArquivo);

        try {
          console.log(1);
          await Filesystem.deleteFile({
            path: nomeArquivo, //'1638380104139.jpg',
            directory: Directory.Data,
          });
          console.log(2);
          // await Filesystem.deleteFile({
          //   path: nomeArquivo,
          //   directory: Directory.Documents,
          // });
          // await this.file.removeFile(this.file.dataDirectory, nomeArquivo);
          this.toastService.presentToast('Cliente removido com sucesso', 3000, 'top');
          this.slidingList.closeSlidingItems();
        } catch (e) {
          await this.alertService.presentAlert('Falha', 'Remoção do arquivo não foi executada', e, ['Ok']);
        }
      };
      await this.alertService.presentConfirm('Remover Cliente', 'Confirma remoção?', successFunction);
    } catch (e) {
      await this.alertService.presentAlert('Falha', 'Remoção não foi executada', e, ['Ok']);
    }
  }
}
