import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';

import { IonicModule } from '@ionic/angular';

import { LookforaddressPage } from './lookforaddress.page';

const routes: Routes = [
  {
    path: '',
    component: LookforaddressPage
  }
];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    RouterModule.forChild(routes)
  ],
  declarations: [LookforaddressPage]
})
export class LookforaddressPageModule {}
