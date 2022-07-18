import 'package:flutter/material.dart';

class TextFormFieldForca extends StatelessWidget {
  final int maxLines;
  final FocusNode focusNode;
  final TextEditingController controller;
  final String labelText;
  final TextInputAction textInputAction;
  final Function(String) onFieldSubmitted;
  final Function(String?) validator;

  const TextFormFieldForca({
    Key? key,
    this.maxLines = 1,
    required this.focusNode,
    required this.controller,
    required this.labelText,
    required this.textInputAction,
    required this.onFieldSubmitted,
    required this.validator,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return TextFormField(
      autocorrect: true,
      maxLines: maxLines,
      focusNode: focusNode,
      controller: controller,
      decoration: InputDecoration(
        labelText: labelText,
      ),
      textInputAction: textInputAction,
      onFieldSubmitted: onFieldSubmitted,
      validator: (value) => validator(value),
    );
  }
}
