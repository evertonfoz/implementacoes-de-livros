import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', loadChildren: './pages/ordensdeservico/listagem/ordensdeservico-listagem.module#OrdensDeServicoListagemPageModule' },
  { path: 'pecas', loadChildren: './pages/pecas/listagem/pecas-listagem.module#PecasListagemPageModule' },
  { path: 'add-edit/:id', loadChildren: './pages/pecas/add-edit/pecas-add-edit.module#PecasAddEditPageModule' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
