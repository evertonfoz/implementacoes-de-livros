import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { LookforaddressPageRoutingModule } from './lookforaddress-routing.module';

import { LookforaddressPage } from './lookforaddress.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    LookforaddressPageRoutingModule
  ],
  declarations: [LookforaddressPage]
})
export class LookforaddressPageModule { }
