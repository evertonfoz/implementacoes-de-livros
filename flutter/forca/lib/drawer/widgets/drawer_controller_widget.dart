import 'package:flutter/material.dart';

// ignore: must_be_immutable
class DrawerControllerWidget extends StatelessWidget {
  final AppBar? appBar;
  final Widget? body;
  final double? topBody;
  final double? leftBody;
  final Drawer? drawer;
  final Function? callbackFunction;

  DrawerControllerWidget({
    Key? key,
    this.appBar,
    this.body,
    this.topBody,
    this.leftBody,
    this.drawer,
    this.callbackFunction,
  }) : super(key: key);

  GlobalKey<DrawerControllerState> drawerKey =
      GlobalKey<DrawerControllerState>();

  void _openDrawer() {
    drawerKey.currentState!.open();
  }

  void _drawerCallback(bool status) {
    if (callbackFunction != null) {
      callbackFunction!(status);
    }
  }

  @override
  Widget build(BuildContext context) => Scaffold(
        body: Stack(
          children: [
            Positioned(
              top: 0.0,
              left: 0.0,
              right: 0.0,
              child: (appBar == null)
                  ? AppBar()
                  : AppBar(
                      automaticallyImplyLeading:
                          appBar!.automaticallyImplyLeading,
                      title: appBar!.title,
                      centerTitle: appBar!.centerTitle,
                      actions: <Widget>[
                        GestureDetector(
                          child: appBar!.actions![0],
                          onTap: () => _openDrawer(),
                        ),
                      ],
                    ),
            ),
            (topBody != null || leftBody != null)
                ? AnimatedPositioned(
                    duration: const Duration(seconds: 1),
                    top: topBody,
                    left: leftBody,
                    child: (body == null) ? Container() : body!,
                  )
                : body!,
            DrawerController(
              key: drawerKey,
              alignment: DrawerAlignment.end,
              child: drawer != null ? drawer! : Container(),
              drawerCallback: (status) => _drawerCallback(status),
            ),
          ],
        ),
      );
}
