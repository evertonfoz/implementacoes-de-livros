import 'package:capitulo03_splashscreen/drawer/widgets/drawerheader_app.dart';
import 'package:flutter/material.dart';

import 'widgets/drawerbody_app.dart';
import 'widgets/drawerbodycontent_app.dart';

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
            DrawerBodyApp(
              child: DrawerBodyContentApp(),
            ),
          ],
        ),
      ),
    );
  }
}
