import 'package:flutter/material.dart';

class DrawerControllerWidget extends StatelessWidget {
  final AppBar? appBar;
  final Widget? body;
  final double? topBody;
  final double? leftBody;

  const DrawerControllerWidget(
      {Key? key, this.appBar, this.body, this.topBody, this.leftBody})
      : super(key: key);

  @override
  Widget build(BuildContext context) => Scaffold(
        body: Stack(
          children: [
            Positioned(
              top: 0.0,
              left: 0.0,
              right: 0.0,
              child: appBar ?? AppBar(),
            ),
            (topBody != null || leftBody != null)
                ? Positioned(
                    top: topBody,
                    left: leftBody,
                    child: body ?? Container(),
                  )
                : body!,
          ],
        ),
      );
}
