import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:responsive_framework/responsive_framework.dart';

import 'core/presentation/theme.dart';
import 'features/produtos/presentation/boasvindas/presentation/pages/boasvindas.dart';

void main() {
  SystemChrome.setSystemUIOverlayStyle(
    const SystemUiOverlayStyle(statusBarColor: Colors.transparent),
  );
  runApp(const ECDeliveryApp());
}

class ECDeliveryApp extends StatelessWidget {
  const ECDeliveryApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'EC Delivery',
      theme: theme(),
      builder: (context, widget) => ResponsiveWrapper.builder(
        widget,
        minWidth: 410,
        defaultScale: true,
        breakpoints: const [
          ResponsiveBreakpoint.resize(410, name: MOBILE),
          ResponsiveBreakpoint.autoScale(560, name: TABLET),
        ],
        backgroundColor: Colors.indigo.shade600,
      ),
      home: const BoasVindasPage(),
    );
  }
}
