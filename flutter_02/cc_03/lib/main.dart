import 'package:ec_delivery/features/boasvindas/data/datasources/boasvindas_datasource.dart';
import 'package:ec_delivery/features/boasvindas/presentation/pages/boasvindas.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:responsive_framework/responsive_framework.dart';

import 'core/presentation/constants/responsiveness.dart';
import 'core/presentation/theme.dart';
import 'features/produtos/presentation/pages/crud.dart';

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
          ResponsiveBreakpoint.resize(kDesktopBreakpoint, name: DESKTOP),
        ],
        backgroundColor: Colors.indigo.shade600,
      ),
      home: FutureBuilder(
        future: _buildHome(),
        builder: (BuildContext context, AsyncSnapshot snapshot) {
          if (snapshot.connectionState == ConnectionState.done) {
            return snapshot.data;
          }

          return Container();
        },
      ),
    );
  }

  Future<Widget> _buildHome() async {
    if (await BoasVindasDataSource.getDontShowAgain()) {
      return const ProdutosCRUDPage();
    }

    return const BoasVindasPage();
  }
}