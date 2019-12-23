import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { ClientesSearchPage } from './clientes-search.page';

@NgModule({
    imports: [
      CommonModule,
      FormsModule,
      IonicModule
    ],
    declarations: [
        ClientesSearchPage
    ]
})

export class ClientesSearchPageModule {}
