import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePage } from './home.page';

const routes: Routes = [
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
        loadChildren: () => import('../clientes-listagem/clientes-listagem.module').then(m => m.ClientesListagemPageModule)
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
  exports: [RouterModule]
})
export class HomePageRoutingModule { }
