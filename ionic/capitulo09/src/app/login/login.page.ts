import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { NavController } from '@ionic/angular';
import { AutenticacaoService } from '../services/autenticacao.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {
  validationsForm: FormGroup;
  errorMessage: string;

  validationMessages = {
    email: [
      { type: 'required', message: 'Informe o E-Mail' },
      { type: 'pattern', message: 'Informe um email válido' }
    ],
    password: [
      { type: 'required', message: 'Informe a senha' },
      { type: 'minlength', message: 'A senha precisa ter ao menos 6 caracteres' }
    ]
  };

  constructor(
    private formBuilder: FormBuilder,
    private autenticacaoService: AutenticacaoService,
    private navCtrl: NavController,
    private router: Router
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

  login(value) {
    this.autenticacaoService.login(value)
    .then(res => {
      this.errorMessage = '';
      // this.router.navigateByUrl('/home');
      this.navCtrl.navigateForward('/home');
    }, err => {
      this.errorMessage = err.message;
    });
  }

  goToRegistrarPage() {
    this.navCtrl.navigateForward('/registrar');
  }
}
