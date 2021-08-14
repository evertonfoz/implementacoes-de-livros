import { SideMenuPage } from './sidemenu.page';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { ClientesAddEditPage } from '../clientes/add-edit/clientes-add-edit.page';
import { ClientesListagemPage } from '../clientes/listagem/clientes-listagem.page';
import { OrdensDeServicoListagemPage } from '../ordensdeservico/listagem/ordensdeservico-listagem.page';
import { ClientesSearchPage } from '../clientes/search/clientes-search.page';
import { OrdensDeServicoAddEditPage } from '../ordensdeservico/add-edit/ordensdeservico-add-edit.page';

const routes: Routes = [
  {
    path: 'menu',
    component: SideMenuPage,
    children: [
      /* {
          path: 'clientes-add-edit',
          outlet: 'menucontent',
          component: ClientesAddEditPage
      }, */
      {
        path: 'clientes-add-edit/:id',
        outlet: 'menucontent',
        component: ClientesAddEditPage
      },
      {
          path: 'clientes',
          outlet: 'menucontent',
          component: ClientesListagemPage,
      },
      {
        path: 'atendimentos',
        outlet: 'menucontent',
        component: OrdensDeServicoListagemPage,
      },
      {
        path: 'pesquisarclientes',
        outlet: 'menucontent',
        component: ClientesSearchPage,
      },
      {
        path: 'os-add-edit/:id',
        outlet: 'menucontent',
        component: OrdensDeServicoAddEditPage
      },
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
  ],
  exports: [RouterModule]
})
export class SideMenuRoutingModule {}
