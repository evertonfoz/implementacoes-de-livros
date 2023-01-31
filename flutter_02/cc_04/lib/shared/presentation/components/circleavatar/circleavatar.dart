import 'package:flutter/material.dart';

class CircleAvatarPEF extends StatelessWidget {
  final double radius;
  final Color borderColor;
  final Color backgroundColor;
  final String imageURL;

  const CircleAvatarPEF({
    Key? key,
    this.radius = 32,
    this.borderColor = Colors.white38,
    this.backgroundColor = Colors.indigo,
    required this.imageURL,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return CircleAvatar(
      radius: radius,
      backgroundColor: borderColor,
      child: CircleAvatar(
        radius: radius - 2,
        backgroundColor: backgroundColor,
        foregroundImage: Image.asset(
          imageURL,
          fit: BoxFit.fill,
        ).image,
      ),
    );
  }
}
