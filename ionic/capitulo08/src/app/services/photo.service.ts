import { Camera, CameraResultType, CameraSource, GalleryPhotos, Photo } from '@capacitor/camera';
import { Filesystem, Directory } from '@capacitor/filesystem';
import { Storage } from '@capacitor/storage';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {
  public webPathToPhoto: String = '';

  constructor() { }

  async obterFoto() {
    const capturedPhoto = await Camera.getPhoto({
      resultType: CameraResultType.Base64,
      source: CameraSource.Camera,
      saveToGallery: true,
      quality: 100,
    });

    this._savePicture(capturedPhoto.base64String);
  }

  async escolherFoto() {
    const pickedPhoto: GalleryPhotos = await Camera.pickImages({
      quality: 100, limit: 1
    });

    this.webPathToPhoto = pickedPhoto.photos[0].webPath;
    // console.log('pickedPhoto: ' + pickedPhoto.photos[0].webPath);
  }

  private _criarNomeArquivoImagem() {
    const d = new Date(),
      t = d.getTime(),
      novoNomeArquivo = t + '.jpg';
    return novoNomeArquivo;
  }

  private async _savePicture(base64Data: string) {
    const fileName = this._criarNomeArquivoImagem();
    const savedFile = await Filesystem.writeFile({
      path: fileName,
      data: base64Data,
      directory: Directory.Data
    });


    // console.log('filename: ' + fileName + ', savedFile.uri: ' + savedFile.uri);
    return savedFile.uri;

  }

}
