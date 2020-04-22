import 'package:flutter/material.dart';

class DrawerControllerWidget extends StatelessWidget {
  final AppBar appBar;
  final Widget body;
  final double topBody;
  final double leftBody;
  final Drawer drawer;

  DrawerControllerWidget(
      {this.appBar, this.body, this.topBody, this.leftBody, this.drawer});

  GlobalKey<DrawerControllerState> drawerKey =
      GlobalKey<DrawerControllerState>();

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
                          appBar.automaticallyImplyLeading,
                      title: appBar.title,
                      centerTitle: appBar.centerTitle,
                      actions: <Widget>[
                        GestureDetector(
                          child: appBar.actions[0],
                        ),
                      ],
                    ),
            ),
            (this.topBody != null || this.leftBody != null)
                ? Positioned(
                    top: this.topBody != null ? this.topBody : null,
                    left: this.leftBody != null ? this.leftBody : null,
                    child: (body == null) ? Container() : body,
                  )
                : body,
            DrawerController(
              alignment: DrawerAlignment.end,
              child: drawer != null ? drawer : Container(),
            ),
          ],
        ),
      );
}
