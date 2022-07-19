import 'package:flutter/material.dart';

import 'core/presentation/theme.dart';
import 'features/produtos/presentation/pages/crud.dart';

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
      home: ProdutosCRUDPage(),
    );
  }
}
