import 'package:flutter/material.dart';

class DrawerBodyApp extends StatelessWidget {
  final Widget child;

  const DrawerBodyApp({@required this.child});

  @override
  Widget build(BuildContext context) {
    return Expanded(
      child: Container(
        decoration: new BoxDecoration(
          gradient: new LinearGradient(
            colors: [Colors.green[100], Colors.green[400]],
            begin: Alignment.topLeft,
            end: Alignment.bottomRight,
            stops: [0.0, 1.0],
          ),
        ),
        child: this.child,
      ),
    );
  }
}
