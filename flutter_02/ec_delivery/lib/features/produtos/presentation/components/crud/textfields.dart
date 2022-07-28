import 'package:ec_delivery/features/produtos/presentation/components/crud/textformdfield.dart';
import 'package:flutter/material.dart';

class FormTextFields extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Column(
      children: const [
        TextFormFieldPEF(
          text: 'Nome',
          textInputAction: TextInputAction.next,
        ),
        SizedBox(height: 10),
        TextFormFieldPEF(
          text: 'Descrição',
          textInputAction: TextInputAction.next,
        ),
        SizedBox(height: 10),
        TextFormFieldPEF(
          text: 'Valor',
          textInputType: TextInputType.number,
          textInputAction: TextInputAction.done,
        ),
        SizedBox(height: 20),
      ],
    );
  }
}
