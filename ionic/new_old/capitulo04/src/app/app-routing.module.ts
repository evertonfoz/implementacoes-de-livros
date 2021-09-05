import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'home',
    loadChildren: () => import('./pages/tipo-servicos/listagem/tipo-servicos-listagem.module').then(m => m.TipoServicosListagemPageModule)
  },
  {
    path: 'add-edit/:id',
    loadChildren: () => import('./pages/tipo-servicos/add-edit/tipo-servicos-add-edit.module').then(m => m.TipoServicosAddEditPageModule)
  },
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
