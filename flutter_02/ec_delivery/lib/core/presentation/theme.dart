import 'package:flutter/material.dart';

const kTextColor = Colors.white;

ThemeData theme() {
  return ThemeData(
    useMaterial3: true,
    // colorSchemeSeed: Colors.indigo,
    // colorScheme: ColorScheme.fromSeed(
    //   seedColor: Colors.indigo,
    //   primary: Colors.red,
    // ),
    // primarySwatch: Colors.indigo,
    primaryColor: Colors.white,
    appBarTheme: AppBarTheme(backgroundColor: Colors.indigo.shade900),
    scaffoldBackgroundColor: Colors.indigo.shade600,
    textTheme: textTheme(),
  );
}

TextTheme textTheme() {
  return const TextTheme(
    bodyText2: TextStyle(color: kTextColor),
  );
}
