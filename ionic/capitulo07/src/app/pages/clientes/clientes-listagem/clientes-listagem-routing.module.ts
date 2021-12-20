import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ClientesListagemPage } from './clientes-listagem.page';

const routes: Routes = [
  {
    path: '',
    component: ClientesListagemPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClientesListagemPageRoutingModule {}
