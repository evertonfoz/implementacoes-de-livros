import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ClienteAddEditPage } from './cliente-add-edit.page';

const routes: Routes = [
  {
    path: '',
    component: ClienteAddEditPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClienteAddEditPageRoutingModule {}
