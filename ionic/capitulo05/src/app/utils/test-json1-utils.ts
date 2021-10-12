export const createSchema: string = `
CREATE TABLE IF NOT EXISTS users (
    id INTEGER PRIMARY KEY NOT NULL,
    name TEXT,
    phone TEXT,
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
PRAGMA user_version = 1;
`;    
export const twoUsers: string = `
INSERT INTO users (name,phone) VALUES ("Jones",json('{"cell":"+34712345678", "home":"+34498765432"}'));
INSERT INTO users (name,phone) VALUES ("Jeep",json('{"cell":"+33912345678", "home":"+33598765432"}'));
`;
export const createSchemaArticles: string = `
CREATE TABLE IF NOT EXISTS articles (
    id INTEGER PRIMARY KEY NOT NULL,
    data TEXT,
    last_modified INTEGER DEFAULT (strftime('%s', 'now'))
);
CREATE INDEX IF NOT EXISTS articles_index_last_modified ON articles (last_modified);
CREATE TRIGGER IF NOT EXISTS articles_trigger_last_modified
AFTER UPDATE ON articles
FOR EACH ROW WHEN NEW.last_modified <= OLD.last_modified
BEGIN
    UPDATE articles SET last_modified= (strftime('%s', 'now')) WHERE id=OLD.id;
END;
PRAGMA user_version = 1;
`;    
