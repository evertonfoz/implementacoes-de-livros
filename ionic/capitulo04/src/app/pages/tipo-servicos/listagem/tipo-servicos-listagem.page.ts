import { Component, OnInit } from '@angular/core';

@Component({
    templateUrl: './tipo-servicos-listagem.page.html'
})
export class TipoServicosListagemPage implements OnInit {

    public tiposServicos = [
        { id: 1, nome: 'Alinhamento', valor: 12.34 },
        { id: 2, nome: 'Balanceamento', valor: 56.78 },
        { id: 3, nome: 'Revisão freios', valor: 90.12 },
        { id: 4, nome: 'Suspensão', valor: 34.56 }
    ];

    ngOnInit(): void {
    }
}