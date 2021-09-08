import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ClienteAddEditPageRoutingModule } from './cliente-add-edit-routing.module';

import { ClienteAddEditPage } from './cliente-add-edit.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ClienteAddEditPageRoutingModule
  ],
  declarations: [ClienteAddEditPage]
})
export class ClienteAddEditPageModule {}
