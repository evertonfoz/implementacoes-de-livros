import { Injectable } from '@angular/core';

import { child, get, getDatabase, onValue, push, ref, remove, update } from 'firebase/database';


@Injectable({
    providedIn: 'root'
})
export class FirestoreService {
    constructor() { }

    // createID(): string {
    //     const databaseReference = getDatabase();
    //     ref(databaseReference, 'clientes/').ref.key.

    //     // const firebaseApp = getApp();
    //     // const db = getFirestore(firebaseApp);

    //     // return this.firestore.app.;
    // }
}