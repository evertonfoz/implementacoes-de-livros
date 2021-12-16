export const createSchema: string = `
CREATE TABLE IF NOT EXISTS ordensdeservico (
    ordemdeservicoid TEXT primary key NOT NULL, 
    clienteid TEXT NOT NULL,
    veiculo TEXT NOT NULL,
    dataehoraentrada DATETIME NOT NULL,
    dataehoratermino DATETIME, 
    dataehoraentrega DATETIME
);

CREATE INDEX IF NOT EXISTS ordensdeservico_index_ordemdeservicoid ON ordensdeservico (ordemdeservicoid);
PRAGMA user_version = 1;
`;

export const databaseName: string = 'oficina09';