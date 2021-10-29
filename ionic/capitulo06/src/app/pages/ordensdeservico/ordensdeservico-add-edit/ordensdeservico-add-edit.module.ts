import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { OrdensdeservicoAddEditPageRoutingModule } from './ordensdeservico-add-edit-routing.module';

import { OrdensDeServicoAddEditPage } from './ordensdeservico-add-edit.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    OrdensdeservicoAddEditPageRoutingModule
  ],
  declarations: [OrdensDeServicoAddEditPage]
})
export class OrdensdeservicoAddEditPageModule { }
