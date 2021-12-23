import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class SearchService {
    private searchSubject = new Subject<any>();

    publishSomeData(data: any) {
        this.searchSubject.next(data);
    }

    getObservable(): Subject<any> {
        return this.searchSubject;
    }
}