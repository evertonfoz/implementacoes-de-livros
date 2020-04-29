import 'package:meta/meta.dart';
import 'package:sqflite/sqlite_api.dart';
import 'package:uuid/uuid.dart';

import '../database.dart';
import '../lp_constants.dart';

import 'package:cc04/models/palavra_model.dart';

import '../../functions/string_functions.dart' as StringFunctions;

class PalavraDAO {
  Future<String> insert({@required PalavraModel palavraModel}) async {
    String result;
    try {
      Database lpDatabase = await SQFLiteDataBase.instance.database;

      palavraModel.palavraID = Uuid().v1();
      result = palavraModel.palavraID;

      var recordsAffected =
          await lpDatabase.insert(kPalavrasTableName, palavraModel.toJson());
      if (recordsAffected == 0) result = null;
    } catch (exception) {
      rethrow;
    }
    return result;
  }

  Future<List> getAll({int startIndex, int limit}) async {
    List<Map<String, dynamic>> dataList = List();
    try {
      Database lpDatabase = await SQFLiteDataBase.instance.database;

      var result = await lpDatabase.query(
        kPalavrasTableName,
        columns: [kPalavraPalavraID, kPalavraPalavra, kPalavraAjuda],
        offset: startIndex ?? null,
        limit: limit ?? null,
        orderBy: kPalavraPalavra,
      );

      dataList = result.toList();
      dataList.sort((a, b) {
        return StringFunctions.removerAcentos(a[kPalavraPalavra].toLowerCase())
            .compareTo(StringFunctions.removerAcentos(
                b[kPalavraPalavra].toLowerCase()));
      });

      return dataList;
    } catch (exception, stacktrace) {
      print('erro -> $exception / $stacktrace');
      rethrow;
    }
  }
}
