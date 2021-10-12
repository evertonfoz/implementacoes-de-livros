import { Injectable } from '@angular/core';
@Injectable()

export class DetailService {
    private _existingConn: boolean;
    private _exportJson: boolean;

    constructor() {
    }
    setExistingConnection(value: boolean) {
        this._existingConn = value;
    }
    getExistingConnection(): boolean {
        return this._existingConn;
    }
    setExportJson(value: boolean) {
        this._exportJson = value;
    }
    getExportJson(): boolean {
        return this._exportJson;
    }
}
