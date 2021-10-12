import { Images } from './base64images';

export const dataToImport: any = {
    database : "db-from-json",
    version : 1,
    encrypted : false,
    mode : "full",
    tables :[
        {
            name: "users",
            schema: [
                {column:"id", value: "INTEGER PRIMARY KEY NOT NULL"},
                {column:"email", value:"TEXT UNIQUE NOT NULL"},
                {column:"name", value:"TEXT"},
                {column:"age", value:"REAL"},
                {column:"last_modified", value:"INTEGER"}
            ],
            indexes: [
                {name: "index_user_on_name",value: "name"},
                {name: "index_user_on_last_modified",value: "last_modified DESC"},
                {name: "index_user_on_email_name", value: "email ASC, name", mode: "UNIQUE"}
            ],
            values: [
                [1,"Whiteley.com","Whiteley",30.5,1582536810],
                [2,"Jones.com","Jones",44.2,1582812800],
                [3,"Simpson@example.com","Simpson",69,1583570630],
                [4,"Brown@example.com","Brown",15,1590383895]
            ]
        },
        {
          name: "messages",
          schema: [
            {column:"id", value: "INTEGER PRIMARY KEY NOT NULL"},
            {column:"title", value:"TEXT NOT NULL"},
            {column:"body", value:"TEXT NOT NULL"},
            {column:"last_modified", value:"INTEGER"}
          ],
          values: [
              [1,"test post 1","content test post 1",1587310030],
              [2,"test post 2","content test post 2",1590388125]
          ]
        },
        {
          name: "images",
          schema: [
            {column:"id", value: "INTEGER PRIMARY KEY NOT NULL"},
            {column:"name", value:"TEXT UNIQUE NOT NULL"},
            {column:"type", value:"TEXT NOT NULL"},
            {column:"size", value:"INTEGER"},
            {column:"img", value:"BLOB"},
            {column:"last_modified", value:"INTEGER"}
          ],
          values: [
            [1,"feather","png",null,Images[1],1582536810],
            [2,"meowth","png",null,Images[0],1590151132]
          ]
        }

    ]
};
export const partialImport1: any = {
    database : "db-from-json",
    version : 1,
    encrypted : false,
    mode : "partial",
    tables :[
        {
            name: "users",
            values: [
                [5,"Addington.com","Addington",22.7,1590388335],
                [6,"Bannister.com","Bannister",59,1590393015],
                [2,"Jones@example.com","Jones",45,1590393325]

            ]
        },
    ]
};
export const partialImport2: any = {
  database : "db-from-json",
  version : 1,
  encrypted : false,
  mode : "partial",
  tables :[
      {
        name: "messages",

        indexes: [
          {name: "index_messages_on_title",value: "title"},
          {name: "index_messages_on_last_modified",value: "last_modified DESC"}

        ],
        values: [
            [3,"test post 3","content test post 3",1590396146],
            [4,"test post 4","content test post 4",1590396288]
        ]
      }

  ]
};
export const partialImport3: any = {
  database : "db-from-json",
  version : 1,
  encrypted : false,
  mode : "partial",
  tables :[
      {
        name: "test113",
        schema: [
          {column:"id", value: "TEXT PRIMARY KEY NOT NULL"},
          {column:"name", value:"TEXT UNIQUE NOT NULL"},
          {column:"code", value:"TEXT"},
          {column:"last_modified", value:"INTEGER"}
        ],
        indexes: [
          {name: "index_test113_on_title",value: "name"},
          {name: "index_test113_on_last_modified",value: "last_modified DESC"}

        ],
        values: [
            ["ef5c57d5-b885-49a9-9c4d-8b340e4abdbc","valve","BV50",1590396146],
            ["bced3262-5d42-470a-9585-d3fd12c45452","pipe","PIPE100",1590396288],
            ["ef5c57d5-b885-49a9-9c4d-8b340e4abdbc","valve","BV100",1590396300],
        ]
      }

  ]
};

export const dataToImport59: any = {
  database : "db-from-json59",
  version : 1,
  encrypted : false,
  mode : "full",
  tables :[
      {
          name: "countries",
          schema: [
              {column:"id", value: "TEXT PRIMARY KEY NOT NULL"},
              {column:"name", value:"TEXT UNIQUE NOT NULL"},
              {column:"code", value:"TEXT"},
              {column:"language", value:"TEXT"},
              {column:"phone_code", value:"TEXT"},
              {column:"last_modified", value:"INTEGER"}
          ],
          indexes: [
              {name: "index_country_on_name",value: "name", mode: "UNIQUE"},
              {name: "index_country_on_last_modified",value: "last_modified DESC"}
          ],
          values: [
              ["3","Afghanistan","AF","fa","93",1608216034],
              ["6","Albania","AL","sq","355",1608216034],
              ["56","Algeria","DZ","ar","213",1608216034],
          ]
      },
      {
        name: "customers",
        schema: [
          {column:"id", value: "TEXT PRIMARY KEY NOT NULL"},
          {column:"first_name", value:"TEXT NOT NULL"},
          {column:"last_name", value:"TEXT NOT NULL"},
          {column:"gender", value:"TEXT NOT NULL"},
          {column:"email", value:"TEXT NOT NULL"},
          {column:"phone", value:"TEXT"},
          {column:"national_id", value:"TEXT NOT NULL"},
          {column:"date_of_birth", value:"TEXT"},
          {column:"created_at", value:"TEXT"},
          {column:"created_by", value:"TEXT"},
          {column:"last_edited", value:"TEXT"},
          {column:"organization", value:"TEXT"},
          {column:"comment_id", value:"TEXT"},
          {column:"country_id", value:"TEXT NOT NULL"},
          {column:"last_modified", value:"INTEGER"},
          {foreignkey: "country_id", value:"REFERENCES countries(id) ON DELETE CASCADE"}
        ],
        indexes: [
          {name: "index_customers_on_email",value: "email", mode: "UNIQUE"},
          {name: "index_customers_on_last_modified",value: "last_modified DESC"}
        ],
        triggers: [
          {
            name: "validate_email_before_insert_customers",
            timeevent: "BEFORE INSERT",
            logic: "BEGIN SELECT CASE WHEN NEW.email NOT LIKE '%_@__%.__%' THEN RAISE (ABORT,'Invalid email address') END; END"
          }
        ],
        values: [
            ["ef5c57d5-b885-49a9-9c4d-8b340e4abdbc","William","Jones","1","peterjones@mail.com<peterjones@mail.com>","420305202","1234567","1983-01-04","2020-11-1212:39:02","3","2020-11-19 05:10:10","1",null,"3",1608216040],
            ["bced3262-5d42-470a-9585-d3fd12c45452","Alexander","Brown","1","alexanderbrown@mail.com<alexanderbrown@mail.com>","420305203","1234572","1990-02-07","2020-12-1210:35:15","1","2020-11-19 05:10:10","2",null,"6",1608216040]
        ]
      }
  ]
};

export const dataToImport2: any = {
  database : "db-from-json",
  version : 1,
  encrypted : false,
  mode : "full",
  tables :[
      {
        name: "images",
        schema: [
          {column:"id", value: "INTEGER PRIMARY KEY NOT NULL"},
          {column:"name", value:"TEXT UNIQUE NOT NULL"},
          {column:"type", value:"TEXT NOT NULL"},
          {column:"size", value:"INTEGER"},
          {column:"img", value:"BLOB"},
          {column:"last_modified", value:"INTEGER"}
        ],
        values: [
          [1,"feather","png",null,Images[1],1582536810],
          [2,"meowth","png",null,Images[0],1590151132]
        ]
      }

  ]
};
export const dataToImport71: any = {
  database : "db-from-json71",
  version : 1,
  encrypted : false,
  mode : "full",
  tables :[
      {
          name: "company",
          schema: [
              {column:"id", value: "INTEGER NOT NULL"},
              {column:"name", value:"TEXT NOT NULL"},
              {column:"age", value:"INTEGER NOT NULL"},
              {column:"country", value:"TEXT"},
              {column:"salary", value:"REAL"},
              {column:"last_modified", value:"INTEGER"},
              {constraint:"PK_id_name", value:"PRIMARY KEY (id,name,age)"}
          ],
          values: [
              [1,"Jones",55,"Australia",1250.98,1608216034],
              [2,"Lawson",32,"Ireland",2345.60,1608216034],
              [3,"Bush",44,"USA",1850.10,1608216034],
          ]
      },
    ]
};
  
export const dataToImport94: any = {
    database : "db-from-json94",
    version : 1,
    encrypted : false,
    mode : "full",
    tables :[
        {
            name: "reps",
            schema: [
                {column:"id", value: "INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE"},
                {column:"fk_workoutexercices", value:"INTEGER NOT NULL"},
                {column:"weight", value:"REAL NOT NULL"},
                {column:"reps", value:"INTEGER NOT NULL"},
                {column:"rest", value:"INTEGER NOT NULL"},
                {column:"note", value:"TEXT"},
            ],
            values: [
                [1,1,11,21,31,null],
                [2,1,12,22,32,null],
                [3,1,13,23,33,null],
            ]
        },
    ]
};
export const schemaToImport164: any = {
  "database": "test_study_db",
  "version": 1,
  "encrypted": false,
  "mode": "full",
  "tables": [
      {
          "name": "modules",
          "schema": [
              {"column": "id", "value": "INTEGER PRIMARY KEY NOT NULL"},
              {"column": "name", "value": "TEXT NOT NULL"},
              {"column": "color", "value": "TEXT NOT NULL"},
              {"column": "room", "value": "TEXT"},
              {"column": "tag", "value": "TEXT"},
              {"column": "event", "value": "TEXT"},
              {"column": "home_work", "value": "TEXT"},
              {"column": "last_modified", "value": "INTEGER DEFAULT (strftime('%s', 'now'))"}
          ],
      },
      {
          "name": "module_date",
          "schema": [
              {"column": "id", "value": "INTEGER PRIMARY KEY NOT NULL"},
              {"column": "date_time", "value": "TEXT NOT NULL"},
              {"column": "last_modified", "value": "INTEGER DEFAULT (strftime('%s', 'now'))"},
              {
                  "foreignkey": "module_id",
                  "value": "REFERENCES modules(id)"
              }
          ],
      }
  ]
}
export const schemaVersion1: any = {
  database : "db-issue164",
  version : 1,
  encrypted : false,
  mode : "full",
  tables :[
      {
          name: "users",
          schema: [
              {column:"id", value: "INTEGER PRIMARY KEY NOT NULL"},
              {column:"email", value:"TEXT UNIQUE NOT NULL"},
              {column:"name", value:"TEXT"},
              {column:"age", value:"REAL"},
              {column:"last_modified", value:"INTEGER"}
          ],
          indexes: [
              {name: "index_user_on_name",value: "name"},
              {name: "index_user_on_last_modified",value: "last_modified DESC"},
              {name: "index_user_on_email_name", value: "email ASC, name", mode: "UNIQUE"}
          ],
      },
      {
        name: "messages",
        schema: [
          {column:"id", value: "INTEGER PRIMARY KEY NOT NULL"},
          {column:"title", value:"TEXT NOT NULL"},
          {column:"body", value:"TEXT NOT NULL"},
          {column:"last_modified", value:"INTEGER"}
        ],
      },
      {
        name: "images",
        schema: [
          {column:"id", value: "INTEGER PRIMARY KEY NOT NULL"},
          {column:"name", value:"TEXT UNIQUE NOT NULL"},
          {column:"type", value:"TEXT NOT NULL"},
          {column:"size", value:"INTEGER"},
          {column:"img", value:"BLOB"},
          {column:"last_modified", value:"INTEGER"}
        ],
      }

  ]

}

export const dataVersion1: any = {
  database : "db-issue164",
  version : 1,
  encrypted : false,
  mode : "partial",
  tables :[
      {
          name: "users",
          values: [
              [1,"Whiteley.com","Whiteley",30.5,1582536810],
              [2,"Jones.com","Jones",44.2,1582812800],
              [3,"Simpson@example.com","Simpson",69,1583570630],
              [4,"Brown@example.com","Brown",15,1590383895]
          ]
      },
      {
        name: "messages",
        values: [
            [1,"test post 1","content test post 1",1587310030],
            [2,"test post 2","content test post 2",1590388125]
        ]
      },
      {
        name: "images",
        values: [
          [1,"feather","png",null,Images[1],1582536810],
          [2,"meowth","png",null,Images[0],1590151132]
        ]
      }

  ]

}
export const schemaVersion2: any = {
  database : "db-issue164",
  version : 2,
  encrypted : false,
  mode : "full",
  tables :[
      {
          name: "users",
          schema: [
              {column:"id", value: "INTEGER PRIMARY KEY NOT NULL"},
              {column:"email", value:"TEXT UNIQUE NOT NULL"},
              {column:"name", value:"TEXT"},
              {column:"age", value:"REAL"},
              {column:"country", value:"TEXT"},
              {column:"last_modified", value:"INTEGER"}
          ],
          indexes: [
              {name: "index_user_on_name",value: "name"},
              {name: "index_user_on_last_modified",value: "last_modified DESC"},
              {name: "index_user_on_email_name", value: "email ASC, name", mode: "UNIQUE"}
          ],
      },
      {
        name: "messages",
        schema: [
          {column:"id", value: "INTEGER PRIMARY KEY NOT NULL"},
          {column:"title", value:"TEXT NOT NULL"},
          {column:"body", value:"TEXT NOT NULL"},
          {column:"last_modified", value:"INTEGER"}
        ],
      },
  ]

}
export const dataVersion2: any = {
  database : "db-issue164",
  version : 2,
  encrypted : false,
  mode : "partial",
  tables :[
      {
          name: "users",
          values: [
              [1,"Whiteley.com","Whiteley",30.5,"United of Kingdom",1582536810],
              [2,"Jones.com","Jones",44.2,"Australia",1582812800],
              [3,"Simpson@example.com","Simpson",69,"South Africa",1583570630],
              [4,"Brown@example.com","Brown",15,"United States", 1590383895],
              [5,"Jeep@example.com","Jeep",70,"France", 1590383980]
          ]
      },
      {
        name: "messages",
        values: [
            [1,"test post 1","content test post 1",1587310030],
            [2,"test post 2","content test post 2",1590388125],
            [3,"test post 3","content test post 3",1590389355],
        ]
      },
  ]

}
export const dataToImport167: any = {
  database: "db-issue167",
  version: 1,
  encrypted: false,
  mode: "full",
  tables: [
    {
      name: "departments",
      schema: [
        {column: "id", value: "INTEGER PRIMARY KEY AUTOINCREMENT" },
        {column: "name", value: "TEXT NOT NULL" },
        {column:"last_modified", value:"INTEGER"}
      ],
      indexes: [
        {name: "index_departments_on_last_modified",value: "last_modified DESC"}
      ],
      values: [
        [1,"Admin",1608216034],
        [2,"Sales",1608216034],
        [3,"Quality Control",1608216034],
        [4,"Marketing",1608216034],
      ]
    },
    {
      name: "employees",
      schema: [
        {column: "id", value: "INTEGER PRIMARY KEY AUTOINCREMENT" },
        {column: "first_name", value: "TEXT" },
        {column: "last_name", value: "TEXT" },
        {column: "salary", value: "NUMERIC" },
        {column: "dept_id", value: "INTEGER" },
        {column: "last_modified", value: "INTEGER"}
      ],
      indexes: [
        {name: "index_departments_on_last_modified",value: "last_modified DESC"}
      ],
      values: [
        [1,"John","Brown",27500,1,1608216034],
        [2,"Sally","Brown",37500,2,1608216034],
        [3,'Vinay','Jariwala', 35100,3,1608216034],
        [4,'Jagruti','Viras', 9500,2,1608216034],
        [5,'Shweta','Rana',12000,3,1608216034],
        [6,'sonal','Menpara', 13000,1,1608216034],
        [7,'Yamini','Patel', 10000,2,1608216034],
        [8,'Khyati','Shah', 50000,3,1608216034],
        [9,'Shwets','Jariwala',19400,2,1608216034],
        [10,'Kirk','Douglas',36400,4,1608216034],
        [11,'Leo','White',45000,4,1608216034],
      ],
    }
  ],
  views: [
    {name: "SalesTeam", value: "SELECT id,first_name,last_name from employees WHERE dept_id IN (SELECT id FROM departments where name='Sales')"},
    {name: "AdminTeam", value: "SELECT id,first_name,last_name from employees WHERE dept_id IN (SELECT id FROM departments where name='Admin')"},
  ]
}
export const viewsToImport167: any = {
  database: "db-issue167",
  version: 1,
  encrypted: false,
  mode: "partial",
  tables: [],
  views: [
    {name: "QualityControlTeam", value: "SELECT id,first_name,last_name from employees WHERE dept_id IN (SELECT id FROM departments where name='Quality Control')"},
    {name: "MarketingTeam", value: "SELECT id,first_name,last_name from employees WHERE dept_id IN (SELECT id FROM departments where name='Marketing')"},
  ]
}
