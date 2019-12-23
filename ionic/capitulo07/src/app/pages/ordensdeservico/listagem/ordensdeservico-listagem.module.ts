import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { RouterModule, Routes } from '@angular/router';
import { OrdensDeServicoListagemPage } from './ordensdeservico-listagem.page';

const routes: Routes = [
    { path: '', component: OrdensDeServicoListagemPage }
  ];

@NgModule({
    imports: [
      CommonModule,
      FormsModule,
      IonicModule,
      RouterModule.forChild(routes)
    ],
    declarations: [
        OrdensDeServicoListagemPage
    ]
})

export class OrdensDeServicoListagemPageModule {}
