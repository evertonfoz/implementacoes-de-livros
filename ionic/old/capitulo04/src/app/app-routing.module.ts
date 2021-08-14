import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', loadChildren: './pages/tipo-servicos/listagem/tipo-servicos-listagem.module#TipoServicosListagemPageModule' },
  { path: 'add-edit/:id', loadChildren: './pages/tipo-servicos/add-edit/tipo-servicos-add-edit.module#TipoServicosAddEditPageModule' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
