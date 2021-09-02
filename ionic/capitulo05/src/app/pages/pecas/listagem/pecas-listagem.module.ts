import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { RouterModule, Routes } from '@angular/router';
import { PecasListagemPage } from './pecas-listagem.page';

const routes: Routes = [
    { path: '', component: PecasListagemPage }
];

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        IonicModule,
        RouterModule.forChild(routes)
    ],
    declarations: [
        PecasListagemPage
    ]
})

export class PecasListagemPageModule { }