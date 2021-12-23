import { Injectable } from '@angular/core';
import { Camera, CameraResultType, CameraSource, GalleryPhotos, Photo } from '@capacitor/camera';
import { Directory, Filesystem } from '@capacitor/filesystem';

@Injectable({
  providedIn: 'root'
})
export class FotosService {
  public caminhoParaFoto: string = '';

  constructor() { }

  async obterFoto() {
    const capturedPhoto = await Camera.getPhoto({
      resultType: CameraResultType.Uri,
      source: CameraSource.Camera,
      saveToGallery: true,
      quality: 100,
    });

    await this._gravarFoto(capturedPhoto.webPath);
  }

  async escolherFoto() {
    const pickedPhoto: GalleryPhotos = await Camera.pickImages({
      quality: 100,
      limit: 1
    });

    await this._gravarFoto(pickedPhoto.photos[0].webPath);
  }

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

    this.caminhoParaFoto = arquivoGravado.uri;
  }

  private async _lerComoBase64(caminho: string) {
    const response = await fetch(caminho);
    const blob = await response.blob();

    return await this._converterBlobParaBase64(blob) as string;
  }

  _converterBlobParaBase64 = (blob: Blob) => new Promise((resolve, reject) => {
    const reader = new FileReader;
    reader.onerror = reject;
    reader.onload = () => {
      resolve(reader.result);
    };
    reader.readAsDataURL(blob);
  });

  async lerComoBlob(caminho: string) {
    const response = await fetch(caminho);
    return await response.blob();
  }
}
