import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PecasPage } from './pecas.page';

const routes: Routes = [
  {
    path: '',
    component: PecasPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PecasPageRoutingModule {}
