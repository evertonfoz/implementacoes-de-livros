import { Component, OnInit } from '@angular/core';
import { Router, RouterEvent } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './sidemenu.page.html',
  styleUrls: ['./sidemenu.page.scss'],
})
export class SideMenuPage implements OnInit {

    selectedPath = '';

    pages = [
        {
          title: 'Tipos de serviços',
          url: '/menu/(menucontent:tiposservicos)',
          src: 'assets/imgs/icon_tiposservicos.png'
        },
        {
          title: 'Peças',
          url: '/menu/(menucontent:pecas)',
          src: 'assets/imgs/tab_pecas.png'
        },
        {
          title: 'Clientes',
          url: '/menu/(menucontent:clientes)',
          src: 'assets/imgs/icon_clientes.png'
        },
        {
          title: 'Atendimentos',
          url: '/menu/(menucontent:atendimentos)',
          src: 'assets/imgs/icon_atendimentos.png'
        }
    ];

    constructor(private router: Router) {
        this.router.events.subscribe((event: RouterEvent) => {
          this.selectedPath = event.url;
        });
    }

    ngOnInit() {
    }

}
