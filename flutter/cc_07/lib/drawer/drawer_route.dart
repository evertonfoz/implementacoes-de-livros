import 'package:cc04/drawer/widgets/drawerbody_app.dart';
import 'package:cc04/drawer/widgets/drawerbodycontent_app.dart';
import 'package:cc04/drawer/widgets/drawerheader_app.dart';
import 'package:cc04/widgets/circular_image_widget.dart';
import 'package:flutter/material.dart';
import 'package:cc04/drawer/widgets/drawer_controller_widget.dart';

class DrawerRoute extends StatefulWidget {
  @override
  _DrawerRouteState createState() => _DrawerRouteState();
}

class _DrawerRouteState extends State<DrawerRoute> {
  @override
  Widget build(BuildContext context) {
    return DrawerControllerWidget(
      appBar: AppBar(
        automaticallyImplyLeading: false,
        title: Text('Jogo da Forca'),
        centerTitle: true,
        actions: <Widget>[
          Icon(
            Icons.menu,
            size: 40,
          ),
        ],
      ),
      topBody: MediaQuery.of(context).size.height - 105,
      leftBody: MediaQuery.of(context).size.width - 105,
      body: CircularImageWidget(
        imageProvider: AssetImage('assets/images/splashscreen.png'),
        width: 100,
        heigth: 100,
      ),
      drawer: Drawer(
        child: Column(
          children: <Widget>[
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
