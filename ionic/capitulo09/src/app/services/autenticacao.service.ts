import { Injectable } from '@angular/core';
import { getAuth, signInWithEmailAndPassword, createUserWithEmailAndPassword } from "@firebase/auth";
import { initializeApp } from '@firebase/app';
import { environment } from '../credentials';

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

  public isUserAuthenticated(): boolean {
    return ((getAuth().currentUser !== null));
  }

  async registrar(value) {
    initializeApp(environment.firebaseConfig);
    const auth = getAuth();

    try {
      return await createUserWithEmailAndPassword(auth, value.email, value.password);
    } catch (error) {
      throw new Error(error.message);
    }
  }
}
