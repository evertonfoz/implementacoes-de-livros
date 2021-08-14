import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', loadChildren: './login/login.module#LoginPageModule' },
  { path: 'home', loadChildren: './home/home.module#HomePageModule' },
  { path: 'registrar', loadChildren: './usuarios/registrar/registrar.module#RegistrarPageModule' },
  // { path: '', loadChildren: './home/home.module#HomePageModule' }
//  { path: 'registrar', loadChildren: './usuarios/registrar/registrar.module#RegistrarPageModule' }
 // { path: '', loadChildren: './home/home.module#HomePageModule' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
