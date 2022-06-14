import 'package:capitulo03_splashscreen/routes/palavras/crud/palavras_crud_route.dart';
import 'package:flutter/material.dart';

import '../app_constants/router_constants.dart';

class AppRouter {
  static Route<dynamic> generateRoute(RouteSettings settings) {
    switch (settings.name) {
      case kPalavrasCRUDRoute:
        return MaterialPageRoute(builder: (_) => const PalavrasCRUDRoute());
      default:
        return MaterialPageRoute(
            builder: (_) => Scaffold(
                  body: Center(
                      child: Text('No route defined for ${settings.name}')),
                ));
    }
  }
}
