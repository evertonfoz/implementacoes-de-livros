import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { OrdensdeservicoAddEditPage } from './ordensdeservico-add-edit.page';

const routes: Routes = [
  {
    path: '',
    component: OrdensdeservicoAddEditPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class OrdensdeservicoAddEditPageRoutingModule {}
