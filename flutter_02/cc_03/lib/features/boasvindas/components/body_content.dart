import 'package:ec_delivery/core/presentation/constants/responsiveness.dart';
import 'package:ec_delivery/features/boasvindas/components/welcome_text.dart';
import 'package:ec_delivery/shared/presentation/components/brand/brand_image.dart';
import 'package:ec_delivery/shared/presentation/components/brand/brand_title.dart';
import 'package:flutter/material.dart';

import 'bottom_row.dart';

class BoasVindasContentBody extends StatelessWidget {
  const BoasVindasContentBody({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      child: ConstrainedBox(
        constraints: const BoxConstraints.tightFor(
          width: kDesktopBreakpoint,
        ),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            const BrandTitleWidget(),
            BrandImageWidget(
              width: MediaQuery.of(context).size.width * 0.9,
              height: MediaQuery.of(context).size.height * 0.5,
              fit: BoxFit.contain,
            ),
            const WelcomeTextWidget(),
            BottomRowBoasVindasWidget(),
          ],
        ),
      ),
    );
  }
}
