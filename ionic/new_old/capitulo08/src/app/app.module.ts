import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { FormBuilder } from '@angular/forms';

import { IonicStorageModule } from '@ionic/storage-angular';
import { DatabaseService } from './services/database.service';
import { DetailService } from './services/detail.service';

// import { AngularFireModule } from '@angular/fire/compat'
// import { AngularFireDatabaseModule } from '@angular/fire/compat/database';
import { provideFirebaseApp, initializeApp } from '@angular/fire/app';
import { connectFirestoreEmulator, enableIndexedDbPersistence, getFirestore, initializeFirestore, provideFirestore, } from '@angular/fire/firestore';
import { environment } from './credentials';
// import { AndroidPermissions } from "@ionic-native/android-permissions/ngx";
import { AngularFireStorageModule } from '@angular/fire/compat/storage';


@NgModule({
  declarations: [AppComponent],
  entryComponents: [],
  imports: [
    //           const db = initializeFirestore(this._fireStore.app, { experimentalAutoDetectLongPolling: true });
    // const clientesRef = collection(db, "clientes");
    provideFirebaseApp(() => {
      // let firebase = initializeApp(environment.firebaseConfig);
      return initializeApp(environment.firebaseConfig);
      // initializeFirestore(firebase, {
      //   useFetchStreams: false,
      //   experimentalForceLongPolling: true,
      // } as any);
      // return firebase;
    }),
    // provideFirestore(() => getFirestore()),
    provideFirestore(() => {
      if (environment.useEmulators) {
        const firestore = getFirestore();
        // connectFirestoreEmulator(firestore, 'localhost', 8080);
        enableIndexedDbPersistence(firestore);

        return firestore;
      } else {
        getFirestore();
      }
    }),
    BrowserModule,
    IonicModule.forRoot(),
    AppRoutingModule,

    IonicStorageModule.forRoot(),
  ],
  providers: [
    DatabaseService,
    DetailService,
    FormBuilder,
    // AndroidPermissions,
    { provide: RouteReuseStrategy, useClass: IonicRouteStrategy }],
  bootstrap: [AppComponent],
})
export class AppModule { }
