import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { OrdensdeservicoListagemPageRoutingModule } from './ordensdeservico-listagem-routing.module';

import { OrdensdeservicoListagemPage } from './ordensdeservico-listagem.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    OrdensdeservicoListagemPageRoutingModule
  ],
  declarations: [OrdensdeservicoListagemPage]
})
export class OrdensdeservicoListagemPageModule {}
