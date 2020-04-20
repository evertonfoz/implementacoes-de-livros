import 'package:flutter/material.dart';

class DrawerControllerWidget extends StatelessWidget {
  @override
  Widget build(BuildContext context) => Scaffold(
        body: Stack(
          children: [
            Positioned(
              top: 0.0,
              left: 0.0,
              right: 0.0,
              child: AppBar(),
            ),
          ],
        ),
      );
}
