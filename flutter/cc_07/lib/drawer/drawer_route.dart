import 'package:flutter/material.dart';
import 'package:cc04/drawer/widgets/drawer_controller_widget.dart';

class DrawerRoute extends StatefulWidget {
  @override
  _DrawerRouteState createState() => _DrawerRouteState();
}

class _DrawerRouteState extends State<DrawerRoute> {
  @override
  Widget build(BuildContext context) {
    return DrawerControllerWidget();
  }
}
