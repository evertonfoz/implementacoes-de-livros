import 'package:flutter/material.dart';

class DefaultTextButton extends StatelessWidget {
  final String text;
  final VoidCallback onPressed;
  final Color? textColor;
  final double textFontSize;

  const DefaultTextButton({
    Key? key,
    required this.text,
    required this.onPressed,
    this.textColor,
    this.textFontSize: 18,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return TextButton(
      onPressed: onPressed,
      child: Text(
        text,
        style: TextStyle(
            fontSize: textFontSize,
            fontWeight: FontWeight.bold,
            color: textColor ?? Theme.of(context).primaryColor),
      ),
    );
  }
}
