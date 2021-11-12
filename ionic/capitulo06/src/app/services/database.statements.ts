export const databaseName: string = 'oficina16';

export const createOrdensDeServicoTable: string = `
CREATE TABLE IF NOT EXISTS ordensdeservico (
    ordemdeservicoid TEXT primary key NOT NULL, 
    clienteid TEXT NOT NULL,
    veiculo TEXT NOT NULL,
    dataehoraentrada DATETIME NOT NULL,
    dataehoratermino DATETIME,
    dataehoraentrega DATETIME,
    FOREIGN KEY (clienteid) REFERENCES clientes (clienteid) ON DELETE CASCADE ON UPDATE NO ACTION
);

CREATE INDEX IF NOT EXISTS ordensdeservico_index_ordemdeservicoid ON ordensdeservico (ordemdeservicoid);
PRAGMA user_version = 1;
`;

export const createClientesTable: string = `
CREATE TABLE IF NOT EXISTS clientes (
    clienteid TEXT primary key NOT NULL, 
    nome TEXT NOT NULL,
    email TEXT NOT NULL,
    telefone TEXT NOT NULL,
    renda REAL NOT NULL
);

CREATE INDEX IF NOT EXISTS clientes_index_clienteid ON clientes (clienteid);
PRAGMA user_version = 1;
`;
