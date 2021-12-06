import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./login/login.module').then(m => m.LoginPageModule)
  },
  {
    path: 'home',
    loadChildren: () => import('./home/home.module').then(m => m.HomePageModule)
  },
  {
    path: 'pecas',
    loadChildren: () => import('./pecas/pecas.module').then(m => m.PecasPageModule)
  },
  {
    path: 'clientes-listagem',
    loadChildren: () => import('./clientes/clientes-listagem/clientes-listagem.module').then(m => m.ClientesListagemPageModule)
  },
  {
    path: 'registrar',
    loadChildren: () => import('./usuarios/registrar/registrar.module').then( m => m.RegistrarPageModule)
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
