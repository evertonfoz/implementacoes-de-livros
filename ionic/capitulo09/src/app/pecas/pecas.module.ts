import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { PecasPageRoutingModule } from './pecas-routing.module';

import { PecasPage } from './pecas.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    PecasPageRoutingModule
  ],
  declarations: [PecasPage]
})
export class PecasPageModule {}
