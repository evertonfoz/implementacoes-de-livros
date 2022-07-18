import 'package:flutter/material.dart';

import 'core/presentation/theme.dart';

void main() {
  runApp(const ECDeliveryApp());
}

class ECDeliveryApp extends StatelessWidget {
  const ECDeliveryApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'EC Delivery',
      theme: theme(),
      home: const Scaffold(
        body: Center(
          child: Text('EC Delivery App'),
        ),
      ),
    );
  }
}
