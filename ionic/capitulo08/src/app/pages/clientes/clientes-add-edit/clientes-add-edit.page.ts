import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Cliente } from 'src/app/models/cliente.model';
import { ActionSheetController, LoadingController, MenuController, Platform } from '@ionic/angular';
import { AlertService } from 'src/app/services/alert.service';
import { ClientesService } from 'src/app/services/clientes.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastService } from 'src/app/services/toast.service';
import { DatePicker } from '@ionic-native/date-picker/ngx';
import { FotosService } from 'src/app/services/fotos.service';
import { Capacitor } from '@capacitor/core';
import { Firestore } from '@angular/fire/firestore';
import { getStorage, uploadBytes, ref as storageRef, getDownloadURL, FirebaseStorage } from 'firebase/storage';
import { Directory, Filesystem } from '@capacitor/filesystem';

@Component({
  templateUrl: './clientes-add-edit.page.html',
  styleUrls: ['./clientes-add-edit.page.scss']
})
export class ClientesAddEditPage implements OnInit {
  private cliente: Cliente;
  public modoDeEdicao = false;
  public clienteForm: FormGroup;
  public caminhoParaFoto: string = 'assets/imgs/icon_clientes.png';

  constructor(
    private formBuilder: FormBuilder,
    private alertService: AlertService,
    private loadingCtrl: LoadingController,
    private clientesService: ClientesService,
    private router: Router,
    private toastService: ToastService,
    private platform: Platform,
    private datePicker: DatePicker,
    private route: ActivatedRoute,
    private actionSheetController: ActionSheetController,
    private fotosService: FotosService,
    private _fireStore: Firestore,
  ) { }

  async ngOnInit() {
  }

  async capturarFoto() {
    const actionSheet = await this.actionSheetController.create(
      {
        header: 'Capturar a foto do cliente',
        buttons: [{
          text: 'Da galeria de imagens',
          handler: async () => {
            await this.fotosService.escolherFoto();
            this.caminhoParaFoto = Capacitor.convertFileSrc(this.fotosService.caminhoParaFoto);
          }
        },
        {
          text: 'Utilizar a câmera',
          handler: async () => {
            await this.fotosService.obterFoto();
            this.caminhoParaFoto = Capacitor.convertFileSrc(this.fotosService.caminhoParaFoto);
          }
        },
        {
          text: 'Cancelar',
          role: 'cancel'
        }
        ]
      });
    await actionSheet.present();
  }

  async ionViewWillEnter() {
    const id = this.route.snapshot.paramMap.get('id');

    if (id !== '-1') {
      this.cliente = await this.clientesService.getById(id);
      this.caminhoParaFoto = this.cliente.foto;
    } else {
      this.cliente = {
        clienteid: '', nome: '', email: '', telefone: '', renda: 0.00, nascimento: new Date(),
        foto: this.caminhoParaFoto, nomeDaFoto: this.obterNomeDoArquivo()
      };
      this.modoDeEdicao = true;
    }

    this.clienteForm = this.formBuilder.group({
      clienteid: [this.cliente.clienteid],
      nome: [this.cliente.nome, Validators.required],
      email: [this.cliente.email, Validators.required],
      telefone: [this.cliente.telefone, Validators.required],
      renda: [this.cliente.renda, Validators.required],
      nascimento: [this.cliente.nascimento, Validators.required],
      nascimentoForm: [{ value: this.cliente.nascimento.toLocaleDateString(), disabled: !this.modoDeEdicao }, Validators.required],
      foto: [this.cliente.foto],
      nomeDaFoto: [this.obterNomeDoArquivo()]
    });
  }

  async submit() {
    if (this.clienteForm.invalid || this.clienteForm.pending) {
      await this.alertService.presentAlert('Falha', 'Gravação não foi executada',
        'Verifique os dados informados para o atendimento', ['Ok']);
      return;
    }

    // Estamos utilizando pela primeira vez este controle
    const loading = await this.loadingCtrl.create();
    await loading.present();

    const urlArquivoEnviado = await this.uploadFile();
    await this.removerFotoLocal();

    console.log('this.obterNomeDoArquivo(): ' + this.obterNomeDoArquivo());
    if (this.fotosService.caminhoParaFoto != '') {
      this.clienteForm.controls.foto.setValue(urlArquivoEnviado);
      this.clienteForm.controls.nomeDaFoto.setValue(this.obterNomeDoArquivo());
    } else {
      this.clienteForm.controls.foto.setValue('');
    }

    if (this.cliente.clienteid === '') {
      await this.clientesService.create(this.clienteForm.value);
    } else {
      await this.clientesService.update(this.clienteForm.value);
    }

    loading.dismiss().then(() => {
      this.toastService.presentToast('Gravação bem sucedida', 3000, 'top');
      this.router.navigateByUrl('/clientes-listagem');
    });
  }

  async removerFotoLocal() {
    if (this.fotosService.caminhoParaFoto != '') {
      await Filesystem.deleteFile({
        path: this.obterNomeDoArquivo(),
        directory: Directory.Data,
      });
    }
  }

  obterNomeDoArquivo() {
    return this.fotosService.caminhoParaFoto.substr(this.fotosService.caminhoParaFoto.lastIndexOf('/') + 1);
  }

  async uploadFile() {
    const storage: FirebaseStorage = getStorage(this._fireStore.app, this._fireStore.app.options.storageBucket);
    const storageReference = storageRef(storage, "fotosClientes/" + this.obterNomeDoArquivo());

    await uploadBytes(storageReference, await this.fotosService.lerComoBlob(this.caminhoParaFoto));
    return await getDownloadURL(storageReference);
  }

  selecionarData() {
    if (!this.modoDeEdicao) {
      return;
    }

    this.platform.ready().then(() => {
      if (this.platform.is('capacitor')) {
        this.datePicker.show({
          date: new Date(),
          mode: 'date',
          locale: 'pt-br',
          doneButtonLabel: 'Confirmar',
          cancelButtonLabel: 'Cancelar'
        })
          .then(
            data => {
              this.clienteForm.controls.nascimentoForm.setValue(data.toLocaleDateString());
              this.clienteForm.controls.nascimento.setValue(data);
            }
          );
      } else {
        // instruções para execução no navegador
      }
    });
  }

  iniciarEdicao() {
    this.modoDeEdicao = true;
  }

  cancelarEdicao() {
    this.clienteForm.setValue(this.cliente);
    this.modoDeEdicao = false;
  }
}
