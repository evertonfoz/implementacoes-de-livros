import 'package:ec_delivery/features/boasvindas/components/background.dart';
import 'package:ec_delivery/features/boasvindas/components/body_content.dart';
import 'package:flutter/material.dart';
import 'package:responsive_framework/responsive_framework.dart';

class BoasVindasPage extends StatelessWidget {
  const BoasVindasPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: Stack(
          children: const [
            ResponsiveVisibility(
              visible: false,
              visibleWhen: [
                Condition.largerThan(name: MOBILE),
              ],
              child: BoasVindasBackground(),
            ),
            BoasVindasContentBody(),
          ],
        ),
      ),
    );
  }
}
