export const createSchemaVersion1: string = `
CREATE TABLE IF NOT EXISTS users (
    id INTEGER PRIMARY KEY NOT NULL,
    email TEXT UNIQUE NOT NULL,
    name TEXT,
    company TEXT,
    size REAL,
    age INTEGER,
    last_modified INTEGER DEFAULT (strftime('%s', 'now'))    
);
CREATE INDEX IF NOT EXISTS users_index_name ON users (name);
CREATE INDEX IF NOT EXISTS users_index_last_modified ON users (last_modified);
CREATE TRIGGER IF NOT EXISTS users_trigger_last_modified
AFTER UPDATE ON users
FOR EACH ROW WHEN NEW.last_modified <= OLD.last_modified
BEGIN
    UPDATE users SET last_modified= (strftime('%s', 'now')) WHERE id=OLD.id;
END;
`;
// Insert some Users
const row: Array<Array<any>> = [["Whiteley","Whiteley.com",30.5],["Jones","Jones.com",44]];
export const twoUsers: string = `
INSERT INTO users (name,email,age) VALUES ("${row[0][0]}","${row[0][1]}",${row[0][2]});
INSERT INTO users (name,email,age) VALUES ("${row[1][0]}","${row[1][1]}",${row[1][2]});
`;
export const createSchemaVersion2: string = `
CREATE TABLE users (
  id INTEGER PRIMARY KEY NOT NULL,
  email TEXT UNIQUE NOT NULL,
  name TEXT,
  company TEXT,
  country TEXT,
  age INTEGER,
  last_modified INTEGER DEFAULT (strftime('%s', 'now'))       
);
CREATE TABLE messages (
  id INTEGER PRIMARY KEY NOT NULL,
  userid INTEGER,
  title TEXT NOT NULL,
  body TEXT NOT NULL,
  last_modified INTEGER DEFAULT (strftime('%s', 'now')),        
  FOREIGN KEY (userid) REFERENCES users(id) ON DELETE SET DEFAULT
);
CREATE INDEX users_index_name ON users (name);
CREATE INDEX users_index_last_modified ON users (last_modified);
CREATE INDEX messages_index_title ON messages (title);
CREATE INDEX messages_index_last_modified ON messages (last_modified);
CREATE TRIGGER users_trigger_last_modified
AFTER UPDATE ON users
FOR EACH ROW WHEN NEW.last_modified <= OLD.last_modified
BEGIN
    UPDATE users SET last_modified= (strftime('%s', 'now')) WHERE id=OLD.id;
END;
CREATE TRIGGER messages_trigger_last_modified
AFTER UPDATE ON messages
FOR EACH ROW WHEN NEW.last_modified <= OLD.last_modified
BEGIN
    UPDATE messages SET last_modified= (strftime('%s', 'now')) WHERE id=OLD.id;
END;
`;
export const setArrayVersion2: Array<any> = [
  { statement:"INSERT INTO messages (userid,title,body) VALUES (?,?,?);",
    values:[
      [1,"test message 1","content test message 1"],
      [2,"test message 2","content test message 2"],
      [1,"test message 3","content test message 3"]
    ]
  },
  { statement:"UPDATE users SET country = ?  WHERE id = ?;",
    values:["United Kingdom",1]
  },
  { statement:"UPDATE users SET country = ?  WHERE id = ?;",
    values:["Australia",2]
  },

];

export const userMessages = `
SELECT users.name,messages.title,messages.body FROM users
 INNER JOIN messages ON users.id = messages.userid
 WHERE users.id = ?;
`;

