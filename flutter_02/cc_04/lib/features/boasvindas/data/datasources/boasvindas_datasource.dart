import 'package:shared_preferences/shared_preferences.dart';

const String kDontShowAgainKey = 'dontShowAgain';

class BoasVindasDataSource {
  final SharedPreferences sharedPreferences;

  BoasVindasDataSource._({required this.sharedPreferences});

  _registerDontShowAgain({required bool value}) async {
    await sharedPreferences.setBool(kDontShowAgainKey, value);
  }

  bool _getDontShowAgain() {
    return sharedPreferences.getBool(kDontShowAgainKey) ?? false;
  }

  static registerDontShowAgain({required bool value}) async {
    var sp = await SharedPreferences.getInstance();
    var ds = BoasVindasDataSource._(sharedPreferences: sp);

    await ds._registerDontShowAgain(value: value);
  }

  static Future<bool> getDontShowAgain() async {
    var sp = await SharedPreferences.getInstance();
    var ds = BoasVindasDataSource._(sharedPreferences: sp);

    return ds._getDontShowAgain();
  }
}
