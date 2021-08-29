import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'home',
    loadChildren: () => import('./pages/pecas/add-edit/pecas-add-edit.module').then(m => m.PecasAddEditPageModule)
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
