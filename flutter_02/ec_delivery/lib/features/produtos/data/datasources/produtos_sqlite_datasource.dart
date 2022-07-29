import 'package:ec_delivery/features/produtos/domain/entities/produto.dart';
import 'package:path/path.dart';
import 'package:sqflite/sqflite.dart';

import 'constants.dart';

class ProdutosSQLiteDatasource {
  Future<Database> _getDatabase() async {
    await deleteDatabase(
      join(await getDatabasesPath(), DATABASE_NAME),
    );

    return openDatabase(
      join(await getDatabasesPath(), DATABASE_NAME),
      onCreate: (db, version) async {
        await db.execute(CREATE_PRODUTOS_TABLE_SCRIPT);

        await db.rawInsert('''insert into $PRODUTOS_TABLE_NAME(
            $PRODUTOS_COLUMN_NOME, $PRODUTOS_COLUMN_DESCRICAO,
            $PRODUTOS_COLUMN_VALOR) 
              VALUES(
                'Suco de Laranja', '300 ml - Natural', 5
              )
          ''');
      },
      version: databaseVersion,
    );
  }

  Future create(Produto produto) async {
    try {
      final Database db = await _getDatabase();

      produto.produtoID =
          await db.rawInsert('''insert into $PRODUTOS_TABLE_NAME(
                $PRODUTOS_COLUMN_NOME, $PRODUTOS_COLUMN_DESCRICAO,
                $PRODUTOS_COLUMN_VALOR) 
              VALUES(
                '${produto.nome}', '${produto.descricao}', 
                '${produto.valor}'
              )
          ''');
    } catch (ex) {
      return;
    }
  }
}
