import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { ClientesAddEditPageModule } from '../add-edit/clientes-add-edit.module';
import { ClientesListagemPage } from './clientes-listagem.page';

@NgModule({
    imports: [
      CommonModule,
      FormsModule,
      IonicModule,
      ClientesAddEditPageModule
    ],
    declarations: [
        ClientesListagemPage
    ]
})

export class ClientesListagemPageModule {}
