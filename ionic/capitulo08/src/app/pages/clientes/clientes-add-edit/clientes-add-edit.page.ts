import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Cliente } from 'src/app/models/cliente.model';
import { ActionSheetController, LoadingController, MenuController } from '@ionic/angular';
import { AlertService } from 'src/app/services/alert.service';
import { ClientesService } from 'src/app/services/clientes.service';
import { ToastService } from 'src/app/services/toast.service';
import { ActivatedRoute, Router } from '@angular/router';
import { getApp } from 'firebase/app';
import { getFirestore } from '@firebase/firestore';
import { collection, onSnapshot, query } from 'firebase/firestore';
import { Firestore } from '@angular/fire/firestore';
import { getDatabase, onValue, ref } from 'firebase/database';
import { Camera, CameraPhoto, CameraResultType, CameraSource } from '@capacitor/camera';
import { Directory, Filesystem } from '@capacitor/filesystem';
import { PhotoService } from 'src/app/services/photo.service';
import { Capacitor } from '@capacitor/core';
import { AngularFireStorage } from '@angular/fire/compat/storage';
import { FirebaseStorage } from '@angular/fire/storage';
import { getStorage, uploadBytes, ref as storageRef, StorageReference, getDownloadURL } from 'firebase/storage';

@Component({
  templateUrl: './clientes-add-edit.page.html',
  styleUrls: ['./clientes-add-edit.page.scss']
})
export class ClientesAddEditPage implements OnInit {
  private cliente: Cliente;
  public modoDeEdicao = false;
  public clientesForm: FormGroup;

  public search: string;
  public caminhoParaFoto: string = 'assets/imgs/icon_clientes.png';
  private uriArquivoImagem;
  // public photoFilename: string = '';
  // public pathToFilePhoto: string = '';


  constructor(
    private formBuilder: FormBuilder,
    private loadingCtrl: LoadingController,
    private alertService: AlertService,
    private clientesService: ClientesService,
    private toastService: ToastService,
    private router: Router, private route: ActivatedRoute,
    private actionSheetController: ActionSheetController,
    private photoService: PhotoService,
    // private storage: AngularFireStorage,
    private _fireStore: Firestore,
  ) {
  }

  async uploadFile() {
    const storage: FirebaseStorage = getStorage(this._fireStore.app, this._fireStore.app.options.storageBucket);
    const storageReference = storageRef(storage, "fotosClientes/" + this.obterNomeDoArquivo());

    await uploadBytes(storageReference, await this.photoService.lerComoBlob(this.caminhoParaFoto));

    return await getDownloadURL(storageReference);
  }

  async removerFotoLocal() {
    if (this.photoService.caminhoParaFoto != '') {
      await Filesystem.deleteFile({
        path: this.obterNomeDoArquivo(),
        directory: Directory.Data,
      });
    }
  }

  obterNomeDoArquivo() {
    // const caminho: string = this.photoService.caminhoParaFoto.substr(0, this.photoService.caminhoParaFoto.lastIndexOf('/') + 1);
    // const nomeArquivo: string = this.photoService.caminhoParaFoto.substr(this.photoService.caminhoParaFoto.lastIndexOf('/') + 1);

    // console.log('this.photoService.caminhoParaFoto ' + this.photoService.caminhoParaFoto);
    // const caminho: string = this.photoService.caminhoParaFoto;
    return this.photoService.caminhoParaFoto.substr(this.photoService.caminhoParaFoto.lastIndexOf('/') + 1);
  }


  async capturarFoto() {
    const actionSheet = await this.actionSheetController.create(
      {
        header: 'Capturar a foto do cliente',
        buttons: [{
          text: 'Da galeria de imagens',
          handler: async () => {
            await this.photoService.escolherFoto();
            this.caminhoParaFoto = Capacitor.convertFileSrc(this.photoService.caminhoParaFoto);
            const caminho: string = this.photoService.caminhoParaFoto.substr(0, this.photoService.caminhoParaFoto.lastIndexOf('/') + 1);
            const nomeArquivo: string = this.photoService.caminhoParaFoto.substr(this.photoService.caminhoParaFoto.lastIndexOf('/') + 1);

            // let caminhoCorrigido = this.photoService.caminhoParaFoto.substr(0, this.photoService.caminhoParaFoto.lastIndexOf('/') + 1);
            // let nomeUtilizado = this.photoService.caminhoParaFoto.substr(this.photoService.caminhoParaFoto.lastIndexOf('/') + 1);

            // console.log('1. ' + caminhoCorrigido);
            // console.log('2. ' + nomeUtilizado);
          }
        },
        {
          text: 'Utilizar a câmera',
          handler: async () => {
            await this.photoService.obterFoto();

            this.caminhoParaFoto = Capacitor.convertFileSrc(this.photoService.caminhoParaFoto);
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

  formatTimestamp(ts) {
    let [D, M, Y, h, m, s, ap] = ts.toLowerCase().split(/\W/);
    h = String(h % 12 + (ap == 'am' ? 0 : 12)).padStart(2, '0');
    return `${Y}-${M}-${D}T${h}:${m}:${s}Z`;
  }

  async ionViewWillEnter() {
    const id = this.route.snapshot.paramMap.get('id');

    if (id !== '-1') {
      this.cliente = await this.clientesService.getById(id);
      this.caminhoParaFoto = this.cliente.foto;
      // this.photoFilename = this.cliente.foto;
    } else {
      this.cliente = {
        clienteid: '', nome: '', email: '', telefone: '', renda: 0.00, nascimento: new Date(),
        foto: this.caminhoParaFoto, nomeDaFoto: this.obterNomeDoArquivo()
      };
      this.modoDeEdicao = true;
    }

    this.clientesForm = this.formBuilder.group({
      clienteid: [this.cliente.clienteid],
      nome: [this.cliente.nome, Validators.required],
      email: [this.cliente.email, Validators.required],
      telefone: [this.cliente.telefone, Validators.required],
      renda: [this.cliente.renda, Validators.required],
      nascimento: [this.cliente.nascimento.toISOString(), Validators.required],
      foto: [this.cliente.foto],
      nomeDaFoto: [this.obterNomeDoArquivo()],
      // caminhoParaFoto: [this.cliente.caminhoParaFoto]
    });
  }

  ngOnInit() {

  }

  async submit() {
    if (this.clientesForm.invalid || this.clientesForm.pending) {
      await this.alertService.presentAlert('Falha', 'Gravação não foi executada',
        'Verifique os dados informados para o cliente', ['Ok']);
      return;
    }

    // Estamos utilizando pela primeira vez este controle
    const loading = await this.loadingCtrl.create();
    await loading.present();


    const urlArquivoEnviado = await this.uploadFile();
    await this.removerFotoLocal();

    if (this.photoService.caminhoParaFoto != '') {
      this.clientesForm.controls.foto.setValue(urlArquivoEnviado);
      this.clientesForm.controls.nomeDaFoto.setValue(this.obterNomeDoArquivo());
    } else {
      this.clientesForm.controls.foto.setValue('');
    }
    // this.clientesForm.controls.caminhoParaFoto.setValue(this.pathToFilePhoto);
    if (this.cliente.clienteid === '') {
      await this.clientesService.create(this.clientesForm.value);
    } else {
      await this.clientesService.update(this.clientesForm.value);
    }

    loading.dismiss().then(() => {
      this.toastService.presentToast('Gravação bem sucedida', 3000, 'top');
      this.router.navigateByUrl('/clientes-listagem');
    });
  }



  iniciarEdicao() {
    this.modoDeEdicao = true;
  }
}