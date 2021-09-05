import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { PecasListagemPage } from './pecas-listagem.page';
import { PecasListagemPageRoutingModule } from './pecas-listagem-routing.module';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        IonicModule,
        PecasListagemPageRoutingModule
    ],
    declarations: [
        PecasListagemPage
    ]
})

export class PecasListagemPageModule { }