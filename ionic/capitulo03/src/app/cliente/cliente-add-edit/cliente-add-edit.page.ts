import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-cliente-add-edit',
  templateUrl: './cliente-add-edit.page.html',
  styleUrls: ['./cliente-add-edit.page.scss'],
})
export class ClienteAddEditPage implements OnInit {

  private nome: string;

  constructor() { }

  ngOnInit() {
  }

  submit() {
    console.log(this.nome);
    this.nome = 'Atronomogildo';
  }

}
