import 'package:cc04/drawer/blocs/drawer_bloc.dart';
import 'package:cc04/drawer/blocs/drawer_bloc_enums.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class DrawerControllerWidget extends StatelessWidget {
  final AppBar appBar;
  final Widget body;
  final double topBody;
//  final double leftBody;
  final Drawer drawer;
  final Function callbackFunction;
  final double leftBodyOpen;
  final double leftBodyClose;

  DrawerControllerWidget({
    this.appBar,
    this.body,
    this.topBody,
//    this.leftBody,
    this.drawer,
    this.callbackFunction,
    this.leftBodyOpen,
    this.leftBodyClose,
  });

  GlobalKey<DrawerControllerState> drawerKey =
      GlobalKey<DrawerControllerState>();
  BuildContext context;

  void _openDrawer() {
    drawerKey.currentState.open();
  }

  void _drawerCallback(bool status) {
    BlocProvider.of<DrawerOpenStateBloc>(this.context)
        .add(status ? DrawerControllerEvent.open : DrawerControllerEvent.close);
  }

  @override
  Widget build(BuildContext context) {
    this.context = context;

    return Scaffold(
      body: Stack(
        children: [
          Positioned(
            top: 0.0,
            left: 0.0,
            right: 0.0,
            child: (appBar == null)
                ? AppBar()
                : AppBar(
                    automaticallyImplyLeading: appBar.automaticallyImplyLeading,
                    title: appBar.title,
                    centerTitle: appBar.centerTitle,
                    actions: <Widget>[
                      GestureDetector(
                        child: appBar.actions[0],
                        onTap: () => _openDrawer(),
                      ),
                    ],
                  ),
          ),
          (this.topBody != null)
              ? BlocBuilder<DrawerOpenStateBloc, bool>(
                  builder: (context, isDrawerOpen) {
                  double left =
                      isDrawerOpen ? this.leftBodyOpen : this.leftBodyClose;
                  return AnimatedPositioned(
                    duration: Duration(seconds: 1),
                    top: this.topBody != null ? this.topBody : null,
                    left: left != null ? left : null,
                    child: (body == null) ? Container() : body,
                  );
                })
              : body,
          DrawerController(
            key: drawerKey,
            alignment: DrawerAlignment.end,
            child: drawer != null ? drawer : Container(),
            drawerCallback: (status) => _drawerCallback(status),
          ),
        ],
      ),
    );
  }
}
