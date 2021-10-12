import { capSQLiteSet } from '@capacitor-community/sqlite';
export const createSchemaContacts: string = `
CREATE TABLE IF NOT EXISTS contacts (
  id INTEGER PRIMARY KEY NOT NULL,
  email TEXT UNIQUE NOT NULL,
  name TEXT,
  FirstName TEXT,
  company TEXT,
  size REAL,
  age INTEGER,
  MobileNumber TEXT
);
CREATE INDEX IF NOT EXISTS contacts_index_name ON contacts (name);
CREATE INDEX IF NOT EXISTS contacts_index_email ON contacts (email);
PRAGMA user_version = 1;
`;
export const setContacts: Array<capSQLiteSet>  = [
  { statement:"INSERT INTO contacts (name,FirstName,email,company,age,MobileNumber) VALUES (?,?,?,?,?,?);",
    values:["Simpson","Tom","Simpson@example.com",,69,"4405060708"]
  },
  { statement:"INSERT INTO contacts (name,FirstName,email,company,age,MobileNumber) VALUES (?,?,?,?,?,?);",
    values:[
      ["Jones","David","Jones@example.com",,42.1,"4404030201"],
      ["Whiteley","Dave","Whiteley@example.com",,45.3,"4405162732"],
      ["Brown","John","Brown@example.com",,35,"4405243853"]
    ]
  },
  { statement:"UPDATE contacts SET age = ? , MobileNumber = ? WHERE id = ?;",
    values:[51.4,"4404030202",2]
  }
];
export const createSchemaMessages: string = `
CREATE TABLE IF NOT EXISTS messages (
  id INTEGER PRIMARY KEY NOT NULL,
  contactid INTEGER,
  title TEXT NOT NULL,
  body TEXT NOT NULL,
  last_modified INTEGER DEFAULT (strftime('%s', 'now')),
  FOREIGN KEY (contactid) REFERENCES contacts(id) ON DELETE SET DEFAULT
);
CREATE INDEX IF NOT EXISTS messages_index_name ON messages (title);
CREATE INDEX IF NOT EXISTS messages_index_last_modified ON messages (last_modified);
`
export const setMessages: Array<capSQLiteSet>  = [
  { statement:"INSERT INTO messages (contactid,title,body) VALUES (?,?,?);",
    values:[
      [1,"message 1","body message1"],
      [2,"message 2","body message2"],
      [1,"message 3","body message3"]
    ]
  },
]
export const setIssue170: Array<capSQLiteSet>  = [
  { statement: "DROP TABLE IF EXISTS issue170", values: [] },
  { statement: "CREATE TABLE issue170 (src VARCHAR(255))", values: [] },
  { statement: "INSERT INTO issue170 (src) values (?)", values: ["google.com"] },
]

