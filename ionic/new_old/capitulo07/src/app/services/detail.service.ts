import { Injectable } from '@angular/core';
@Injectable()

export class DetailService {
    private _existingConn: boolean;
    setExistingConnection(value: boolean) {
        this._existingConn = value;
    }
    getExistingConnection(): boolean {
        return this._existingConn;
    }
}
