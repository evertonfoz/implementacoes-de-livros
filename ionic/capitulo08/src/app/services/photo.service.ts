import { Camera, CameraResultType, CameraSource, GalleryPhotos, Photo } from '@capacitor/camera';
import { Filesystem, Directory } from '@capacitor/filesystem';
import { Storage } from '@capacitor/storage';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {
  public webPathToPhoto: string = '';

  constructor() { }

  async obterFoto() {
    const capturedPhoto = await Camera.getPhoto({
      resultType: CameraResultType.Uri,
      source: CameraSource.Camera,
      saveToGallery: true,
      quality: 100,
    });

    this.webPathToPhoto = await this._savePicture(capturedPhoto.webPath);
  }

  async escolherFoto() {
    const pickedPhoto: GalleryPhotos = await Camera.pickImages({
      quality: 100, limit: 1
    });

    this.webPathToPhoto = await this._savePicture(pickedPhoto.photos[0].webPath);
    // console.log('pickedPhoto: ' + pickedPhoto.photos[0].webPath);
  }

  private async _readAsBase64(webPath: string) {
    console.log('readAsBase64: ' + webPath);
    const response = await fetch(webPath);
    console.log('response: ' + response);
    const blob = await response.blob();
    console.log('blob: ' + blob);

    return await this._convertBlobToBase64(blob) as string;
  }

  _convertBlobToBase64 = (blob: Blob) => new Promise((resolve, reject) => {
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

  private async _savePicture(webPath: string) {
    const fileName = this._criarNomeArquivoImagem();
    const base64Data = await this._readAsBase64(webPath);
    const savedFile = await Filesystem.writeFile({
      path: fileName,
      data: base64Data,
      directory: Directory.Data
    });


    console.log('savedFile.uri: ' + savedFile.uri);
    return savedFile.uri;

  }

}
