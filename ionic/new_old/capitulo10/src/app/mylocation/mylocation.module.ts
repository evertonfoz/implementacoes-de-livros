import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { MylocationPageRoutingModule } from './mylocation-routing.module';

import { MylocationPage } from './mylocation.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    MylocationPageRoutingModule
  ],
  declarations: [MylocationPage]
})
export class MylocationPageModule {}
