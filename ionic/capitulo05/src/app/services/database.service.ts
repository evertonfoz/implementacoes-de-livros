import { Injectable } from '@angular/core';
import { CapacitorSQLite, capSQLiteResult, SQLiteConnection, SQLiteDBConnection } from '@capacitor-community/sqlite';
import { Capacitor } from '@capacitor/core';

@Injectable({
    providedIn: 'root'
})
export class DatabaseService {
    sqlite: SQLiteConnection;
    platform: string;
    native: boolean = false;
    sqlitePlugin: any;

    async initializePlugin(): Promise<boolean> {
        return new Promise(resolve => {
            this.platform = Capacitor.getPlatform();
            if (this.platform === 'ios' || this.platform === 'android') this.native = true;
            this.sqlitePlugin = CapacitorSQLite;
            this.sqlite = new SQLiteConnection(this.sqlitePlugin);
            resolve(true);
        });
    }

    async createConnection(database: string, encrypted: boolean,
        mode: string, version: number
    ): Promise<SQLiteDBConnection> {
        if (this.sqlite != null) {
            try {
                const db: SQLiteDBConnection = await this.sqlite.createConnection(
                    database, encrypted, mode, version);
                if (db != null) {
                    return Promise.resolve(db);
                } else {
                    return Promise.reject(new Error(`Erro ao criar a conexão`));
                }
            } catch (err) {
                return Promise.reject(new Error(err));
            }
        } else {
            return Promise.reject(new Error(`Nenhuma conexão disponível para ${database}`));
        }
    }

    async isDatabase(database: string): Promise<capSQLiteResult> {
        if (this.sqlite != null) {
            try {
                return Promise.resolve(await this.sqlite.isDatabase(database));
            } catch (err) {
                return Promise.reject(new Error(err));
            }
        } else {
            return Promise.reject(new Error(`A base de dados ${database} não existe`));
        }
    }

    async openConnection(database: string): Promise<SQLiteDBConnection> {
        if (this.sqlite != null) {
            try {
                this.sqlitePlugin.open({ database: database });
                console.log(`Abriu a conexão com ${database}`);

                if ((await this.sqlite.isConnection(database)).result) {
                    const db: SQLiteDBConnection = await this.sqlite.retrieveConnection(
                        database);
                    console.log(`Recuperou a conexão com ${database}`);
                    return Promise.resolve(db);
                } else {
                    console.log(`${database} não é uma conexão`);
                }
            } catch (err) {
                return Promise.reject(new Error(err));
            }
        } else {
            return Promise.reject(new Error(`Nenhuma conexão disponível para ${database}`));
        }
    }

    // async isConnection(database: string): Promise<capSQLiteResult> {
    //     if (this.sqlite != null) {
    //         try {
    //             return Promise.resolve(await this.sqlite.isConnection(database));
    //         } catch (err) {
    //             return Promise.reject(new Error(err));
    //         }
    //     } else {
    //         return Promise.reject(new Error(`Nenhuma conexão disponível`));
    //     }
    // }

    // async retrieveConnection(database: string):
    //     Promise<SQLiteDBConnection> {
    //     if (this.sqlite != null) {
    //         try {
    //             return Promise.resolve(await this.sqlite.retrieveConnection(database));
    //         } catch (err) {
    //             return Promise.reject(new Error(err));
    //         }
    //     } else {
    //         return Promise.reject(new Error(`no connection open for ${database}`));
    //     }
    // }
}