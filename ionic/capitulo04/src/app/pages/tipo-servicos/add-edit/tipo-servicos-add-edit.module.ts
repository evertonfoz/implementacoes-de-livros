import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { TipoServicosAddEditPage } from './tipo-servicos-add-edit.page';
import { TipoServicosAddEditPageRoutingModule } from './tipo-servicos-add-edit-routing.module';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        IonicModule,
        ReactiveFormsModule,
        TipoServicosAddEditPageRoutingModule
    ],
    declarations: [
        TipoServicosAddEditPage
    ]
})

export class TipoServicosAddEditPageModule { }