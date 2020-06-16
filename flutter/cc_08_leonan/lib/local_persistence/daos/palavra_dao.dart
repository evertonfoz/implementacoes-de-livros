import 'package:cc04/models/palavra_model.dart';
import 'package:meta/meta.dart';
import 'package:sqflite/sqlite_api.dart';
import 'package:uuid/uuid.dart';

import '../database.dart';
import '../lp_constants.dart';

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
}
