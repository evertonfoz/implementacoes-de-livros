import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { PecasAddEditPageRoutingModule } from './pecas-add-edit-routing.module';
import { PecasAddEditPage } from './pecas-add-edit.page';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        IonicModule,
        ReactiveFormsModule,
        PecasAddEditPageRoutingModule
    ],
    declarations: [
        PecasAddEditPage
    ]
})

export class PecasAddEditPageModule { }