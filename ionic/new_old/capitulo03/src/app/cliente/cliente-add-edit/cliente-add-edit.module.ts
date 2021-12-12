import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ClienteAddEditPageRoutingModule } from './cliente-add-edit-routing.module';

import { ClienteAddEditPage } from './cliente-add-edit.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ClienteAddEditPageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [ClienteAddEditPage]
})
export class ClienteAddEditPageModule { }
