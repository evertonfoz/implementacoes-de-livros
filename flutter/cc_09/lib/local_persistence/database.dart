import 'dart:io';

import 'package:path/path.dart';
import 'package:path_provider/path_provider.dart';
import 'package:sqflite/sqflite.dart';

import 'lp_constants.dart';

class SQFLiteDataBase {
  /// Objeto SQFLite para nossa base de dados
  static Database _database;

  /// Um construtor privado, atuando como um singleton para termos sempre a mesma
  /// conexão em toda a aplicação
  SQFLiteDataBase._privateConstructor();
  static final SQFLiteDataBase instance = SQFLiteDataBase._privateConstructor();

  /// Acessor à base de dados
  Future<Database> get database async {
    if (_database != null) return _database;
    _database = await _initDatabase();
    return _database;
  }

  /// Método que inicializará a base de dados, caso ainda não exista
  _initDatabase() async {
    Directory documentsDirectory = await getApplicationDocumentsDirectory();
    String path = join(documentsDirectory.path, kDatabaseName);
    return await openDatabase(path,
        version: kDatabaseVersion,
        onCreate: _onCreateDb,
        onUpgrade: _nUpgradeDb,
        onDowngrade: _onDowngradeDb);
  }

  /// Métodos que serão executados de acordo ao estado identificado na
  /// inicialização.
  Future _onCreateDb(Database database, int version) async {
    await database.execute("CREATE TABLE palavras ("
        "palavraID TEXT PRIMARY KEY,"
        "palavra TEXT,"
        "ajuda TEXT"
        ")");
  }

  Future _nUpgradeDb(
      Database database, int previousVersion, int newVersion) async {}
  Future _onDowngradeDb(
      Database database, int previousVersion, int newVersion) async {}
}
