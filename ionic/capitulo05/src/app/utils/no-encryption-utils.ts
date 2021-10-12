import { capSQLiteSet } from '@capacitor-community/sqlite';
export const createSchema: string = `
CREATE TABLE IF NOT EXISTS users (
    id INTEGER PRIMARY KEY NOT NULL,
    email TEXT UNIQUE NOT NULL,
    name TEXT,
    company TEXT,
    size REAL,
    age INTEGER,
    last_modified INTEGER DEFAULT (strftime('%s', 'now'))
);
CREATE TABLE IF NOT EXISTS messages (
  id INTEGER PRIMARY KEY NOT NULL,
  userid INTEGER,
  title TEXT NOT NULL,
  body TEXT NOT NULL,
  last_modified INTEGER DEFAULT (strftime('%s', 'now')),
  FOREIGN KEY (userid) REFERENCES users(id) ON DELETE SET DEFAULT
);
CREATE TABLE IF NOT EXISTS images (
  id INTEGER PRIMARY KEY NOT NULL,
  name TEXT UNIQUE NOT NULL,
  type TEXT NOT NULL,
  size INTEGER,
  img BLOB,
  last_modified INTEGER DEFAULT (strftime('%s', 'now'))
);
CREATE TABLE IF NOT EXISTS test56 (
  id INTEGER PRIMARY KEY NOT NULL,
  name TEXT,
  name1 TEXT
);
CREATE INDEX IF NOT EXISTS users_index_name ON users (name);
CREATE INDEX IF NOT EXISTS users_index_last_modified ON users (last_modified);
CREATE INDEX IF NOT EXISTS messages_index_name ON messages (title);
CREATE INDEX IF NOT EXISTS messages_index_last_modified ON messages (last_modified);
CREATE INDEX IF NOT EXISTS images_index_name ON images (name);
CREATE INDEX IF NOT EXISTS images_index_last_modified ON images (last_modified);
CREATE TRIGGER IF NOT EXISTS users_trigger_last_modified
AFTER UPDATE ON users
FOR EACH ROW WHEN NEW.last_modified <= OLD.last_modified
BEGIN
    UPDATE users SET last_modified= (strftime('%s', 'now')) WHERE id=OLD.id;
END;
CREATE TRIGGER IF NOT EXISTS messages_trigger_last_modified
AFTER UPDATE ON messages
FOR EACH ROW WHEN NEW.last_modified <= OLD.last_modified
BEGIN
    UPDATE messages SET last_modified= (strftime('%s', 'now')) WHERE id=OLD.id;
END;
CREATE TRIGGER IF NOT EXISTS images_trigger_last_modified
AFTER UPDATE ON images
FOR EACH ROW WHEN NEW.last_modified <= OLD.last_modified
BEGIN
    UPDATE images SET last_modified= (strftime('%s', 'now')) WHERE id=OLD.id;
END;
PRAGMA user_version = 1;
`;    

// Insert some Users
const row: Array<Array<any>> = [["Whiteley","Whiteley.com",30.2],["Jones","Jones.com",44]];
export const twoUsers: string = `
INSERT INTO users (name,email,age) VALUES ("${row[0][0]}","${row[0][1]}",${row[0][2]});
INSERT INTO users (name,email,age) VALUES ("${row[1][0]}","${row[1][1]}",${row[1][2]});
`;
// Insert some Tests issue#56
export const twoTests = `
INSERT INTO test56 (name) VALUES ("test 1");
INSERT INTO test56 (name) VALUES ("test 2");
`;
export const setUsers: Array<capSQLiteSet>  = [
  { statement:"INSERT INTO users (name,email,company,size,age) VALUES (?,?,?,?,?);",
    values:["Jackson","Jackson@example.com",null,null,18]
  },
  { statement:"INSERT INTO users (name,email,age) VALUES (?,?,?);",
    values:["Kennedy","Kennedy@example.com",25]
  },
  { statement:"INSERT INTO users (name,email,company,size,age) VALUES (?,?,?,?,?);",
    values:["Bush","Bush@example.com",null,null,null]
  },
];
export const createSchema82: string = `
CREATE TABLE IF NOT EXISTS drawings (
  id TEXT PRIMARY KEY NOT NULL,
  congregationId TEXT,
  prefix TEXT,
  creationTime TEXT NOT NULL,
  lastUpdated TEXT,
  featureCollection TEXT NOT NULL,
  printConfiguration TEXT
);
PRAGMA drawings_version = 1;
`

