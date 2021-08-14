import { Injectable } from '@angular/core';
import { Cliente } from '../models/cliente.model';
import { AngularFirestore, AngularFirestoreCollection } from '@angular/fire/firestore';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { File } from '@ionic-native/File/ngx';
import * as firebase from 'firebase';

@Injectable({
    providedIn: 'root'
})
export class ClientesService {
  constructor(
    private firestore: AngularFirestore,
    private file: File
  ) { }

  async update(cliente: Cliente): Promise<void> {
    try {
      if (cliente.uriFotoCapturada) {
        if (cliente.nomeFotoEnviada) {
          this.deleteImagem(cliente.nomeFotoEnviada);
        }
        cliente.nomeFotoEnviada = this.criarNomeArquivoImagem();
        const blobDaImagem = await this.criarBlobDeArquivoDeImagem(cliente.uriFotoCapturada);
        cliente.uriFotoParaExibir = await this.upload(blobDaImagem, cliente.nomeFotoEnviada);
      }
      cliente.nascimento = new Date(cliente.nascimento);
      cliente.uriFotoCapturada = '';

      await this.firestore.doc(`clientes/${cliente.clienteid}`).set(cliente);
    } catch (e) {
      console.error(e);
    }
  }

/*   async update(cliente: Cliente): Promise<void> {
    try {
      cliente.nascimento = new Date(cliente.nascimento);
      await this.firestore.doc(`clientes/${cliente.clienteid}`).set(cliente);
      cliente.foto = cliente.foto.replace('http://localhost/', 'file://');
      const blobDaImagem = await this.criarBlobDeArquivoDeImagem(cliente.foto);
      await this.upload(blobDaImagem, this.criarNomeArquivoImagem());
    } catch (e) {
      console.error(e);
    }
  } */

  criarNomeArquivoImagem() {
    const d = new Date(),
        t = d.getTime(),
        novoNomeArquivo = t + '.jpg';
    return novoNomeArquivo;
  }

  public getAll(): AngularFirestoreCollection<Cliente> {
    return this.firestore.collection('clientes', ref => ref.orderBy('nome', 'asc'));
  }

  async getById(clienteID: string): Promise<Cliente> {
    try {
      const cliente = await this.firestore.collection('clientes').doc(clienteID).ref.get();
      if (cliente.exists) {
          const dadosCliente = cliente.data();
          const nascimento = dadosCliente.nascimento.toDate();
          return  {
            clienteid: dadosCliente.clienteid, nome: dadosCliente.nome, email: dadosCliente.email,
            telefone: dadosCliente.telefone, renda: dadosCliente.renda,
            nascimento: new Date(nascimento), uriFotoCapturada: dadosCliente. uriFotoCapturada,
            nomeFotoEnviada: dadosCliente.nomeFotoEnviada, uriFotoParaExibir: dadosCliente.uriFotoParaExibir
          };
      }
    } catch (e) {
      console.log(e);
    }
  }

  async removeById(clienteId: string, fotoEnviada: string): Promise<void> {
    await this.deleteImagem(fotoEnviada);
    return this.firestore.doc(`clientes/${clienteId}`).delete();
  }

  public getByNome(nome: string): Observable<Cliente[]> {
    const clientes: Observable<Cliente[]> = this.getAll().valueChanges();

    if (!nome) {
        return clientes;
    }

    return clientes.pipe(
        map(result =>
            result.filter(
                cliente => cliente.nome.toLowerCase().startsWith(nome.toLowerCase()))
        )
    );
  }

  criarBlobDeArquivoDeImagem(caminhoArquivo) {
    return new Promise((resolve, reject) => {
      this.file
        .resolveLocalFilesystemUrl(caminhoArquivo)
        .then(dadosDoArquivo => {
            const { name, nativeURL } = dadosDoArquivo;
            const path = nativeURL.substring(0, nativeURL.lastIndexOf('/'));
            return this.file.readAsArrayBuffer(path, name);
        })
        .then(buffer => {
            const blobDaImagem = new Blob([buffer], {
                type: 'image/jpeg'
            });
            resolve(blobDaImagem);
        })
        .catch(e => reject(e));
    });
  }

  async upload(imagem, nomeImagem): Promise<string> {
    if (imagem) {
        try {
            nomeImagem = 'fotosClientes/' + nomeImagem;
            const resultadoUpLoad = await firebase.storage().ref().child(nomeImagem).put(imagem);
            const urlUpLoad = await resultadoUpLoad.ref.getDownloadURL();
            return urlUpLoad;
          } catch (e) {
            console.log(e);
        }
    }
  }

  async deleteImagem(nomeImagem) {
    try {
      nomeImagem = 'fotosClientes/' + nomeImagem;
      await firebase.storage().ref().child(nomeImagem).delete();
    } catch (e) {
        console.log(e);
    }
  }
}
