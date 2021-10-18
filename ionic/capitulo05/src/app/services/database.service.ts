import { fn } from '@angular/compiler/src/output/output_ast';
import { Injectable, SystemJsNgModuleLoader } from '@angular/core';
import { CapacitorSQLite, capSQLiteResult, SQLiteConnection, SQLiteDBConnection } from '@capacitor-community/sqlite';
import { Capacitor } from '@capacitor/core';
import { Guid } from 'guid-typescript';
// import { ConsoleReporter } from 'jasmine';
import { createSchema } from './database.statements';

@Injectable({
    providedIn: 'root'
})
export class DatabaseService {
    sqliteConnection: SQLiteConnection;
    platform: string;
    native: boolean = false;
    sqlitePlugin: any;

    async initializePlugin(): Promise<boolean> {
        return new Promise(resolve => {
            this.platform = Capacitor.getPlatform();
            if (this.platform === 'ios' || this.platform === 'android') this.native = true;
            this.sqlitePlugin = CapacitorSQLite;
            this.sqliteConnection = new SQLiteConnection(this.sqlitePlugin);
            resolve(true);
        });
    }

    async createConnection(database: string, encrypted: boolean,
        mode: string, version: number
    ): Promise<SQLiteDBConnection> {
        if (this.sqliteConnection != null) {
            try {
                const db: SQLiteDBConnection = await this.sqliteConnection.createConnection(
                    database, encrypted, mode, version);
                if (db != null) {
                    await this.createSchema(db);
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

    private async createSchema(db: SQLiteDBConnection): Promise<void> {
        await db.open();
        console.log('Abriu conexão');
        // console.log(`Após abertura da base de dados`)

        let createSchemma: any = await db.execute(createSchema);

        await this.populateDatabase(db);

        // console.log(`Após o fechamento da base de dados`)

        if (createSchemma.changes.changes < 0) {
            console.log('Fechou if conexão');
            await db.close();
            return Promise.reject(new Error("Erro na criação das tabelas"));
        }
        // console.log(`criação das tabelas: ${JSON.stringify(createSchemma)}`);

        await db.close();
        console.log('Fechou conexão');
        return Promise.resolve();
    }

    private async populateDatabase(db: SQLiteDBConnection): Promise<void> {
        let returnQuery = await db.query("select COUNT(ordemdeservicoid) as qtdeOS from ordensdeservico;");
        // console.log(`returnQuery => ${returnQuery}`);
        // console.log(`returnQuery.values.length => ${returnQuery.values.length}`);
        // console.log(`returnQuery.values[0].qtdeOS => ${returnQuery.values[0].qtdeOS}`);

        if (returnQuery.values[0].qtdeOS === 0) {
            let sqlcmd: string =
                "INSERT INTO ordensdeservico (ordemdeservicoid, clienteid, veiculo, dataehoraentrada, dataehoratermino) VALUES (?,?,?,?,?)";
            let values: Array<any> = [Guid.create().toString(), Guid.create().toString(), 'ABC-1235', Date.now(), null];

            let returnInsert = await db.run(sqlcmd, values);
            if (returnInsert.changes < 0) {
                return Promise.reject(new Error("Erro na inserção da ordem de serviço"));
            }
        }

        return Promise.resolve();
    }

    // async isConnection(database: string): Promise<capSQLiteResult> {
    //     if (this.sqliteConnection != null) {
    //         try {
    //             return Promise.resolve(await this.sqliteConnection.isConnection(database));
    //         } catch (err) {
    //             return Promise.reject(new Error(err));
    //         }
    //     } else {
    //         return Promise.reject(new Error(`Sem conexão aberta`));
    //     }
    // }

    async retrieveConnection(database: string):
        Promise<SQLiteDBConnection> {
        if (this.sqliteConnection != null) {
            try {
                return Promise.resolve(await this.sqliteConnection.retrieveConnection(database));
            } catch (err) {
                return Promise.reject(new Error(err));
            }
        } else {
            return Promise.reject(new Error(`Sem conexão para ${database}`));
        }
    }


    // async isDatabase(database: string): Promise<capSQLiteResult> {
    //     if (this.sqliteConnection != null) {
    //         try {
    //             return Promise.resolve(await this.sqliteConnection.isDatabase(database));
    //         } catch (err) {
    //             return Promise.reject(new Error(err));
    //         }
    //     } else {
    //         return Promise.reject(new Error(`A base de dados ${ database } não existe`));
    //     }
    // }

    // async openConnection(database: string): Promise<SQLiteDBConnection> {
    //     if (this.sqliteConnection != null) {
    //         try {
    //             this.sqlitePlugin.open({ database: database });
    //             console.log(`Abriu a conexão com ${ database } `);

    //             // if ((await this.sqlite.isConnection(database)).result) {
    //             const db: SQLiteDBConnection = await this.sqliteConnection.retrieveConnection(
    //                 database);
    //             console.log(`Recuperou a conexão com ${ database } `);
    //             return Promise.resolve(db);
    //             // } else {
    //             //     console.log(`${ database } não é uma conexão`);
    //             // }
    //         } catch (err) {
    //             return Promise.reject(new Error(err));
    //         }
    //     } else {
    //         return Promise.reject(new Error(`Nenhuma conexão disponível para ${ database } `));
    //     }
    // }
}