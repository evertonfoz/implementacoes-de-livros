import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { AutenticacaoService } from '../../services/autenticacao.service';
import { NavController } from '@ionic/angular';

@Component({
  selector: 'app-register',
  templateUrl: './registrar.page.html',
  styleUrls: ['./registrar.page.scss'],
})
export class RegistrarPage implements OnInit {

  validationsForm: FormGroup;
  errorMessage: '';
  successMessage: string;

  validationMessages = {
    email: [
      { type: 'required', message: 'Informe o e-Mail' },
      { type: 'pattern', message: 'Informe um email válido' }
    ],
    password: [
      { type: 'required', message: 'Informe a senha' },
      { type: 'minlength', message: 'A senha precisa ter ao menos 6 caracteres' }
    ]
  };

  constructor(
    private navCtrl: NavController,
    private autenticacaoService: AutenticacaoService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    this.validationsForm = this.formBuilder.group({
      email: new FormControl('', Validators.compose([
        Validators.required,
        Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')
      ])),
      password: new FormControl('', Validators.compose([
        Validators.minLength(6),
        Validators.required
      ])),
    });
  }

  registrar(value) {
    this.autenticacaoService.registrar(value)
      .then(res => {
        this.errorMessage = '';
        this.successMessage = 'Sua conta foi criada com sucesso. Se autentique.';
      }, err => {
        this.errorMessage = err.message;
        this.successMessage = '';
      });
  }

  goLoginPage() {
    this.navCtrl.navigateBack('');
  }
}
