
export const createSchema: string = `
CREATE TABLE IF NOT EXISTS teachers (
    id INTEGER PRIMARY KEY NOT NULL,
    email VARCHAR(255) UNIQUE NOT NULL,
    name VARCHAR(50),
    office TEXT,
    size DOUBLE,
    age INT,
    phone DECIMAL(11,0),
    birth_date DATE,
    last_modified INTEGER DEFAULT (strftime('%s', 'now'))
);
CREATE INDEX IF NOT EXISTS teachers_index_email ON teachers (email);
CREATE INDEX IF NOT EXISTS teachers_index_last_modified ON teachers (last_modified);
CREATE TRIGGER IF NOT EXISTS teachers_trigger_last_modified
AFTER UPDATE ON teachers
FOR EACH ROW WHEN NEW.last_modified <= OLD.last_modified
BEGIN
    UPDATE teachers SET last_modified= (strftime('%s', 'now')) WHERE id=OLD.id;
END;
`;    
export const firstTeachers: string = `
DELETE FROM teachers;
INSERT INTO teachers (name,email,office,size,age,phone,birth_date) VALUES ("Brown","stevebrown@example.com",null,null,null,33601234567,"1980-03-20");
INSERT INTO teachers (name,email,office,size,age,phone,birth_date) VALUES ("Dupont","micheldupont@example.com",null,null,null,33901234567,"1998-04-12");
`;

export const partialImport: any = {
    database : "testTypes",
    version : 1,
    encrypted : false,
    mode : "partial",
    tables :[
        {
            name: "teachers",
            values: [
                [3,"stevemclaren.com","MacLaren",null,null,null,44905671234,"1974-07-20",1618634218],
                [4,"alexanderbannister.com","Bannister","CDK",null,21,44601234567,"2000-07-20",1618644218],
                [5,"brianjones@example.com","Jones","ZWK",null,42,31671434567,"1979-02-03",1618654218]
            ]
        },
        {
            name: "classes",
            schema: [
                {column:"id", value: "INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE"},
                {column:"courseCode", value:"INTEGER NOT NULL"},
                {column:"dayOfWeek", value:"VARCHAR(10) NOT NULL"},
                {column:"timeStart", value:"FLOAT"},
                {column:"timeEnd", value:"FLOAT"},
                {column:"teacherId", value:"INTEGER"},
                {column:"last_modified", value:"INTEGER"},
                {foreignkey: "teacherId", value:"REFERENCES teachers(id) ON DELETE CASCADE"}
            ],
            indexes: [
              {name: "index_classes_on_courseCode",value: "courseCode"},
              {name: "index_classes_on_last_modified",value: "last_modified DESC"}
            ],
            triggers: [
                {
                  name: "classes_trigger_last_modified",
                  timeevent: "AFTER UPDATE",
                  logic: "FOR EACH ROW WHEN NEW.last_modified <= OLD.last_modified BEGIN UPDATE images SET last_modified= (strftime('%s', 'now')) WHERE id=OLD.id;END;"
                }
            ],
            values: [
                [1,1,"Monday",8.30,10.00,1,1618634218],
                [2,2,"Wednesday",14.00,15.00,2,1618634218],
                [3,1,"Friday",10.00,12.00,1,1618634218],
            ]
        }
    ]
};
/*
*/