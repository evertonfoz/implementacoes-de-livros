import 'package:capitulo03_splashscreen/models/palavra_model.dart';
import 'package:capitulo03_splashscreen/routes/jogo/jogo_route.dart';
import 'package:capitulo03_splashscreen/routes/palavras/crud/palavras_crud_route.dart';
import 'package:capitulo03_splashscreen/routes/palavras/list/palavras_listview_route.dart';
import 'package:flutter/material.dart';

import '../app_constants/router_constants.dart';

class AppRouter {
  static Route<dynamic> generateRoute(RouteSettings settings) {
    switch (settings.name) {
      case kPalavrasCRUDRoute:
        return MaterialPageRoute(
            builder: (_) => PalavrasCRUDRoute(
                palavraModel: settings.arguments as PalavraModel?));
      case kPalavrasAllRoute:
        return MaterialPageRoute(builder: (_) => const PalavrasListViewRoute());
      case kJogoRoute:
        return MaterialPageRoute(builder: (_) => JogoRoute());
      default:
        return MaterialPageRoute(
            builder: (_) => Scaffold(
                  body: Center(
                      child: Text('No route defined for ${settings.name}')),
                ));
    }
  }
}
