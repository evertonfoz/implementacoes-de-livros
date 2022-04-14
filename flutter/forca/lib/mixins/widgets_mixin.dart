import 'package:flutter/material.dart';

mixin TextFormFieldMixin {
  textFormField({
    maxLines,
    required focusNode,
    required controller,
    required labelText,
    textInputAction,
    onFieldSubmitted,
    required validator,
    initialValue = '',
    onChanged,
  }) {
    return TextFormField(
      initialValue: initialValue,
      autocorrect: true,
      maxLines: maxLines ?? 1,
      focusNode: focusNode,
      // controller: controller,
      decoration: InputDecoration(
        labelText: labelText,
      ),
      textInputAction: textInputAction,
      onFieldSubmitted: onFieldSubmitted,
      validator: validator,
      onChanged: onChanged,
    );
  }
}
