import { Injectable } from '@angular/core';
import { FirebaseApp } from '@angular/fire/app';
import { initializeApp } from '@firebase/app';
import { getAuth, signInWithEmailAndPassword } from "@firebase/auth";
import { environment } from 'src/credentials';

@Injectable({
  providedIn: 'root'
})
export class AutenticacaoService {

  constructor() { }

  async login(value) {
    initializeApp(environment.firebaseConfig);
    const auth = getAuth();
    try {
      return await signInWithEmailAndPassword(auth, value.email, value.password);
    } catch (error) {
      throw new Error(error.message);
    }
  }

  async logout() {
    try {
      await getAuth().signOut();
    } catch (error) {
      throw new Error(error.message);
    }
  }
}
