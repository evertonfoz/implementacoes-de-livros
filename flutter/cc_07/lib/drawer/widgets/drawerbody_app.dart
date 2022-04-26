import 'package:flutter/material.dart';

class DrawerBodyApp extends StatelessWidget {
  final Widget child;

  const DrawerBodyApp({Key? key, required this.child}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Expanded(
      child: Container(
        decoration: BoxDecoration(
          gradient: LinearGradient(
            colors: [Colors.green[100]!, Colors.green[400]!],
            begin: Alignment.topLeft,
            end: Alignment.bottomRight,
            stops: const [0.0, 1.0],
          ),
        ),
        child: child,
      ),
    );
  }
}
