import 'package:ec_delivery/features/produtos/presentation/components/crud/textformdfield.dart';
import 'package:ec_delivery/features/produtos/presentation/mobx_stores/produto_store.dart';
import 'package:flutter/material.dart';
import 'package:get_it/get_it.dart';

class FormTextFields extends StatelessWidget {
  const FormTextFields({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        TextFormFieldPEF(
          controller: GetIt.I.get<ProdutoStore>().nomeController,
          text: 'Nome',
          textInputAction: TextInputAction.next,
          onChanged: (value) =>
              GetIt.I.get<ProdutoStore>().atualizarNome(value!),
        ),
        const SizedBox(height: 10),
        TextFormFieldPEF(
          controller: GetIt.I.get<ProdutoStore>().descricaoController,
          text: 'Descrição',
          textInputAction: TextInputAction.next,
          onChanged: (value) =>
              GetIt.I.get<ProdutoStore>().atualizarDescricao(value!),
        ),
        const SizedBox(height: 10),
        TextFormFieldPEF(
          controller: GetIt.I.get<ProdutoStore>().valorController,
          text: 'Valor',
          textInputType: TextInputType.number,
          textInputAction: TextInputAction.done,
          onChanged: (value) =>
              GetIt.I.get<ProdutoStore>().atualizarValor(value!),
        ),
        const SizedBox(height: 20),
      ],
    );
  }
}
