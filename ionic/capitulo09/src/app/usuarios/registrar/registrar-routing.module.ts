import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RegistrarPage } from './registrar.page';

const routes: Routes = [
  {
    path: '',
    component: RegistrarPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class RegistrarPageRoutingModule {}
