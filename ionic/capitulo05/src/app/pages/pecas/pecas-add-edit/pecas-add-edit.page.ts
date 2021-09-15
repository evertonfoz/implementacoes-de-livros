import { Component, OnInit } from '@angular/core';
import { Peca } from 'src/app/models/peca.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Guid } from 'guid-typescript';
import { ToastService } from 'src/app/services/toast.service';
import { PecasService } from 'src/app/services/pecas.service';

@Component({
  templateUrl: './pecas-add-edit.page.html'
})
export class PecasAddEditPage implements OnInit {
  private peca: Peca;
  public modoDeEdicao = false;
  public pecasForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private toastService: ToastService,
    private pecasService: PecasService,
  ) { }

  iniciarEdicao() {
    this.modoDeEdicao = true;
  }

  cancelarEdicao() {
    this.pecasForm.setValue(this.peca);
    this.modoDeEdicao = false;
  }

  async submit() {
    await this.pecasService.update(this.pecasForm.value);
    this.peca = this.pecasForm.value;

    this.toastService.presentToast('Gravação bem sucedida', 3000, 'top');
    this.modoDeEdicao = false;
    // Navegar para a página principal
  }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');

    if (id && Guid.isGuid(id)) {
      // Recuperaremos o objeto persistido
    } else {
      this.peca = { id: Guid.createEmpty(), nome: '', valor: 0.00 };
      this.modoDeEdicao = true;
    }

    this.pecasForm = this.formBuilder.group({
      id: [this.peca.id],
      nome: [this.peca.nome, Validators.required],
      valor: [this.peca.valor, Validators.required]
    });
  }

}