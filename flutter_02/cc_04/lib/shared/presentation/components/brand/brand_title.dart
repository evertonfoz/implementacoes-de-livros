import 'package:flutter/material.dart';

class BrandTitleWidget extends StatelessWidget {
  final double fontSize;

  const BrandTitleWidget({Key? key, this.fontSize = 62}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Text(
        'EC Delivery',
        style: TextStyle(
          fontSize: fontSize,
          color: Theme.of(context).primaryColor,
          fontWeight: FontWeight.bold,
        ),
      ),
    );
  }
}
