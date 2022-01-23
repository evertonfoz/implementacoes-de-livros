import 'package:flutter/material.dart';
import 'package:cc04/drawer/widgets/drawerheader_app.dart';
import 'package:cc04/drawer/widgets/drawerbody_app.dart';
import 'package:cc04/drawer/widgets/drawerbodycontent_app.dart';

class DrawerRoute extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(
          "Jogo da Forca",
        ),
        centerTitle: true,
      ),
      body: Container(),
      drawer: Drawer(
        child: Column(
          children: <Widget>[
            DrawerHeaderApp(),
            DrawerBodyApp(child: DrawerBodyContentApp()),
          ],
        ),
      ),
    );
  }
}
