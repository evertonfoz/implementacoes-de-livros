import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ClientesListagemPageRoutingModule } from './clientes-listagem-routing.module';

import { ClientesListagemPage } from './clientes-listagem.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ClientesListagemPageRoutingModule
  ],
  declarations: [ClientesListagemPage]
})
export class ClientesListagemPageModule {}
