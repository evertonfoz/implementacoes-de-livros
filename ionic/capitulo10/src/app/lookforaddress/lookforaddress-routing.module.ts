import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LookforaddressPage } from './lookforaddress.page';

const routes: Routes = [
  {
    path: '',
    component: LookforaddressPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class LookforaddressPageRoutingModule {}
