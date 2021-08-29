import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';

import { IonicModule } from '@ionic/angular';

import { TipoServicosListagemPage } from './tipo-servicos-listagem.page';
import { TipoServicosListagemPageRoutingModule } from './tipo-servicos-listagem-routing.module';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        IonicModule,
        TipoServicosListagemPageRoutingModule
    ],
    declarations: [TipoServicosListagemPage]
})
export class TipoServicosListagemPageModule { }