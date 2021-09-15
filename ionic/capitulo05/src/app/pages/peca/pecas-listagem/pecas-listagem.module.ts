import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { PecasListagemPageRoutingModule } from './pecas-listagem-routing.module';

import { PecasListagemPage } from './pecas-listagem.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    PecasListagemPageRoutingModule
  ],
  declarations: [PecasListagemPage]
})
export class PecasListagemPageModule {}
