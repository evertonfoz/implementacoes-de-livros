import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ClientesSearchPageRoutingModule } from './clientes-search-routing.module';

import { ClientesSearchPage } from './clientes-search.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ClientesSearchPageRoutingModule
  ],
  declarations: [ClientesSearchPage]
})
export class ClientesSearchPageModule {}
