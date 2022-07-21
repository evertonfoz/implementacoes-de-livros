import 'package:flutter/material.dart';

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
  );
}
