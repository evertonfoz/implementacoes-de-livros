export const createSchema: string = `
CREATE TABLE IF NOT EXISTS ordensdeservico (
    ordemdeservicoid TEXT primary key NOT NULL, 
    clienteid TEXT NOT NULL,
    veiculo TEXT NOT NULL,
    dataehoraentrada DATETIME NOT NULL,
    dataehoratermino DATETIME,
    dataehoraentrega DATETIME
);

CREATE INDEX IF NOT EXISTS ordensdeservico_index_clienteid ON ordensdeservico (ordemdeservicoid);
PRAGMA user_version = 1;
`;

// // Insert some Users
// const row: Array<Array<any>> = [["Whiteley", "Whiteley.com", 30.2], ["Jones", "Jones.com", 44]];
// export const twoUsers: string = `
// INSERT INTO users (name,email,age) VALUES ("${row[0][0]}","${row[0][1]}",${row[0][2]});
// INSERT INTO users (name,email,age) VALUES ("${row[1][0]}","${row[1][1]}",${row[1][2]});
// `;
// // Insert some Tests issue#56
// export const twoTests = `
// INSERT INTO test56 (name) VALUES ("test 1");
// INSERT INTO test56 (name) VALUES ("test 2");
// `;
// export const setUsers: Array<capSQLiteSet> = [
//     {
//         statement: "INSERT INTO users (name,email,company,size,age) VALUES (?,?,?,?,?);",
//         values: ["Jackson", "Jackson@example.com", null, null, 18]
//     },
//     {
//         statement: "INSERT INTO users (name,email,age) VALUES (?,?,?);",
//         values: ["Kennedy", "Kennedy@example.com", 25]
//     },
//     {
//         statement: "INSERT INTO users (name,email,company,size,age) VALUES (?,?,?,?,?);",
//         values: ["Bush", "Bush@example.com", null, null, null]
//     },
// ];
// export const createSchema82: string = `
// CREATE TABLE IF NOT EXISTS drawings (
//   id TEXT PRIMARY KEY NOT NULL,
//   congregationId TEXT,
//   prefix TEXT,
//   creationTime TEXT NOT NULL,
//   lastUpdated TEXT,
//   featureCollection TEXT NOT NULL,
//   printConfiguration TEXT
// );
// PRAGMA drawings_version = 1;
// `
