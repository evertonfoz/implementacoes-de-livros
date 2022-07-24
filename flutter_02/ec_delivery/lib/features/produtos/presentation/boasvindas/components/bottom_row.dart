import 'package:ec_delivery/features/produtos/presentation/boasvindas/data/datasources/boasvindas_datasource.dart';
import 'package:ec_delivery/shared/presentation/components/buttons/default_text_button.dart';
import 'package:ec_delivery/shared/presentation/components/checkbox/checkbox.dart';
import 'package:flutter/material.dart';
import 'package:shared_preferences/shared_preferences.dart';

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

            var sp = await SharedPreferences.getInstance();
            var ds = BoasVindasDataSource(sharedPreferences: sp);

            await ds.registerDontShowAgain(value: _checkedBoxValue);

            navigator.pushReplacement(
              MaterialPageRoute(
                builder: (context) => ProdutosCRUDPage(),
              ),
            );
          },
        ),
      ],
    );
  }
}
