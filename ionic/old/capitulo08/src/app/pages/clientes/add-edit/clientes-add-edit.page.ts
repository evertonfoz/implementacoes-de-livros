import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Cliente } from 'src/app/models/cliente.model';
import { LoadingController, ActionSheetController, Platform } from '@ionic/angular';
import { AlertService } from 'src/app/services/alert.service';
import { FirestoreService } from 'src/app/services/firestore.service';
import { ClientesService } from 'src/app/services/clientes.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastService } from 'src/app/services/toast.service';
import { Camera, CameraOptions, PictureSourceType } from '@ionic-native/Camera/ngx';
import { File } from '@ionic-native/File/ngx';
import { WebView } from '@ionic-native/ionic-webview/ngx';
import { FilePath } from '@ionic-native/file-path/ngx';


@Component({
    templateUrl: './clientes-add-edit.page.html',
    styleUrls: ['./clientes-add-edit.page.scss']
})
export class ClientesAddEditPage implements OnInit {
    private cliente: Cliente;
    public modoDeEdicao = false;
    public clientesForm: FormGroup;
    public imagemSelecionada;
    private uriArquivoImagem;
    private loading;

    constructor(
        private formBuilder: FormBuilder,
        private alertService: AlertService,
        private loadingCtrl: LoadingController,
        private firestoreService: FirestoreService,
        private clientesService: ClientesService,
        private toastService: ToastService,
        private router: Router,
        private route: ActivatedRoute,
        private actionSheetController: ActionSheetController,
        private camera: Camera,
        private file: File,
        private webview: WebView,
        private platform: Platform,
        private filePath: FilePath
    ) {}

    ngOnInit() {
        this.imagemSelecionada = 'assets/imgs/icon_clientes.png';
    }

    async ionViewWillEnter() {
        const id = this.route.snapshot.paramMap.get('id');

        if (id !== '-1') {
            this.cliente = await this.clientesService.getById(id);
            this.imagemSelecionada = this.cliente.uriFotoParaExibir;
        } else {
            this.cliente = {clienteid: '', nome: '', email: '', telefone: '', renda: 0.00, nascimento: new Date(),
                uriFotoCapturada: '', nomeFotoEnviada: '', uriFotoParaExibir: this.imagemSelecionada };
            this.modoDeEdicao = true;
        }

        this.clientesForm = this.formBuilder.group({
            clienteid: [this.cliente.clienteid],
            nome: [this.cliente.nome, Validators.required],
            email: [this.cliente.email, Validators.required],
            telefone: [this.cliente.telefone, Validators.required],
            renda: [this.cliente.renda, Validators.required],
            nascimento: [this.cliente.nascimento.toISOString(), Validators.required],
            uriFotoCapturada: [this.cliente.uriFotoCapturada],
            nomeFotoEnviada: [this.cliente.nomeFotoEnviada],
            uriFotoParaExibir: [this.cliente.uriFotoParaExibir]
        });
    }

    async submit() {
        if (this.clientesForm.invalid || this.clientesForm.pending) {
            await this.alertService.presentAlert('Falha', 'Gravação não foi executada',
                'Verifique os dados informados para o atendimento', ['Ok']);
            return;
        }

        // Estamos utilizando pela primeira vez este controle
        const loading = await this.loadingCtrl.create();
        await loading.present();

        if (this.cliente.clienteid === '') {
            this.clientesForm.controls.clienteid.setValue(this.firestoreService.createID());
        }

        // this.clientesForm.controls.foto.setValue(this.imagemSelecionada);
        // Invocamos o serviço, enviando um objeto com os dados recebidos da visão

        if (this.uriArquivoImagem) {
            this.clientesForm.controls.uriFotoCapturada.setValue(this.uriArquivoImagem);
        }

        await this.clientesService.update(this.clientesForm.value)
            .then(
                () => {
                    loading.dismiss().then(() => {
                        this.toastService.presentToast('Gravação bem sucedida', 3000, 'top');
                        this.router.navigateByUrl('/menu/(menucontent:clientes)');
                    });
                },
                    error => {
                    console.error(error);
                }
            );
    }

    iniciarEdicao() {
        this.modoDeEdicao = true;
    }

    cancelarEdicao() {
        this.imagemSelecionada = this.cliente.uriFotoParaExibir;
        this.clientesForm.setValue(this.cliente);
        this.modoDeEdicao = false;
    }

    async capturarFoto() {
        const actionSheet = await this.actionSheetController.create(
        {
            header: 'Capturar a foto do cliente',
            buttons: [{
                text: 'Da galeria de imagens',
                handler: () => {
                    this.obterFoto(this.camera.PictureSourceType.PHOTOLIBRARY);
                }
            },
            {
                text: 'Utilizar a câmera',
                handler: () => {
                    this.obterFoto(this.camera.PictureSourceType.CAMERA);
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

    obterFoto(sourceType: PictureSourceType) {
        let caminhoCorrigido, nomeUtilizado;

        const options: CameraOptions = {
            quality: 10,
            targetHeight: 200,
            sourceType,
            targetWidth: 200,
            saveToPhotoAlbum: false,
            correctOrientation: true,
            destinationType: this.camera.DestinationType.FILE_URI,
            // destinationType: this.camera.DestinationType.DATA_URL,
            encodingType: this.camera.EncodingType.JPEG,
            mediaType: this.camera.MediaType.PICTURE
          };

        this.camera.getPicture(options).then(async (caminhoImagem) => {
            if (this.platform.is('android') && sourceType === this.camera.PictureSourceType.PHOTOLIBRARY) {
                const caminhoArquivo = await this.filePath.resolveNativePath(caminhoImagem);
                caminhoCorrigido = caminhoArquivo.substr(0, caminhoArquivo.lastIndexOf('/') + 1);
                nomeUtilizado = caminhoImagem.substring(caminhoImagem.lastIndexOf('/') + 1, caminhoImagem.lastIndexOf('?'));
            } else {
                caminhoCorrigido = caminhoImagem.substr(0, caminhoImagem.lastIndexOf('/') + 1);
                nomeUtilizado = caminhoImagem.substr(caminhoImagem.lastIndexOf('/') + 1);
            }

            this.uriArquivoImagem = caminhoCorrigido + nomeUtilizado;
            this.imagemSelecionada = this.caminhoParaImagem(this.uriArquivoImagem);
            console.log('2- ', this.imagemSelecionada);
        });
    }

    copiarArquivoParaDiretorioLocal(caminho, nomeAtual, novoNomeParaArquivo) {
        this.file.copyFile(caminho, nomeAtual, this.file.dataDirectory, novoNomeParaArquivo)
            .then(
                success => {
                    const caminhoParaArquivo = this.file.dataDirectory + novoNomeParaArquivo;
                    const caminhoParaArquivoConvertido = this.caminhoParaImagem(caminhoParaArquivo);
                    this.imagemSelecionada = caminhoParaArquivoConvertido;
            },
                error => {
                    this.toastService.presentToast('Erro ao copiar arquivo de imagem', 3000, 'top');
            });
    }

    caminhoParaImagem(caminhoParaImagem) {
        if (caminhoParaImagem === null) {
            return '';
        } else {
            const caminhoParaArquivoConvertido = this.webview.convertFileSrc(caminhoParaImagem);
            return caminhoParaArquivoConvertido;
        }
    }
}
