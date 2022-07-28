import 'package:flutter/material.dart';

class BrandImageWidget extends StatelessWidget {
  final double width;
  final double height;
  final ImageRepeat? repeat;
  final BoxFit? fit;
  final double? scale;

  const BrandImageWidget({
    Key? key,
    this.width = 90,
    this.height = 50,
    this.repeat,
    this.fit,
    this.scale,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Image.asset(
      'assets/images/brand/320x253.png',
      width: width,
      height: height,
      fit: fit,
      repeat: repeat ?? ImageRepeat.noRepeat,
      scale: scale,
    );
  }
}
