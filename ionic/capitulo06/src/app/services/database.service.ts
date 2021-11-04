import { fn } from '@angular/compiler/src/output/output_ast';
import { Injectable, SystemJsNgModuleLoader } from '@angular/core';
import { CapacitorSQLite, capEchoResult, capSQLiteResult, SQLiteConnection, SQLiteDBConnection } from '@capacitor-community/sqlite';
import { Capacitor } from '@capacitor/core';
import { Guid } from 'guid-typescript';
// import { ConsoleReporter } from 'jasmine';
import { createClientesTable, createOrdensDeServicoTable } from './database.statements';

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
            let db: SQLiteDBConnection;
            try {
                db = await this.sqliteConnection.createConnection(
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

        let createClienteSchemma: any = await db.execute(createClientesTable);
        console.log(`createClienteSchemma: ${JSON.stringify(createClienteSchemma)}`)

        let createOSSchemma: any = await db.execute(createOrdensDeServicoTable);
        console.log(`createOSSchemma: ${JSON.stringify(createOSSchemma)}`)

        await this.populateDatabase(db);

        // if (createOSSchemma.changes.changes < 0 || createClienteSchemma.changes.changes < 0) {
        //     await db.close();
        //     return Promise.reject(new Error("Erro na criação das tabelas"));
        // }

        await db.close();
        return Promise.resolve();
    }

    private async populateDatabase(db: SQLiteDBConnection): Promise<void> {
        const clienteID = Guid.create().toString();

        await this.populateClientes(db, clienteID);
        await this.populateOrdensDeServico(db, clienteID);

        return Promise.resolve();
    }

    private async populateClientes(db: SQLiteDBConnection, clienteID: String): Promise<void> {
        // db.open();
        console.log('clienteID ' + clienteID);

        let returnQuery = await db.query("select COUNT(clienteid) as qtdeClientes from clientes;");

        // if (returnQuery.values[0].qtdeClientes > 0) {
        //     await db.execute('DELETE FROM ordensdeservico;')
        //     await db.execute('DELETE FROM clientes;')
        // }
        console.log('Count Clientes ' + returnQuery.values[0].qtdeClientes);

        if (returnQuery.values[0].qtdeClientes === 0) {
            let sqlcmd: string =
                "INSERT INTO clientes (clienteid, nome, email, telefone, renda) VALUES (?,?,?,?,?)";
            let values: Array<any> = [clienteID, 'Ambrózio', 'ambrozio@casadocodigo.com.br', '91234-5668', 123];

            let returnInsert = await db.run(sqlcmd, values,);
            if (returnInsert.changes < 0) {
                // db.close();
                return Promise.reject(new Error("Erro na inserção da clientes"));
            }
        }

        // db.close();
        return Promise.resolve();
    }

    private async populateOrdensDeServico(db: SQLiteDBConnection, clienteID: String): Promise<void> {
        console.log('clienteID ' + clienteID);

        let returnQuery = await db.query("select COUNT(ordemdeservicoid) as qtdeOS from ordensdeservico;");

        console.log('Count OS ' + returnQuery.values[0].qtdeOS);

        if (returnQuery.values[0].qtdeOS === 0) {
            let sqlcmd: string =
                "INSERT INTO ordensdeservico (ordemdeservicoid, clienteid, veiculo, dataehoraentrada, dataehoratermino) VALUES (?,?,?,?,?)";
            let values: Array<any> = [Guid.create().toString(), clienteID, 'ABC-1235', Date.now(), null];

            let returnInsert = await db.run(sqlcmd, values);
            if (returnInsert.changes < 0) {
                return Promise.reject(new Error("Erro na inserção da ordem de serviço"));
            }
        }

        return Promise.resolve();
    }

    async isConnection(database: string): Promise<capSQLiteResult> {
        if (this.sqliteConnection != null) {
            try {
                return Promise.resolve(await this.sqliteConnection.isConnection(database));
            } catch (err) {
                return Promise.reject(new Error(err));
            }
        } else {
            return Promise.reject(new Error(`Sem conexão aberta`));
        }
    }

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


    async isDatabase(database: string): Promise<capSQLiteResult> {
        if (this.sqliteConnection != null) {
            try {
                return Promise.resolve(await this.sqliteConnection.isDatabase(database));
            } catch (err) {
                return Promise.reject(new Error(err));
            }
        } else {
            return Promise.reject(new Error(`A base de dados ${database} não existe`));
        }
    }

    async echo(value: string): Promise<capEchoResult> {
        if (this.sqliteConnection != null) {
            try {
                const ret = await this.sqliteConnection.echo(value);
                return Promise.resolve(ret);
            } catch (err) {
                return Promise.reject(new Error(err));
            }
        } else {
            return Promise.reject(new Error("no connection open"));
        }
    }

    async retrieveAllConnections():
        Promise<Map<string, SQLiteDBConnection>> {
        if (this.sqliteConnection != null) {
            try {
                const myConns = await this.sqliteConnection.retrieveAllConnections();
                console.log('myConns: ' + myConns.size);
                let keys = [...myConns.keys()];
                keys.forEach((value) => {
                    console.log("Connection: " + value);
                });

                return Promise.resolve(myConns);
            } catch (err) {
                return Promise.reject(new Error(err));
            }
        } else {
            return Promise.reject(new Error(`no connection open`));
        }
    }
    // async openConnection(database: string): Promise<SQLiteDBConnection> {
    async openConnection(database: string): Promise<void> {
        if (this.sqliteConnection != null) {
            try {
                await this.sqlitePlugin.open({ database: database });
                console.log(`Abriu a conexão com ${database}`);

                await this.retrieveAllConnections();

                // if ((await this.sqliteConnection.isConnection(database)).result) {
                //     // if ((await this.sqlitePlugin.isConnection(database)).result) {
                //     // const db: SQLiteDBConnection = await this.sqliteConnection.retrieveConnection(
                //     //     database);
                //     console.log(`É uma conexão com ${database} `);
                //     //     return Promise.resolve();
                // } else {
                //     console.log(`${database} não é uma conexão`);
                // }
            } catch (err) {
                return Promise.reject(new Error(err));
            }
        } else {
            return Promise.reject(new Error(`Nenhuma conexão disponível para ${database} `));
        }
    }

    async deleteDatabase(db: SQLiteDBConnection): Promise<void> {
        try {
            let ret: any = await db.isExists();
            if (ret.result) {
                const dbName = db.getConnectionDBName();
                await db.delete();
                return Promise.resolve();
            } else {
                return Promise.resolve();
            }
        } catch (err) {
            return Promise.reject(err);
        }
    }

    async closeAllConnections(): Promise<void> {
        if (this.sqliteConnection != null) {
            try {
                return Promise.resolve(await this.sqliteConnection.closeAllConnections());
            } catch (err) {
                return Promise.reject(new Error(err));
            }
        } else {
            return Promise.reject(new Error(`no connection open`));
        }
    }
}