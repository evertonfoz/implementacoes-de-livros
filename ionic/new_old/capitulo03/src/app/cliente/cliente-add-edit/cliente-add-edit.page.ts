import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DatePicker } from '@ionic-native/date-picker/ngx';
import { AlertController, Platform, ToastController } from '@ionic/angular';

@Component({
  selector: 'app-cliente-add-edit',
  templateUrl: './cliente-add-edit.page.html',
  styleUrls: ['./cliente-add-edit.page.scss'],
})
export class ClienteAddEditPage implements OnInit {

  cliente = {};
  clienteForm: FormGroup;
  hasErrors = false;
  errorsMessage: string[];

  validationMessages = {
    nome: [
      { type: 'required', message: 'Nome é obrigatório' },
      { type: 'minlength', message: 'Nome deve ter ao menos 3 caracteres' },
      { type: 'maxlength', message: 'Nome não pode ter mais que 50 caracteres' }
    ],
    renda: [
      { type: 'min', message: 'Renda precisa ser positiva' }
    ]
  };

  constructor(private formBuilder: FormBuilder,
    private datePicker: DatePicker,
    private platform: Platform,
    private alertCtrl: AlertController,
    private toastCtrl: ToastController) {
  }

  get isBrowserPlatform(): boolean {
    if (this.platform.is('cordova')) {
      return false;
    }
    return true;
  }

  ngOnInit() {
    this.clienteForm = this.formBuilder.group({
      nome: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(50)])],
      email: ['', Validators.compose([Validators.required, Validators.email])],
      telefone: ['', Validators.required],
      renda: ['0', Validators.compose([Validators.required, Validators.min(0)])],
      nascimento: [{ value: '', disabled: !this.isBrowserPlatform }, Validators.required]
    });
  }

  // async submit() {
  //   this.errorsMessage = [];
  //   if (this.clienteForm.get('nome').hasError('required')) {
  //     this.errorsMessage.push('Nome é obrigatório');
  //   }
  //   if (this.clienteForm.get('email').hasError('required')) {
  //     this.errorsMessage.push('Email é obrigatório');
  //   }
  //   this.hasErrors = this.errorsMessage.length > 0;

  //   if (!this.hasErrors) {
  //     await this.presentAlert('Sucesso', 'Gravação bem sucedida', 'Os dados do cliente foram gravados', ['Ok']);
  //   }
  // }

  async submit() {
    await this.presentToast('Gravação bem sucedida', 3000, 'top');
  }

  selecionarData() {
    this.platform.ready().then(() => {
      if (this.platform.is('cordova')) {
        this.datePicker.show({
          date: new Date(),
          mode: 'date',
          locale: 'pt-br',
          doneButtonLabel: 'Confirmar',
          cancelButtonLabel: 'Cancelar'
        })
          .then(
            data => this.clienteForm.controls.nascimento.setValue(data.toISOString())
          );
      } else {
        // instruções para execução no navegador
      }
    });
  }

  async presentAlert(header: string, subHeader: string, message: string, buttons: string[]) {
    const alert = await this.alertCtrl.create({
      header,
      subHeader,
      message,
      buttons
    });
    await alert.present();
  }

  async presentToast(message: string, duration: number, position: 'top' | 'bottom') {
    const toast = await this.toastCtrl.create({
      message,
      duration,
      position
    });
    toast.present();
  }
}
