import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PecasAddEditPage } from './pecas-add-edit.page';

const routes: Routes = [
    {
        path: '',
        component: PecasAddEditPage
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class PecasAddEditPageRoutingModule { }