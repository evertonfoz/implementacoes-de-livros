import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

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

  constructor(private formBuilder: FormBuilder) {
  }

  ngOnInit() {
    this.clienteForm = this.formBuilder.group({
      nome: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(50)])],
      email: ['', Validators.compose([Validators.required, Validators.email])],
      telefone: ['', Validators.required],
      renda: ['0', Validators.compose([Validators.required, Validators.min(0)])],
      nascimento: ['', Validators.required]
    });
  }

  async submit() {
    this.errorsMessage = [];
    if (this.clienteForm.get('nome').hasError('required')) {
      this.errorsMessage.push('Nome é obrigatório');
    }
    if (this.clienteForm.get('email').hasError('required')) {
      this.errorsMessage.push('Email é obrigatório');
    }
    this.hasErrors = this.errorsMessage.length > 0;
  }

}
