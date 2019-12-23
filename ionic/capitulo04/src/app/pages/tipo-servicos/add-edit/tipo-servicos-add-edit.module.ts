import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { RouterModule, Routes } from '@angular/router';
import { TipoServicosAddEditPage } from './tipo-servicos-add-edit.page';

const routes: Routes = [
    { path: '', component: TipoServicosAddEditPage }
  ];

@NgModule({
    imports: [
      CommonModule,
      FormsModule,
      IonicModule,
      RouterModule.forChild(routes),
      ReactiveFormsModule
    ],
    declarations: [
      TipoServicosAddEditPage
    ]
})

export class TipoServicosAddEditPageModule {}
