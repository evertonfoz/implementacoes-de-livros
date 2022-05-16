import 'package:capitulo03_splashscreen/models/palavra_model.dart';
import 'package:sqflite/sqlite_api.dart';
import 'package:uuid/uuid.dart';

import '../database.dart';
import '../lp_constants.dart';
import '../../functions/string_functions.dart' as string_functions;

class PalavraDAO {
  Future<String?> insert({required PalavraModel palavraModel}) async {
    String? result;
    try {
      Database lpDatabase = await SQFLiteDataBase.instance.database;

      palavraModel.palavraID = const Uuid().v1();
      result = palavraModel.palavraID;

      var recordsAffected =
          await lpDatabase.insert(kPalavrasTableName, palavraModel.toJson());
      if (recordsAffected == 0) result = null;
    } catch (exception) {
      rethrow;
    }
    return result;
  }

  Future<List> getAll({int? startIndex, int? limit}) async {
    List<Map<String, dynamic>> dataList = [];
    try {
      Database lpDatabase = await SQFLiteDataBase.instance.database;

      var result = await lpDatabase.query(
        kPalavrasTableName,
        columns: [kPalavraPalavraID, kPalavraPalavra, kPalavraAjuda],
        offset: startIndex,
        limit: limit,
        orderBy: '$kPalavraPalavra COLLATE LOCALIZED',
      );

      dataList = result.toList();
      dataList.sort((a, b) {
        return string_functions
            .removerAcentos(a[kPalavraPalavra].toLowerCase())
            .compareTo(string_functions
                .removerAcentos(b[kPalavraPalavra].toLowerCase()));
      });

      return dataList;
    } catch (exception) {
      rethrow;
    }
  }
}
