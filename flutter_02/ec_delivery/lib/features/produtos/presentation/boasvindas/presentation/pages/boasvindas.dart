import 'package:ec_delivery/features/produtos/presentation/boasvindas/components/welcome_text.dart';
import 'package:ec_delivery/shared/bottom_row.dart';
import 'package:ec_delivery/shared/presentation/components/brand/brand_image.dart';
import 'package:ec_delivery/shared/presentation/components/brand/brand_title.dart';
import 'package:flutter/material.dart';

class BoasVindasPage extends StatelessWidget {
  const BoasVindasPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            const BrandTitleWidget(),
            BrandImageWidget(
              width: MediaQuery.of(context).size.width * 0.9,
              height: MediaQuery.of(context).size.height * 0.5,
            ),
            const WelcomeTextWidget(),
            const BottomRowBoasVindasWidget(),
          ],
        ),
      ),
    );
  }
}
