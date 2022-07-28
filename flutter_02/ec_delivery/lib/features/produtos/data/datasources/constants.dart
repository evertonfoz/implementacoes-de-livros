// ignore_for_file: constant_identifier_names

const String DATABASE_NAME = 'ec_delivery_db';

const String PRODUTOS_TABLE_NAME = 'produtos';
const String PRODUTOS_COLUMN_PRODUTOID = 'produtoID';
const String PRODUTOS_COLUMN_NOME = 'nome';
const String PRODUTOS_COLUMN_DESCRICAO = 'descricao';
const String PRODUTOS_COLUMN_VALOR = 'valor';

const String CREATE_PRODUTOS_TABLE_SCRIPT = '''
  CREATE TABLE $PRODUTOS_TABLE_NAME
  (
    $PRODUTOS_COLUMN_PRODUTOID INTEGER PRIMARY KEY,
    $PRODUTOS_COLUMN_NOME TEXT,
    $PRODUTOS_COLUMN_DESCRICAO TEXT, 
    $PRODUTOS_COLUMN_VALOR REAL
  )
  ''';

const int databaseVersion = 1;
