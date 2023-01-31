import 'package:ec_delivery/core/presentation/constants/responsiveness.dart';
import 'package:ec_delivery/features/produtos/presentation/components/crud/devices/desktop.dart';
import 'package:ec_delivery/features/produtos/presentation/components/crud/devices/mobile.dart';
import 'package:flutter/material.dart';
import 'package:responsive_framework/responsive_framework.dart';

class ProdutosFormWidget extends StatelessWidget {
  const ProdutosFormWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Form(
      child: Center(
        child: ConstrainedBox(
          constraints: BoxConstraints.tightFor(
            width: kDesktopBreakpoint,
            height: MediaQuery.of(context).size.height * 0.8,
          ),
          child: const ResponsiveVisibility(
            visible: false,
            visibleWhen: [
              Condition.smallerThan(name: DESKTOP),
            ],
            // ignore: sort_child_properties_last
            child: MobileForm(),
            replacement: DesktopForm(),
          ),
        ),
      ),
    );
  }
}
