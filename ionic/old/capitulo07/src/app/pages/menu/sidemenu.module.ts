import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';

import { SideMenuPage } from './sidemenu.page';

import { SideMenuRoutingModule } from './sidemenu-routing.module';
import { ClientesAddEditPageModule } from '../clientes/add-edit/clientes-add-edit.module';
import { ClientesListagemPageModule } from '../clientes/listagem/clientes-listagem.module';
import { OrdensDeServicoListagemPageModule } from '../ordensdeservico/listagem/ordensdeservico-listagem.module';
import { ClientesSearchPageModule } from '../clientes/search/clientes-search.module';
import { OrdensDeServicoAddEditPageModule } from '../ordensdeservico/add-edit/ordensdeservico-add-edit.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    SideMenuRoutingModule,
    ClientesAddEditPageModule,
    ClientesListagemPageModule,
    OrdensDeServicoListagemPageModule,
    ClientesSearchPageModule,
    OrdensDeServicoAddEditPageModule
  ],
  declarations: [SideMenuPage]
})
export class SideMenuPageModule {}
