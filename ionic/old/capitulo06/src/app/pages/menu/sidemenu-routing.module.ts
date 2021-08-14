import { SideMenuPage } from './sidemenu.page';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { OrdensDeServicoListagemPage } from '../ordensdeservico/listagem/ordensdeservico-listagem.page';
import { OrdensDeServicoAddEditPage } from '../ordensdeservico/add-edit/ordensdeservico-add-edit.page';
import { OrdensDeServicoAddEditPageModule } from '../ordensdeservico/add-edit/ordensdeservico-add-edit.module';

const routes: Routes = [
  {
    path: 'menu',
    component: SideMenuPage,
    children: [
      {
        path: 'atendimentos',
        outlet: 'menucontent',
        component: OrdensDeServicoListagemPage,
      },
      {
          path: 'os-add-edit/:id',
          outlet: 'menucontent',
          component: OrdensDeServicoAddEditPage
      }
    ]
  },
  {
    path: '',
    redirectTo: '/menu/(menucontent:atendimentos)',
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    OrdensDeServicoAddEditPageModule
  ],
  exports: [RouterModule]
})
export class SideMenuRoutingModule {}
