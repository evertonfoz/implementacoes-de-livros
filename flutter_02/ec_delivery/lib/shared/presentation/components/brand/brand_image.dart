import 'package:flutter/material.dart';

class BrandImageWidget extends StatelessWidget {
  final double width;
  final double height;

  const BrandImageWidget({
    this.width = 90,
    this.height = 50,
  });

  @override
  Widget build(BuildContext context) {
    return Image.asset(
      'assets/images/brand/320x253.png',
      width: width,
      height: height,
      fit: BoxFit.contain,
    );
  }
}
