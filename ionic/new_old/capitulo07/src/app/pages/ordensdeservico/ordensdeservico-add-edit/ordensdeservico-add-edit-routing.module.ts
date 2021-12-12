import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { OrdensDeServicoAddEditPage } from './ordensdeservico-add-edit.page';

const routes: Routes = [
  {
    path: '',
    component: OrdensDeServicoAddEditPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class OrdensdeservicoAddEditPageRoutingModule { }
