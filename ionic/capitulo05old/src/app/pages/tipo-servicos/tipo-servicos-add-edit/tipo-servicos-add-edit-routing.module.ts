import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TipoServicosAddEditPage } from './tipo-servicos-add-edit.page';

const routes: Routes = [
  {
    path: '',
    component: TipoServicosAddEditPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TipoServicosAddEditPageRoutingModule {}
