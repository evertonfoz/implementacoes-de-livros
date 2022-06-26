import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:forca/drawer/blocs/drawer_bloc.dart';
import 'package:forca/widgets/circular_image_widget.dart';

import 'widgets/drawer_controller_widget.dart';
import 'widgets/drawerbody_app.dart';
import 'widgets/drawerbodycontent_app.dart';
import 'widgets/drawerheader_app.dart';

class DrawerRoute extends StatefulWidget {
  const DrawerRoute({Key? key}) : super(key: key);

  @override
  State<DrawerRoute> createState() => _DrawerRouteState();
}

class _DrawerRouteState extends State<DrawerRoute> {
  // ignore: prefer_final_fields
  bool _drawerIsOpen = false;

  double _topBody() {
    return MediaQuery.of(context).size.height - 105;
  }

  double _leftBody() {
    if (!_drawerIsOpen) {
      return MediaQuery.of(context).size.width - 105;
    } else {
      return 5;
    }
  }

  // _handleDrawer(bool drawerIsOpen) {
  //   setState(() {
  //     _drawerIsOpen = drawerIsOpen;
  //   });
  // }

  double _leftBodyOpen() {
    return 5;
  }

  double _leftBodyClose() {
    return MediaQuery.of(context).size.width - 105;
  }

  void _drawerCallback(bool status) {
    context.read<DrawerBloc>().add(ToogleDrawer(isOpen: !status));
  }

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
      topBody: _topBody(),
      leftBody: _leftBody(),
      body: const CircularImageWidget(
        imageProvider: AssetImage('assets/images/splashscreen.png'),
        width: 100,
        height: 100,
      ),
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
      callbackFunction: _drawerCallback,
      leftBodyOpen: _leftBodyOpen(),
      leftBodyClose: _leftBodyClose(),
    );
  }
}
