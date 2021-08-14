import { Component, OnInit, ViewChild } from '@angular/core';
import { AutenticacaoService } from '../services/autenticacao.service';
import { NavController, IonTabs } from '@ionic/angular';

@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.scss'],
})
export class HomePage implements OnInit {

  @ViewChild('tabMenu') tabMenu: IonTabs;

  constructor(
    private autenticacaoService: AutenticacaoService,
    private navCtrl: NavController
  ) {
  }

  ngOnInit() {
  }

  logout() {
    this.autenticacaoService.logout()
    .then(res => {
      console.log(res);
      this.navCtrl.navigateBack('');
    })
    .catch(error => {
      console.log(error);
    });
  }
}
