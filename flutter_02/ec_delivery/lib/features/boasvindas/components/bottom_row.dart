import 'package:ec_delivery/features/boasvindas/data/datasources/boasvindas_datasource.dart';
import 'package:ec_delivery/features/produtos/presentation/pages/crud.dart';
import 'package:ec_delivery/features/produtos/presentation/pages/listagem.dart';
import 'package:ec_delivery/shared/presentation/components/buttons/default_text_button.dart';
import 'package:ec_delivery/shared/presentation/components/checkbox/checkbox.dart';
import 'package:flutter/material.dart';

class BottomRowBoasVindasWidget extends StatelessWidget {
  bool _checkedBoxValue = false;

  BottomRowBoasVindasWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        CheckBoxWidget(
          text: 'Não exibir mais',
          onChanged: (value) {
            _checkedBoxValue = value;
          },
        ),
        DefaultTextButton(
          text: 'Avançar',
          textFontSize: 24,
          onPressed: () async {
            final navigator = Navigator.of(context);

            await BoasVindasDataSource.registerDontShowAgain(
                value: _checkedBoxValue);

            navigator.pushReplacement(
              MaterialPageRoute(
                builder: (context) => const ProdutosListPage(),
              ),
            );
          },
        ),
      ],
    );
  }
}
