import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Cliente } from '../models/cliente.model';

@Injectable({
    providedIn: 'root'
})
export class SearchService {

    private searchSubject = new Subject<any>();

    publishSomeData(data: any) {
        this.searchSubject.next(data);
    }

    getObservable(): Subject<any> {
        if (this.searchSubject.closed) {
            this.searchSubject = new Subject<any>();
        }
        return this.searchSubject;
    }
}