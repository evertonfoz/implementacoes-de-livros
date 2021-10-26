import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full'
  },
  // {
  //   path: 'home',
  //   loadChildren: () => import('./pages/menu/sidemenu/sidemenu.module').then(m => m.SideMenuPageModule)
  // },
  // {
  //   path: 'pecas-add-edit/:id',
  //   loadChildren: () => import('./pages/pecas/pecas-add-edit/pecas-add-edit.module').then(m => m.PecasAddEditPageModule)
  // },

  // {
  //   path: 'tipo-servicos-listagem',
  //   loadChildren: () => import('./pages/tipo-servicos/tipo-servicos-listagem/tipo-servicos-listagem.module').then(m => m.TipoServicosListagemPageModule)
  // },
  // {
  //   path: 'tipo-servicos-add-edit/:id',
  //   loadChildren: () => import('./pages/tipo-servicos/tipo-servicos-add-edit/tipo-servicos-add-edit.module').then(m => m.TipoServicosAddEditPageModule)
  // },
  // {
  //   path: 'pecas-add-edit',
  //   loadChildren: () => import('./pages/pecas/pecas-add-edit/pecas-add-edit.module').then(m => m.PecasAddEditPageModule)
  // },
  // {
  //   path: 'pecas-listagem',
  //   loadChildren: () => import('./pages/pecas/pecas-listagem/pecas-listagem.module').then(m => m.PecasListagemPageModule)
  // },
  {
    path: 'ordensdeservico-listagem',
    loadChildren: () => import('./pages/ordensdeservico/ordensdeservico-listagem/ordensdeservico-listagem.module').then(m => m.OrdensdeservicoListagemPageModule)
  },
  {
    path: 'dashboard',
    loadChildren: () => import('./pages/dashboard/dashboard.module').then(m => m.DashboardPageModule)
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
