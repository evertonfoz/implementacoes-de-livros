import 'package:flutter/material.dart';

import '../widgets/circular_image_widget.dart';
import 'widgets/drawer_controller_widget.dart';

class DrawerRoute extends StatefulWidget {
  const DrawerRoute({Key? key}) : super(key: key);

  @override
  State<DrawerRoute> createState() => _DrawerRouteState();
}

class _DrawerRouteState extends State<DrawerRoute> {
  @override
  Widget build(BuildContext context) {
    return DrawerControllerWidget(
      appBar: AppBar(
        automaticallyImplyLeading: false,
        title: const Text('Jogo da Forca'),
        centerTitle: true,
        actions: const <Widget>[
          Icon(
            Icons.menu,
            size: 40,
          ),
        ],
      ),
      topBody: MediaQuery.of(context).size.height - 105,
      leftBody: MediaQuery.of(context).size.width - 105,
      body: const CircularImageWidget(
        imageProvider: AssetImage('assets/images/splashscreen.png'),
        width: 100,
        height: 100,
      ),
    );
  }
}
