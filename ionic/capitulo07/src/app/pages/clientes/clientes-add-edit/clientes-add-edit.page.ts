import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Cliente } from 'src/app/models/cliente.model';
import { LoadingController, MenuController } from '@ionic/angular';
import { AlertService } from 'src/app/services/alert.service';
import { ClientesService } from 'src/app/services/clientes.service';
import { ToastService } from 'src/app/services/toast.service';
import { Router } from '@angular/router';
import { getApp } from 'firebase/app';
import { getFirestore } from '@firebase/firestore';
import { collection, onSnapshot, query } from 'firebase/firestore';
import { Firestore } from '@angular/fire/firestore';
import { getDatabase, onValue, ref } from 'firebase/database';

@Component({
  templateUrl: './clientes-add-edit.page.html'
})
export class ClientesAddEditPage implements OnInit {
  private cliente: Cliente;
  public modoDeEdicao = false;
  public clientesForm: FormGroup;

  public search: string;



  constructor(
    private formBuilder: FormBuilder,
    private loadingCtrl: LoadingController,
    private alertService: AlertService,
    private clientesService: ClientesService,
    private toastService: ToastService,
    private router: Router, private _fireStore: Firestore,
  ) {
  }

  ngOnInit() {

    // let clientes: Cliente[] = [];
    // const db = getDatabase(this._fireStore.app);
    // const dbRef = ref(db, 'clientes/');

    // onValue(dbRef, (snapshot) => {
    //   snapshot.forEach((childSnapshot) => {
    //     console.log(3);
    //     let cliente = {
    //       clienteid: childSnapshot.key,
    //       nome: childSnapshot.val().nome,
    //       email: childSnapshot.val().email,
    //       telefone: childSnapshot.val().telefone,
    //       renda: childSnapshot.val().renda,
    //       nascimento: childSnapshot.val().nascimento,
    //     }
    //     console.log('cliente: ' + cliente);
    //     clientes.push(cliente);
    //   });
    // }, {
    //   onlyOnce: true
    // });
    // console.log('CLIENTES: ' + clientes);
  }

  async submit() {
    if (this.clientesForm.invalid || this.clientesForm.pending) {
      await this.alertService.presentAlert('Falha', 'Gravação não foi executada',
        'Verifique os dados informados para o atendimento', ['Ok']);
      return;
    }

    // Estamos utilizando pela primeira vez este controle
    const loading = await this.loadingCtrl.create();
    await loading.present();

    if (this.cliente.clienteid === '') {
      await this.clientesService.create(this.clientesForm.value)
        .then(
          () => {
            loading.dismiss().then(() => {
              this.toastService.presentToast('Gravação bem sucedida', 3000, 'top');
              this.router.navigateByUrl('/clientes-add-edit)');
            });
          },
          error => {
            console.error(error);
          }
        );
      // await this.clientesService.getAll
    }
  }
}