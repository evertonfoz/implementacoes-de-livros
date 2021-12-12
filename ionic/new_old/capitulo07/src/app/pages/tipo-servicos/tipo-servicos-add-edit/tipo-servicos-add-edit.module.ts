import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { TipoServicosAddEditPageRoutingModule } from './tipo-servicos-add-edit-routing.module';

import { TipoServicosAddEditPage } from './tipo-servicos-add-edit.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    TipoServicosAddEditPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [TipoServicosAddEditPage]
})
export class TipoServicosAddEditPageModule { }
