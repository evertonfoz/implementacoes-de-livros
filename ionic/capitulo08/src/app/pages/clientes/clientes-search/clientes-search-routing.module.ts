import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ClientesSearchPage } from './clientes-search.page';

const routes: Routes = [
  {
    path: '',
    component: ClientesSearchPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClientesSearchPageRoutingModule {}
