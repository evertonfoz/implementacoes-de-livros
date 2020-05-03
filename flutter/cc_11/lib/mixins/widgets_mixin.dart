import 'package:flutter/material.dart';

mixin TextFormFieldMixin {
  textFormField({
    maxLines,
    focusNode,
    controller,
    labelText,
    textInputAction,
    onFieldSubmitted,
    validator,
  }) {
    return TextFormField(
      autovalidate: true,
      maxLines: maxLines ?? 1,
      focusNode: focusNode ?? null,
      controller: controller ?? null,
      decoration: InputDecoration(
        labelText: labelText ?? 'Informe o labelText',
      ),
      textInputAction: textInputAction ?? null,
      onFieldSubmitted: onFieldSubmitted ?? null,
      validator: validator ?? null,
    );
  }
}
