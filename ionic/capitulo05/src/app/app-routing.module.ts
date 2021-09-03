import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    loadChildren: () => import('./pages/ordensdeservico/listagem/ordensdeservico-listagem.module').then(m => m.OrdensDeServicoListagemPageModule)
  },
  {
    path: 'pecas',
    loadChildren: () => import('./pages/pecas/listagem/pecas-listagem.module').then(m => m.PecasListagemPageModule)
  },
  {
    path: 'add-edit/:id',
    loadChildren: () => import('./pages/tipo-servicos/add-edit/tipo-servicos-add-edit.module').then(m => m.TipoServicosAddEditPageModule)
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
