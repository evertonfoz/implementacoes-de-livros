import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { initializeApp, provideFirebaseApp } from '@angular/fire/app';
import { environment } from 'src/credentials';
import { enableIndexedDbPersistence, getFirestore, provideFirestore } from '@angular/fire/firestore';

// initializeApp(environment.firebaseConfig);

@NgModule({
  declarations: [AppComponent],
  entryComponents: [],
  imports: [
    provideFirebaseApp(() => {
      return initializeApp(environment.firebaseConfig);
    }),
    provideFirestore(() => {
      if (environment.useEmulators) {
        const firestore = getFirestore();
        enableIndexedDbPersistence(firestore);

        return firestore;
      } else {
        getFirestore();
      }
    }),
    BrowserModule, ReactiveFormsModule, IonicModule.forRoot(), AppRoutingModule],
  providers: [{ provide: RouteReuseStrategy, useClass: IonicRouteStrategy }],
  bootstrap: [AppComponent],
})
export class AppModule { }
