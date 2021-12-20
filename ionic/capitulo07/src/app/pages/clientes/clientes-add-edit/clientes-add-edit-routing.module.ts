import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ClientesAddEditPage } from './clientes-add-edit.page';

const routes: Routes = [
  {
    path: '',
    component: ClientesAddEditPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClientesAddEditPageRoutingModule {}
