import 'package:flutter/material.dart';
import 'package:forca/app_constants/router_constants.dart';
import 'package:forca/local_persistence/lp_constants.dart';
import 'package:forca/routes/palavras/crud/palavras_crud_route.dart';
import 'package:forca/routes/palavras/list/palavras_listview_route.dart';

class AppRouter {
  static Route<dynamic> generateRoute(RouteSettings settings) {
    switch (settings.name) {
      case kPalavrasCRUDRoute:
        return MaterialPageRoute(builder: (_) => const PalavrasCRUDRoute());
      case kPalavrasAllRoute:
        return MaterialPageRoute(builder: (_) => PalavrasListViewRoute());
      default:
        return MaterialPageRoute(
            builder: (_) => Scaffold(
                  body: Center(
                      child: Text('No route defined for ${settings.name}')),
                ));
    }
  }
}
