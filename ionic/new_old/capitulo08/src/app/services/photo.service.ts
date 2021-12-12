import { Camera, CameraResultType, CameraSource, GalleryPhotos, Photo } from '@capacitor/camera';
import { Filesystem, Directory } from '@capacitor/filesystem';
import { Storage } from '@capacitor/storage';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {
  // public nomeArquivoFoto: string = '';
  public caminhoParaFoto: string = '';

  constructor() { }

  async obterFoto() {
    const capturedPhoto = await Camera.getPhoto({
      resultType: CameraResultType.Uri,
      source: CameraSource.Prompt,
      saveToGallery: true,
      quality: 100,
    });

    await this._gravarFoto(capturedPhoto.webPath);
  }

  async escolherFoto() {
    const pickedPhoto: GalleryPhotos = await Camera.pickImages({
      quality: 100, limit: 1
    });

    await this._gravarFoto(pickedPhoto.photos[0].webPath);
  }

  async lerComoBlob(caminho: string) {
    const response = await fetch(caminho);
    return await response.blob();
  }

  private async _lerComoBase64(caminho: string) {
    const response = await fetch(caminho);
    const blob = await response.blob();

    return await this._converterBlobParaBase64(blob) as string;
  }

  private _converterBlobParaBase64 = (blob: Blob) => new Promise((resolve, reject) => {
    const reader = new FileReader;
    reader.onerror = reject;
    reader.onload = () => {
      resolve(reader.result);
    };
    reader.readAsDataURL(blob);
  });

  private _criarNomeArquivoImagem() {
    const d = new Date(),
      t = d.getTime(),
      novoNomeArquivo = t + '.jpg';
    return novoNomeArquivo;
  }

  private async _gravarFoto(caminho: string) {
    const nomeDoArquivo = this._criarNomeArquivoImagem();
    const dadosEmBase64 = await this._lerComoBase64(caminho);

    const arquivoGravado = await Filesystem.writeFile({
      path: nomeDoArquivo,
      data: dadosEmBase64,
      directory: Directory.Data
    });

    // this.nomeArquivoFoto = nomeDoArquivo;
    this.caminhoParaFoto = arquivoGravado.uri;
  }

}
