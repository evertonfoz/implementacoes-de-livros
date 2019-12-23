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
              loadChildren: '../pecas/pecas.module#PecasPageModule'
            }
          ]
        },
        {
            path: 'clientes',
            children: [
              {
                path: '',
                loadChildren: '../clientes/listagem/clientes-listagem.module#ClientesListagemPageModule'
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
  imports:
    [
      RouterModule.forChild(routes)
    ],
  exports:
    [
      RouterModule
    ]
})
export class HomePageRoutingModule {}
