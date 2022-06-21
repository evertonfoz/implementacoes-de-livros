import 'package:flutter/material.dart';

import 'widgets/drawerheader_app.dart';

class DrawerRoute extends StatelessWidget {
  const DrawerRoute({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text(
          "Jogo da Forca",
        ),
        centerTitle: true,
      ),
      body: Container(),
      drawer: Drawer(
        child: Column(
          children: const <Widget>[
            DrawerHeaderApp(),
          ],
        ),
      ),
    );
  }
}
