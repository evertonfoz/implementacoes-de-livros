import 'package:ec_delivery/features/produtos/presentation/components/crud/textformdfield.dart';
import 'package:flutter/material.dart';

import 'button.dart';
import 'photo.dart';

class ProdutosFormWidget extends StatelessWidget {
  const ProdutosFormWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Form(
      child: Column(
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
          SizedBox(height: 10),
          PhotoProdutoWidget(),
          SizedBox(height: 10),
          GravarProdutoButton(),
        ],
      ),
    );
  }
}
