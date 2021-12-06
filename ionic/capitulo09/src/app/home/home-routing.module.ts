import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomePage } from './home.page';

const routes: Routes = [
  // {
  //   path: '',
  //   component: HomePage,
  // },
  {
    path: 'tabsMenu',
    component: HomePage,
    children: [
      {
        path: 'pecas',
        children: [
          {
            path: '',
            loadChildren: () => import('../pecas/pecas.module').then(m => m.PecasPageModule)
          }
        ]
      },

      {
        path: 'clientes',
        children: [
          {
            path: '',
            loadChildren: () => import('../clientes/clientes-listagem/clientes-listagem.module').then(m => m.ClientesListagemPageModule)
          }
        ]
      },
    ]
  },
  {
    path: '',
    redirectTo: 'tabsMenu/pecas',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class HomePageRoutingModule { }
