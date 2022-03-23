import 'package:flutter/material.dart';

class ContainerIluminadoWidget extends StatelessWidget {
  final double height;
  final Color backgroundColor;
  final Color shadowColor;
  final Widget child;

  const ContainerIluminadoWidget({
    Key? key,
    this.height = 125,
    this.backgroundColor = Colors.white,
    this.shadowColor = Colors.grey,
    required this.child,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: const EdgeInsets.only(bottom: 16.0),
      child: Container(
          height: height,
          decoration: BoxDecoration(
              color: backgroundColor,
              borderRadius: const BorderRadius.all(Radius.circular(15)),
              boxShadow: [
                BoxShadow(
                  blurRadius: 5,
                  color: shadowColor,
                  spreadRadius: 5,
                  offset: const Offset(0.1, 0.1),
                )
              ]),
          child: child),
    );
  }
}
