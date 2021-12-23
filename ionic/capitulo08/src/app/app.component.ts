import { Component } from '@angular/core';
import { Platform } from '@ionic/angular';
import { Storage } from '@ionic/storage-angular';
import { DatabaseService } from './services/database.service';
import { databaseName } from './services/database.statements';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {
  private initPlugin: boolean;

  pages = [
    {
      title: 'Tipos de serviços',
      url: '/tiposdeservicos',
      icon: '/assets/imgs/icon_tiposservicos.png'
    },
    {
      title: 'Peças',
      url: '/pecas',
      icon: '/assets/imgs/tab_pecas.png'
    },
    {
      title: 'Atendimentos',
      url: '/ordensdeservico-listagem',
      icon: '/assets/imgs/icon_atendimentos.png'
    },
    {
      title: 'Clientes',
      url: '/clientes-listagem',
      icon: '/assets/imgs/icon_clientes.png'
    }

  ];

  constructor(
    private storage: Storage,
  ) {

  }

  async ngOnInit() {
  }

  async initializeApp() {
    await this.storage.create();
  }
}
