import 'package:ec_delivery/shared/presentation/components/buttons/default_text_button.dart';
import 'package:ec_delivery/shared/presentation/components/checkbox/checkbox.dart';
import 'package:flutter/material.dart';

class BottomRowBoasVindasWidget extends StatelessWidget {
  const BottomRowBoasVindasWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        const CheckBoxWidget(
          text: 'Não exibir mais',
        ),
        DefaultTextButton(
          text: 'Avançar',
          textFontSize: 24,
          onPressed: () {},
        ),
      ],
    );
  }
}
